using BlazorApp.Models.Entities;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace BlazorApp.Models.Queries
{
    public class LoginQuery : IQueryDefinition<User>
    {
        public string Email { get; }
        public string Passwd { get; }

        public LoginQuery(string email, string passwd)
        {
            Email = email;
            Passwd = passwd;
        }
    }
}
