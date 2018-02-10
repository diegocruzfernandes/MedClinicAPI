using MedServer.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Service
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            //Need implement server Email for Reset Password
        }
    }
}
