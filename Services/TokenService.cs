using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Services;

/// <summary>
/// Token Utility Service
/// </summary>
public class TokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly ILogger<TokenService> logger;

    public TokenService(IOptions<JwtSettings> jwtSettings, ILogger<TokenService> logger)
    {
        _jwtSettings = jwtSettings.Value;
        this.logger = logger;
    }

    /// <summary>
    /// Generate Access token
    /// </summary>
    /// <returns>returns string representing access token</returns>
    public string GenerateAccessToken(string? username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username ?? "user"),
            new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Generate refresh token
    /// </summary>
    /// <returns>returns refresh token</returns>
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        System.Security.Cryptography.RandomNumberGenerator.Fill(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    /// <summary>
    /// Validate Access Token (optional)
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = securityKey,
            ValidateLifetime = false // We want to validate expired tokens as well
        };

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
        return principal;
    }

   
    /// <summary>
    /// get token expiration time
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public DateTime GetTokenExpiration(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        return jwtToken.ValidTo.ToLocalTime();
    }

}
/// <summary>
/// JwT Object
/// </summary>
public class JwtSettings
{
    public string SecretKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}