using System.ComponentModel;

namespace SampleCqrs.Domain.Core.Enums
{
    namespace Responses
    {
        public enum ResponseStatus
        {
            [Description("Erro")]
            Erro,

            [Description("Sucesso")]
            Sucesso
        }
    }
}