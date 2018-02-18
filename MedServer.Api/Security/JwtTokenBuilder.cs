using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedServer.Api.Security
{
    public class JwtTokenBuilder
    {
        private SecurityKey securityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        private string nameId = "";
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expiryInMinutes = 2880; 

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        public JwtTokenBuilder AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public JwtTokenBuilder AddIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public JwtTokenBuilder AddAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        public JwtTokenBuilder AddNameId(string nameId)
        {
            this.nameId = nameId;
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        {
            foreach (KeyValuePair<string, string> item in claims)
            {
                this.claims.Add(item.Key.ToString().ToLower(), item.Value.ToString().ToLower());
            }
            return this;
        }

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            this.expiryInMinutes = expiryInMinutes;
            return this;
        }

        public string Build()
        {
            var claimsList = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Sub, this.subject),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (KeyValuePair<string, string> item in claims)
            {
                claimsList.Add(new Claim(item.Key.ToString().ToLower(), item.Value.ToString().ToLower()));
            }

            var token = new JwtSecurityToken(
                                      issuer: this.issuer,
                                      audience: this.audience,
                                      claims: claimsList,
                                      expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                                      signingCredentials: new SigningCredentials(
                                                                this.securityKey,
                                                                SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
