using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTime.Utility;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace LogTime.Config
{
    public class JwtManager
    {
        public static string GenerateToken(string UserId, string UserName, string FullName, string Email, int expireMinutes = 60)
        {
            var symmetricKey = Convert.FromBase64String(Constant.Serect);
            var now = DateTime.UtcNow;
            var claims = new Claim[] {
                    new Claim(ClaimTypes.Sid, UserId ?? ""),
                    new Claim(ClaimTypes.Email, Email ?? ""),
                    new Claim(ClaimTypes.Name, FullName ?? ""),
                    new Claim(ClaimTypes.NameIdentifier, UserName ?? "")
                };
            var token = new JwtSecurityToken(
                issuer: "LogTime.NetCore",
                audience: "LogTimeClient",
                claims: claims,
                expires: now.AddMinutes(expireMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
