using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> SendMail([Bind] string mailContent,string mailSubject) 
        {
            string result = "";
            try
            {
                using (SmtpClient MailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    MailAddress receiverAddress = new MailAddress("momomomomo7677@gmail.com", "肥子776");//<-這物件只是用來設定郵件帳號而已~
                    MailAddress senderAddress = new MailAddress("chickensoupengineer@gmail.com", "雞湯工程師");
                    MailMessage mail = new MailMessage(senderAddress, receiverAddress);//<-這物件是郵件訊息的部分~需設定寄件人跟收件人~可直接打郵件帳號也可以使用MailAddress物件~
                    mail.Subject = mailSubject;
                    mail.Body = mailContent;
                    mail.IsBodyHtml = true;//<-如果要這封郵件吃html的話~這屬性就把他設為true~~

                    MailClient.Credentials = new System.Net.NetworkCredential("chickensoupengineer@gmail.com", "bmbneuuiitkfjanw");

                    //Gmial 的 smtp 必需要使用 SSL
                    MailClient.EnableSsl = true;
                    //MailClient.Send(mail);
                    await MailClient.SendMailAsync(mail);
                    result = "成功";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }


            ViewData["result"] = result;
            return View();

        }
    }
}
