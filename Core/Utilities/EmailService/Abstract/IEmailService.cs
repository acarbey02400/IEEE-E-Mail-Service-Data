using Auth0.ManagementApi.Models;
using Core.Utilities.Results;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.EmailService.Abstract
{
    public interface IEmailService
    {
        public IResult sendMail(MimeMessage mimeMessage);
    }
}
