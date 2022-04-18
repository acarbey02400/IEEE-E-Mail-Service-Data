using Core.Utilities.EmailService.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class EMailManager
    {
        IEmailService _emailService;
        public EMailManager(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IResult SendMail(MimeMessage template)
        {
           // string message = $"To: {template.to}\r\nSubject: {template.subject}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n{template.body}";
           var service= _emailService.sendMail(template);
            if (service.Success)
            {
                return new SuccessResult("Mail gönderildi");
            }
            return new ErrorResult("Hata!");
        }
    }
}
