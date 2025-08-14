using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.DTO;
using RealEstate.Core.Entities;
using RealEstate.Services;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtService;

    public AuthController(UserManager<ApplicationUser> userManager,
        IConfiguration config,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenService jwtService)
    {
        _userManager = userManager;
        _config = config;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }
        DateTime expiryAccess = DateTime.UtcNow.AddMinutes(Convert.ToInt32(this._config["AccessTokenExpiryMin"]));
        DateTime expiryRefresh = DateTime.UtcNow.AddMinutes(Convert.ToInt32(this._config["RefreshTokenExpiryMin"]));
        var accessToken  = _jwtService.GenerateAccessToken(user, expiryAccess);
        var refreshToken = await _jwtService.GenerateRefreshTokenAsync(user, expiryRefresh);

        Response.Cookies.Append("accessToken", accessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = expiryAccess,
        });

        Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = expiryRefresh
        });

        return Ok(new {email = user.Email, message = "Login successful", accessTokenExpiry = expiryAccess });
    }

    [Authorize]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (await _jwtService.ValidateRefreshTokenAsync(userId, refreshToken))
        {
            DateTime expiryAccess = DateTime.UtcNow.AddMinutes(Convert.ToInt32(this._config["AccessTokenExpiryMin"]));
            var user = await _userManager.FindByEmailAsync(email);
            var accessToken = _jwtService.GenerateAccessToken(user, expiryAccess);

            Response.Cookies.Append("accessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = expiryAccess
            });

            return Ok(new { accessTokenExpiry = expiryAccess, message = "success" });
        }
        else
        {
            return Unauthorized();
        }
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _jwtService.LogoutSessionAsync(userId, refreshToken);
        Response.Cookies.Delete("accessToken");
        Response.Cookies.Delete("refreshToken");
        
        return Ok(new { message = "Logged out successfully" });
    }
}
