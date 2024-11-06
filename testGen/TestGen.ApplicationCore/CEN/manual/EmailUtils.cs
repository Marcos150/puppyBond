using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace TestGen.ApplicationCore.CEN.DSM;

public class EmailUtils
{
    public static void SendEmail(string receptor, string asunto, string contenido)
    {
        //Lo de abajo se carga de un fichero .env que no se sube a GitHub ya que contiene credenciales secretas
        DotNetEnv.Env.Load();
        DotNetEnv.Env.TraversePath().Load();
        string direccionGmail = System.Environment.GetEnvironmentVariable("gmailAddress");
        string contrasenya = System.Environment.GetEnvironmentVariable("gmailPassword");
        string servidorSmtp = System.Environment.GetEnvironmentVariable("smtpServer");
        string puerto = System.Environment.GetEnvironmentVariable("port");
        
        var message = new MimeMessage ();
        message.From.Add (new MailboxAddress ("Puppybond", direccionGmail));
        message.To.Add (new MailboxAddress (receptor, receptor));
        message.Subject = asunto;

        message.Body = new TextPart ("plain") {
            Text = contenido
        };

        using (var client = new SmtpClient ()) {
            client.Connect (servidorSmtp, Int32.Parse (puerto ?? "485"), true);
            
            client.Authenticate (direccionGmail, contrasenya);

            client.Send (message);
            client.Disconnect (true);
        }
    }

    public static void SendEmailToSelf(string asunto, string contenido)
    {
        DotNetEnv.Env.Load();
        DotNetEnv.Env.TraversePath().Load();
        string direccionGmail = System.Environment.GetEnvironmentVariable("gmailAddress");
        SendEmail(direccionGmail, asunto, contenido);
    }
}