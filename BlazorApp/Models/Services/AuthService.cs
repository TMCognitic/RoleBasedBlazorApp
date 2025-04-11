using BlazorApp.Models.Entities;
using BlazorApp.Models.Queries;
using BlazorApp.Models.Repositories;
using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.CommandQuerySeparation.Results;
using System.Net.Http.Json;

namespace BlazorApp.Models.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly HttpClient _client;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("Api");
        }

        public async ValueTask<IQueryResult<User>> ExecuteAsync(LoginQuery query)
        {
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("auth/login", query);

            if (responseMessage.IsSuccessStatusCode)
            {
                User? user = await responseMessage.Content.ReadFromJsonAsync<User>();

                if (user is null)
                    return IQueryResult<User>.Failure("Quelque chose en va pas", null);

                return IQueryResult<User>.Success(user);
            }
            else
            {
                switch (responseMessage.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return IQueryResult<User>.Failure("Mot de passe ou Email invalide", null);
                    default:
                        return IQueryResult<User>.Failure("Quelque chose en va pas", null);
                }
            }
        }
    }
}
