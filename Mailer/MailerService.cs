using MailKit.Net.Smtp;
using MimeKit;

namespace Mailer
{
    public class MailerService : IMailerService
    {
        private string _Host { get; set; }
        private int _Port { get; set; }
        private string _Username { get; set; }
    
        private string _AppEmail { get; set; }
        private string _AppName { get; set; }

        public MailerService(string host, int port, string username, string appEmail, string appName)
        {
            _Host = host;
            _Port = port;
            _Username = username;
            _AppEmail = appEmail;
            _AppName = appName;
        }

        // Méthode pour envoyer un email de bienvenue lors de l'inscription à la newsletter
        public void SendSubscriptionEmail(string email)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_AppName,_AppEmail));
            message.To.Add(new MailboxAddress(_Username, _AppEmail));
            message.Subject = "Bienvenue à notre newsletter!";
            message.Body = new TextPart("plain")
            {
                Text = "Merci de vous être inscrit à notre newsletter. Nous sommes ravis de vous compter parmi nos abonnés!"
            };

            using SmtpClient smtpClient = new SmtpClient();
            try
            {
                // - Connexion au serveur Smtp
                smtpClient.Connect(_Host, _Port, false);

                // - Envoi du mail 
                smtpClient.Send(message);
            }
            finally
            {
                smtpClient.Disconnect(true);
            }

        }

        // Méthode pour envoyer un email de confirmation lors de la désinscription de la newsletter
        public void SendUnsubscriptionEmail(string email)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_AppName, _AppEmail));
            message.To.Add(new MailboxAddress(_Username, _AppEmail));
            message.Subject = "Desinsciption à notre newsletter";
            message.Body = new TextPart("plain")
            {
                Text = "Vous avez été désinscrit de notre newsletter. Nous sommes désolés de vous voir partir."
            };

            using SmtpClient smtpClient = new SmtpClient();
            try
            {
                // - Connexion au serveur Smtp
                smtpClient.Connect(_Host, _Port, false);

                // - Envoi du mail 
                smtpClient.Send(message);
            }
            finally
            {
                smtpClient.Disconnect(true);
            }


        }


        }
    }
