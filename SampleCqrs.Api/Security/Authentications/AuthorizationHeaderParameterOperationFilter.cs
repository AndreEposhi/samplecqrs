using Swashbuckle.Swagger;
using System.Web.Http.Description;

namespace SampleCqrs.Api.Security.Authentications
{
    /// <summary>
    /// Adicionar a autorização ao cabeçãlho da requisição Http
    /// </summary>
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Aplica a autorização ao cabeçalho da requisição Htpp
        /// </summary>
        /// <param name="operation">Operação a ser adicionada</param>
        /// <param name="schemaRegistry">Schema registrado</param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "acess token",
                    type = "string"
                });
            }
        }
    }
}