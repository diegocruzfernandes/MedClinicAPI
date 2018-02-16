using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServer.Api.Security
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret) =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}
