using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Configuration;

namespace SampleCqrs.Api.Security.Jwt
{
    /// <summary>
    /// Gerenciamento do token do Jwt
    /// </summary>
    public class TokenManager
    {
        private static readonly string secretToken = WebConfigurationManager.AppSettings["SecretToken"].ToString();

        /// <summary>
        /// Gera o token de acesso
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string GenerateToken(string userName)
        {
            byte[] key = Convert.FromBase64String(secretToken);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = securityTokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return securityTokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">Token de acesso</param>
        /// <returns></returns>
        public static ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)securityTokenHandler.ReadToken(token);

                if (jwtSecurityToken == null)
                    return null;

                byte[] key = Convert.FromBase64String(secretToken);
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;
                ClaimsPrincipal claimsPrincipal = securityTokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return claimsPrincipal;
            }
            catch 
            {
                return null;
            }
        }

        /// <summary>
        /// Valida o token
        /// </summary>
        /// <param name="token">Token a ser validado</param>
        /// <returns></returns>
        public static string ValidateToken(string token)
        {
            var userName = "";
            ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(token);

            if (claimsPrincipal == null)
                return null;

            ClaimsIdentity claimsIdentity = null;

            try
            {
                claimsIdentity = (ClaimsIdentity)claimsPrincipal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            userName = claim.Value;

            return userName;
        }
    }
}