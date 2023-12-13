using ElectRightApplication.Data.UnitOfWork;
using ElectRightApplication.Interfaces;
using Microsoft.Extensions.Logging;

namespace ElectRight.Infrastructure.Services.UnitOfWork
{
    public class UnitOfWorkService<T>(IUnitOfWorkService unitOfWork, Logger<UnitOfWorkService> logger) : IUnitOfWorkService<T>
    {
        private bool isTransactionActive;

        public async Task BeginTransactionAsync()
        {
            CheckAndThrowIfNeeded();
            try
            {
                aw.BeginTransactionAsync();
                isTransactionActive = true;
            }
            catch (Exception e)
            {
                logger.LogError("BeginTransactionAsync has failed", e);
                throw;
            }
        }
        
        public async Task EndTransactionAsync()
        {
            CheckAndThrowIfNeeded();
            try
            {
                await unitOfWork.e();
                isTransactionActive = true;
            }
            catch (Exception e)
            {
                logger.LogError("EndTransactionAsync has failed", e);
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            CheckAndThrowIfNeeded();

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch(Exception e)
            {
                await RollbackAsync();

                throw;
            }
            finally
            {
                isTransactionActive = false;
            }

            try
            {
                await unitOfWork.CommitTransactionAsync();
            }
            catch (Exception e)
            {
                logger.LogError("CommitTransactionAsync has failed");
                throw;
            }
            
            isTransactionActive = false;
        }

        private async Task RollbackAsync()
        {
            if (!isTransactionActive)
            {
                logger.LogTrace("Rollback stars");
                await unitOfWork.RollbackTransactionAsync();
                logger.LogTrace("Rollback has stopped");
            }
        }

        public async Task RollbackChangesAsync()
        {
            CheckAndThrowIfNeeded();

            try
            {
                await unitOfWork.RollbackTransactionAsync();
            }
            catch (Exception e)
            {
                logger.LogError("RollbackChangesAsync has failed", e);
                throw;
            }
            finally
            {
                isTransactionActive = false;
            }
        }

        private void CheckAndThrowIfNeeded()
        {
            if (!isTransactionActive)
            {
                throw new InvalidOperationException("No active transaction.");
            }
        }
    }
}
