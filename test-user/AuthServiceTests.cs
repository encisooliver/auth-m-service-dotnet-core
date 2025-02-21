using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using auth_project.Models;
using auth_project.Services;
using Moq;
using Microsoft.Extensions.Configuration;

namespace test_user;

public class AuthServiceTests
{
    private readonly AuthService _authService;
    private readonly Mock<IConfiguration> _mockConfiguration;
    
    public AuthServiceTests()
    {
        _mockConfiguration = new Mock<IConfiguration>();

        var mockJwtSection = new Mock<IConfigurationSection>();
        mockJwtSection.Setup(x => x.GetValue<string>("Key")).Returns("supersecretkey123456789");
        mockJwtSection.Setup(x => x.GetValue<string>("Issuer")).Returns("TestIssuer");
        mockJwtSection.Setup(x => x.GetValue<string>("Audience")).Returns("TestAudience");

        _mockConfiguration.Setup(x => x.GetSection("JwtConfig")).Returns(mockJwtSection.Object);
        
        _authService = new AuthService(_mockConfiguration.Object);
    }
    
        [Fact]
    public void GenerateJwtToken_ShouldReturn_ValidToken()
    {
        var user = new UserModel
        {
            UserName = "testuser",
            Email = "testuser@example.com"
        };

        var token = _authService.GenerateJwtToken(user);

        Assert.False(string.IsNullOrEmpty(token));

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        Assert.Equal("TestIssuer", jwtToken.Issuer);
        Assert.Equal("TestAudience", jwtToken.Audiences.First());
        Assert.Contains(jwtToken.Claims, c => c.Type == ClaimTypes.Name && c.Value == "testuser");
        Assert.Contains(jwtToken.Claims, c => c.Type == ClaimTypes.Email && c.Value == "testuser@example.com");
    }
}