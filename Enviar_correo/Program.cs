using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Enviar_correo
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress("mbaltazar12@itscc.edu.mx")); //correo destino
            email.From = new MailAddress("webmaster_bcs@hotmail.com"); //correo origen
            email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";//asunto
            email.Body = "Cualquier contenido en <b>HTML</b> para enviarlo por correo electrónico.";//contenido
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Low;//prioridad

            //credenciales
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.live.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("webmaster_bcs@hotmail.com", "webmaster2016");
            //

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
