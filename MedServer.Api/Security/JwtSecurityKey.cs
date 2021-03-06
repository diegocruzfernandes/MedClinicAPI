﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MedServer.Api.Security
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret) =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}
