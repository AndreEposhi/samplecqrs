using SampleCqrs.Api.Security.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace SampleCqrs.Api.Security.Authentications.Attributes
{
    /// <summary>
    /// Atributo que define que o controlador irá possuir uma autorização para ser executado
    /// </summary>
    public class Authorization : AuthorizeAttribute, IAuthenticationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authenticationHeaderValue = request.Headers.Authorization;
            string[] tokenAndUser = null;

            if (authenticationHeaderValue == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing authorization header.", request);
                return;
            }

            if (!authenticationHeaderValue.Scheme.Equals("Bearer"))
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid authorization schema", request);
                return;
            }

            tokenAndUser = authenticationHeaderValue.Parameter.Split(':');

            var token = tokenAndUser[0];
            //var userName = tokenAndUser[1];
            var validuserName = TokenManager.ValidateToken(token);

            if (string.IsNullOrWhiteSpace(token))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing token", request);
                return;
            }

            //if (!userName.Equals(validuserName))
            //{
            //    context.ErrorResult = new AuthenticationFailureResult("Invalid token for user.", request);
            //    return;
            //}

            context.Principal = TokenManager.GetClaimsPrincipal(token);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);

            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));

            context.Result = new ResponseMessageResult(result);
        }
    }
}