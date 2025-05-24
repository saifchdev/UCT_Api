using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Replace with real validation logic
        if (request.Email == "admin@test.com" && request.Password == "admin")
        {
            var token = GenerateJwtToken(request.Email);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e3d8eebd593a083f54b75368d5659a9a65293ca60bdbc199523c630d341a6bbfb50937235b76043221f6e4f6207145faea4a2d096b4478368cde853de98db93167d70e50291d0bc65f1b965f24e7d08e87c3677b3a4d529a8bff3e5470202d0b72f1cd808990cc3bbf3825b884622a99e6ff12436f34816c97f9fd0ea11dd462ed54b50bf41b2967a4efc1cf13fa79a41ad88499754001415195f0185ef6e465c598d1c3d063aad54335a6698388c68729c663ef3520a2fd92dc6202534ecd55fc51774d289b593420072ed2f326f551be663c70529e30be397f43f5df8a709aee9ec9b4bb38dc788e680acd1028a1f5e856ed7caca4314c4961fd0a759c8bf9"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(ClaimTypes.Name, email),
        };

        var token = new JwtSecurityToken(
            issuer: "yourApp",
            audience: "yourApp",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
