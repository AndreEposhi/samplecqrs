using SampleCqrs.Domain.Core.Responses;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SampleCqrs.Api.Controllers
{
    /// <summary>
    /// Controlador base da Api
    /// </summary>
    public class ApiBaseController : ApiController
    {
        /// <summary>
        /// Recupera a resposta customizada da Api
        /// </summary>
        /// <param name="response">Resposta customizada a ser recuperada</param>
        /// <returns></returns>
        protected IHttpActionResult GetCustomResponse(CustomResponse response)
        {
            try
            {
                if (response.Status == Domain.Core.Enums.Responses.ResponseStatus.Sucesso)
                    if (response.Dados.Any())
                        return Ok(response.Dados);
                    else
                        return Ok(response);

                var modelStateDictionary = new ModelStateDictionary();

                foreach (var erro in response.Erros)
                    modelStateDictionary.AddModelError("Message: ", erro);

                return BadRequest(modelStateDictionary);
            }
            catch (Exception excecao)
            {
                return BadRequest($"Ocorreu o seguinte erro: {excecao.Message}");
            }
        }
    }
}