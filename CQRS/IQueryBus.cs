using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using ElectRightApplication.CQRS.Queries;

namespace ElectRight.Api.CQRS;

internal interface IQueryBus
{
    Task<List<T>> SendAsync<T>(RetrieveAllCandidatesQuery retrieveAllCandidatesQuery);
}