using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.Shared
{
    public static class ValidationPassword
    {
        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            var pass = (password += "|BDB80E1F-1FEC-43B8-A99A-C5AF887B2951");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.ASCII.GetBytes(pass));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
