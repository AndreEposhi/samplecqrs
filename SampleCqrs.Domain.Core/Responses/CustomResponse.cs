using Newtonsoft.Json;
using SampleCqrs.Domain.Core.Enums.Responses;
using SampleCqrs.Domain.Common.Extensions;
using System.Collections.Generic;

namespace SampleCqrs.Domain.Core.Responses
{
    public class CustomResponse
    {
        public CustomResponse(ResponseStatus status = ResponseStatus.Erro, string mensagem = "Ocorreu erros de validação")
        {
            Status = status;
            Mensagem = mensagem;
            Erros = new List<string>();
            Dados = new List<object>();
        }

        [JsonIgnore]
        public ResponseStatus Status { get; private set; }

        public string StatusResposta { get => Status.GetDescription(); }
        public string Mensagem { get; private set; }
        public IList<string> Erros { get; private set; }
        public IList<object> Dados { get; private set; }
        public void AdicionarErro(IList<string> erros)
        {
            Erros.Clear();

            foreach (var erro in erros)
                Erros.Add(erro);
        }
        public void AdicionarDado(IList<object> dados)
        {
            Dados.Clear();

            foreach (var dado in dados)
                Dados.Add(dado);
        }
    }
}