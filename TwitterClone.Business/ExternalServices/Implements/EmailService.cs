using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.ExternalServices.Interfaces;

namespace TwitterClone.Business.ExternalServices.Implements
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
