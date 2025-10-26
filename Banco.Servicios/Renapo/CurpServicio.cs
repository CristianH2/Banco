using Banco.Core.Dtos;
using Banco.Core.IServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Banco.Servicios.Renapo
{
    public class CurpServicio : ICurpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CurpServicio(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GenerarCurp(SolicitudDto solicitudDeCurpDto)
        {
            const string endpoint = "https://utilidades.vmartinez84.xyz/api/Curp";
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Add("accept", "application/json");
            request.Content = new StringContent(JsonConvert.SerializeObject(solicitudDeCurpDto), null, "application/json");
            var response = await client.SendAsync(request);
            var data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                CurpDto curpDto;

                curpDto = JsonConvert.DeserializeObject<CurpDto>(await response.Content.ReadAsStringAsync());

                return curpDto.Curp;
            }

            return string.Empty;
        }
    }

}
