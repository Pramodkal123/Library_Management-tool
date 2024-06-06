using System;
using System.Net.Mail;
using System.Windows;

namespace cw_sample1
{
    class email
    {
        public void sendmail(String email, String subject,String body)
        {
            try
            {
                MailMessage reminder = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp-relay.brevo.com");
                reminder.From = new MailAddress("fishbun8@gmail.com");
                reminder.To.Add(email);
                reminder.Subject = subject;
                reminder.Body = body;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("fishbun8@gmail.com", "MCHEmbKqpxdzI3yS");
                smtp.EnableSsl = true;
                smtp.Send(reminder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
