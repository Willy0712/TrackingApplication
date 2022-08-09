using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TimeTrackingApi.Models;
using TimeTrackingApi.Utils;

namespace TimeTrackingApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokenController : ControllerBase
  {
    public IConfiguration _configuration;
    private readonly trackingcontext _context;
    private readonly PasswordHasher<User> passwordHasher;

    public TokenController(IConfiguration config, trackingcontext context)
    {
      _configuration = config;
      _context = context;
      this.passwordHasher = new PasswordHasher<User>();

    }


    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
      if (user == null)
      {
        return BadRequest();
      }

      if (await _context.Users.AnyAsync(u => u.UserName == user.UserName || u.Email == user.Email))
      {
        return BadRequest("Username or email already exists");
      }

      if (user.Password.Length < 6)
      {
        return BadRequest("Password must be at least 6 characters long");
      }

      user.CreatedDate = DateTime.Now;
      user.Password = PasswordUtils.ComputeSha256Hash(user.Password);
      _context.Users.Add(user);
      await _context.SaveChangesAsync();


      // var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
      // var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
      // EmailHelper emailHelper = new EmailHelper();
      // bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

      // var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

      return Ok();
    }

    [HttpPost]
    [Route("register/confrimEmail")]
    public async Task<ActionResult<User>> ConfirmEmail(string email)
    {

      // var claims = (User.Identity as ClaimsIdentity).Claims;
      // var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      if (email == null)
      {
        return BadRequest();
      }
      else
      {
        var query = _context.Users.FirstOrDefault(item => item.Email == email);
        query.IsConfirmed = 1;
        await _context.SaveChangesAsync();

      }
      return Ok();

      // var query2 = _context.Users.Update(user => user.isEmailConfirmed = 1);

      // if (email != null)
      // {
      //   query = query.Where(item => item.Email == email item.isEmailConfirmed = 1);
      //   await query.;
      //   return Ok();

      // }
      // else
      // {
      //   return BadRequest();
      // }





      // var result = await _context.ConfirmEmailAsync(user, token);
      // return View(result.Succeeded ? "ConfirmEmail" : "Error");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> AuthenticateUser([FromBody] User _userData)
    {
      if (_userData != null && _userData.Email != null && _userData.Password != null)
      {
        var user = await GetUser(_userData.Email, PasswordUtils.ComputeSha256Hash(_userData.Password));

        if (user != null)
        {
          //create claims details based on the user information
          var claims = new[] {
                          new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                          new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                          new Claim("UserId", user.id.ToString()),
                          new Claim("Username", user.UserName),
                          new Claim("Email", user.Email)
                      };

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
          var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
          var token = new JwtSecurityToken(
              _configuration["Jwt:Issuer"],
              _configuration["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: signIn);

          return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        else
        {
          return BadRequest("Invalid credentials");
        }
      }
      else
      {
        return BadRequest();
      }
    }

    private async Task<User> GetUser(string email, string password)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
  }
}


