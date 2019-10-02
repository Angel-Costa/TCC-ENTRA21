using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ViewCliente.Controllers
{
    public class ContatoController : Controller
    {
        private ContatoRepository repository;

        public ContatoController()
        {
            repository = new ContatoRepository();
        }

        public ActionResult Indicacao()
        {
            return View();
        }

        [HttpPost, Route("contato")]
        public ActionResult Cadastro(Contato contato)
        {
            var id = repository.Inserir(contato);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("gerenciamentolux@gmail.com");
            mail.To.Add("gerenciamentolux@gmail.com"); // para
            mail.IsBodyHtml = true;
            mail.Subject = "Feedback"; // assunto
            mail.Body = ""; // mensagem

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {

                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // Modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas
                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential("gerenciamentolux@gmail.com", "sislux123");
                smtp.EnableSsl = true;

                // envia o e-mail
                smtp.Send(mail);
            }
            return RedirectToAction("Indicacao", new { id });
        }
    }
}