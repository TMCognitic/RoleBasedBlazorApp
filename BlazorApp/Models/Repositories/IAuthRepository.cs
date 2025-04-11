using BlazorApp.Models.Entities;
using BlazorApp.Models.Queries;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace BlazorApp.Models.Repositories
{
    public interface IAuthRepository : IQueryAsyncHandler<LoginQuery, User>
    {
    }
}
