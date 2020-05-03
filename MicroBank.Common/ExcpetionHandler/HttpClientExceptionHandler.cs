using MicroBank.Common.ExceptionHandler.Exceptions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBank.Common.ExceptionHandler
{
    public class HttpClientExceptionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new MicroBankUnauthorizedExeption();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    throw new MicroBankInternalServerErrorException();
                }

                var result = await response.Content.ReadAsAsync<MicroBankHttpError>();

                if (result == null)
                {
                    throw new ForwardedMicroBankExeption(null, null, response.StatusCode);
                }

                throw new ForwardedMicroBankExeption(result.Error, result.Code, response.StatusCode);
            }

            return response;
        }
    }
}
