using Domain.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.SharedKernel.Validation;
using Newtonsoft.Json;

namespace App.WebAPI.Middleware
{
    /// <summary>
    /// Objeto retornado pela API quando ocorre algum erro.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// O erro que ocorreu
        /// </summary>
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public Error Error { get; private set; }

        /// <summary>
        /// Detalhes dos erros
        /// </summary>
        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public List<Error> Details { get; private set; }

        /// <summary>
        /// Erro interno
        /// </summary>
        [JsonProperty("innererror", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorResponse InnerError { get; private set; }
        
        private ErrorResponse()
        {
        }

        /// <summary>
        /// Cria um ErrorResponse baseado em uma exceção
        /// </summary>
        /// <param name="ex">Exceção</param>
        /// <param name="target">Referencia do erro</param>
        public ErrorResponse(Exception ex, string target = null)
        {
            var response = GetErrorResponseFromException(ex, target);
            Error = response.Error;
            Details = response.Details;
            InnerError = response.InnerError;
        }

        private ErrorResponse GetErrorResponseFromException(Exception ex, string target)
        {
            ErrorResponse response = new ErrorResponse();

            response.Error = new Error
            {
                Message = ex.Message,
                Target = target
            };

            switch (ex)
            {
                case NotFoundException nfEx:
                    response.Error.Code = ErrorCode.NotFound.ToString();
                    break;
                case FieldsValidationException fvEx:
                    response.Error.Code = ErrorCode.BadArgument.ToString();
                    response.Details = GetDetais(fvEx.FieldsValidation);
                    break;
                case UserLoginFailedException ulfEx:
                    response.Error.Code = ErrorCode.BadArgument.ToString();
                    break;
                default:
                    Error.Code = ErrorCode.ServerInternalError.ToString(); // 500 se for qualquer outro erro
                    break;
            }

            if(ex.InnerException != null)
            {
                response.InnerError = GetErrorResponseFromException(ex.InnerException, null);
            }

            return response;
        }


        private List<Error> GetDetais(IList<FieldValidationInfo> fieldsValidation)
        {
            if (!fieldsValidation.Any())
                return null;

            var lista = new List<Error>();

            foreach(var item in fieldsValidation)
            {
                lista.Add(new Error
                {
                    Message = item.Message,
                    Code = ErrorCode.BadArgument.ToString(),
                    Target = item.Field
                });
            }

            return lista;
        }
    }

    /// <summary>
    /// Representa um erro
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Código do erro
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// Mensagem
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Objeto onde o erro ocorreu
        /// </summary>
        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }

    }

    /// <summary>
    /// Códigos de erro
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Erro interno do servidor
        /// </summary>
        ServerInternalError,

        /// <summary>
        /// Informações incorretas enviadas na requisição
        /// </summary>
        BadArgument,

        /// <summary>
        /// Recurso não encontrado
        /// </summary>
        NotFound,

        /// <summary>
        /// Conflito
        /// </summary>
        Conflict
            
    }
}
