using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Servicios
{
    public class ServicioEmail
    {
        private SmtpClient servidor;
        private MailMessage email;

        public ServicioEmail()
        {
            try
            {
                servidor = new SmtpClient();
                servidor.Credentials = new NetworkCredential("validaciones.claves@gmail.com", "stpehrmexdydhtzz");
                servidor.EnableSsl = true;
                servidor.Port = 587;
                servidor.Host = "smtp.gmail.com";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void armarEmail(string emailDestino, string asunto, string cuerpo, string emailOrigen)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress(emailOrigen);
                email.To.Add(emailDestino);
                email.Subject = asunto;
                email.IsBodyHtml = true;
                email.Body = cuerpo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void enviarEmail()
        {
            try
            {
                servidor.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
