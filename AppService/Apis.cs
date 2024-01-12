using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using testing_picking.Models.Auth;
using testing_picking.Models.BorderPicking;
using testing_picking.Models.Confirm;
using testing_picking.Models.Divert;
using testing_picking.Models.TransferInbound;

namespace testing_picking.AppService
{
    public class Apis : IApisAppService
    {
        private readonly string endpoint = "https://localhost:7180/";
        private readonly HttpClient httpClient;

        public Apis()
        {
            httpClient = new HttpClient();
        }

        private void ConfigureHeaders(string bearerToken)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        public async Task<TransferInboundReturn> TransferInboundAsync(TransferRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "transfer-inboud/check-tote";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    TransferInboundReturn result = JsonConvert.DeserializeObject<TransferInboundReturn>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<string> GetBearerTokenAsync(string username, string password)
        {
            string authEndpointUrl = endpoint + "api/Auth";

            var authRequestData = new
            {
                userName = username,
                password
            };

            try
            {
                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(authRequestData);

                // Realiza la solicitud HTTP POST para obtener el token
                HttpResponseMessage response = await httpClient.PostAsync(authEndpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<AuthResponse> authResponses = JsonConvert.DeserializeObject<List<AuthResponse>>(jsonResponse);
                    return authResponses[0].Token;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud de autenticación: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
        }
        public async Task<BorderPickingResponse> BorderPickingAsync(TransferRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "api/ToteInformation/receive-flow/borderPicking";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }

        public async Task<BorderPickingResponse> DivertAsync(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }

        public async Task<BorderPickingResponse> DivertSingleAsync(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/singleTote";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<BorderPickingResponse> DivertMultiAsync(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/multiTote";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<BorderPickingResponse> DivertCam11Async(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/TotesCam11";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<BorderPickingResponse> DivertCam14Async(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/multiToteCam14";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<BorderPickingResponse> DivertCam15Async(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/multiToteCam15";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<BorderPickingResponse> DivertCam16Async(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/multiToteCam16";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<BorderPickingResponse> DivertCam17Async(DivertRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/divert/multiToteCam17";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta y deserializa el JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    BorderPickingResponse result = JsonConvert.DeserializeObject<BorderPickingResponse>(jsonResponse);
                    return result;
                }
                else
                {
                    // Manejar errores según sea necesario
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<string> DivertConfirm(ConfirmRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/confirmation";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    return "confirm";
                }
                else
                {
                    return "no";
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<string> DivertConfirm14Async(ConfirmRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/confirmation/Cam14";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    return "confirm";
                }
                else
                {
                    return "no";
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<string> DivertConfirm15Async(ConfirmRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/confirmation/Cam15";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    return "confirm";
                }
                else
                {
                    return "no";
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }

        public async Task<string> DivertConfirm16Async(ConfirmRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/confirmation/Cam16";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    return "confirm";
                }
                else
                {
                    return "no";
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
        public async Task<string> DivertConfirm17Async(ConfirmRequest requestData, string bearerToken)
        {
            string endpointUrl = endpoint + "divert-flow/confirmation/Cam17";

            try
            {
                ConfigureHeaders(bearerToken);

                // Convierte el objeto a formato JSON
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                // Realiza la solicitud HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(endpointUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                // Verifica si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    return "confirm";
                }
                else
                {
                    return "no";
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            finally
            {
                // Limpia la cabecera de autorización después de la solicitud
                httpClient.DefaultRequestHeaders.Clear();
            }
        }
    }

}
