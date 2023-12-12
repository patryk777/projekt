using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace ElectRight.Api.CQRS;

internal interface IQueryBus
{
    Task<List<T>> SendAsync<T>();
}