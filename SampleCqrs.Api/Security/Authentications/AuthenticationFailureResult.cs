using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleCqrs.Api.Security.Authentications
{
    /// <summary>
    ///
    /// </summary>
    public class AuthenticationFailureResult : IHttpActionResult
    {
        /// <summary>
        ///
        /// </summary>
        public string ReasonPhrase;

        /// <summary>
        ///
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="reasonPhrase"></param>
        /// <param name="request"></param>
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(Execute());

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Execute()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            responseMessage.RequestMessage = Request;
            responseMessage.ReasonPhrase = ReasonPhrase;

            return responseMessage;
        }
    }
}