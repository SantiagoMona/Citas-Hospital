using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simulacro2.Services.MailSend
{

    public class EmailSender : IEmailSender
    {
        private readonly HttpClient _httpClient;
        private readonly string? _ApiUrl; // LINK DE LA API
        private readonly string? _ApiKey; // TOKEN
        private readonly string? _FromEmail; // CORREO DESDE DONDE SE ENVIA 

        public EmailSender(HttpClient httpClient,IConfiguration configuration){
            _httpClient = httpClient;
            _ApiUrl = configuration["MailerSend:ApiUrl"];
            _ApiKey = configuration["MailerSend:ApiKey"];
            _FromEmail = configuration["MailerSend:FromEmail"];

        }
        public async Task<string> SendEmailAsync(string info, string toEmail)
        {
            var request = new {
                from = new {email = _FromEmail} ,// se le ingresa el correo que ya tenemos configuarados en el JSON
                to = new[] {new {email = toEmail}} , // este es a quien se le va a enviar el correo 
                subject = "Este es un correo" ,// asunto 
                text = "envio de correo de prueba"    // 
            };
            // configuracion de token 
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _ApiKey);

            try{

                // se solicita una peticion http tipo post y se le envia la informacion que se obtuvo en el request
                var response = await _httpClient.PostAsJsonAsync("https://api.mailersend.com/v1/email",request); 

                // se verifica si la respuesta fue exitosa
                //response.EnsureSuccessStatusCode(); 
                Console.WriteLine("Vamoa enviar un correo!!!!");
                return $"se ha enviado con exito a {request}";
            }catch (HttpRequestException ex)
            {
                Console.WriteLine("Estamos saltando acá!!!");
                return $"Error al enviar correo___HERE !!: {ex.Message}";
                throw new ApplicationException("errorrr perrroror");
            }
            
        }

        
    }
}