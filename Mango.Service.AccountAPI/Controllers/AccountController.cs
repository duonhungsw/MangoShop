using AutoMapper;
using Book.Core.Interfaces;
using Mango.Service.AccountAPI.Helper;
using Mango.Service.AccountAPI.Infrastructure.Extensions;
using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Models.Dto;
using Mango.Service.AccountAPI.Service;
using Mango.Service.AccountAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Service.AccountAPI.Controllers;

public class AccountController(IAccountService accountService, IUnitOfWork unitOfWork,
                        IMapper mapper, SendMailService _sendMailService, IPasswordResetService _passwordResetService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserViewModel appUserView)
    {
        var userModel = mapper.Map<User>(appUserView);

        accountService.Create(userModel);
        if (await unitOfWork.Complete())
        {
            return Ok(userModel);
        }
        else
        {
            return BadRequest("Create unsuccessfully");
        }
    }
    [Authorize]
    [HttpPut("update-profile")]
    public async Task<ActionResult> UpdateProfile(UserViewModel appUserView)
    {
        var accountExist = await accountService.GetByIdAsync(appUserView.Id);
        if (accountExist == null) return BadRequest();
        var userModel = mapper.Map<User>(appUserView);

        userModel.UpdateAppUser(appUserView);
        accountService.Update(userModel);
        if (await unitOfWork.Complete())
        {
            return Ok(accountExist);
        }
        else
        {
            return BadRequest("Create unsuccessfully");
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var token = await accountService.Login(loginDto.Email, loginDto.Password, HttpContext);
            return Ok(new ResponseDto
            {
                IsSuccess = true,
                Message = "Success",
                Result = token
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("listAccount")]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        var list = await accountService.GetAllAsync();
        return Ok(list);
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> forgotPassword([FromBody] string email)
    {
        try
        {
            var token = await _passwordResetService.GeneratePasswordResetToken(email);

            //var generator = new RandomStringGenerator();
            //string randomString = generator.GenerateRandomString(12);

            MailContent mailContent = new MailContent();
            mailContent.To = email;
            mailContent.Subject = "Password Reset Confirmation";
            string link = "https://localhost:7002/Home/ResetPassword";
            string url = "\n"
                + "\n"
                + "<!DOCTYPE html>\n"
                + "<html>\n"
                + "    <head>\n"
                + "        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n"
                + "        <title>JSP Page</title>\n"
                + "\n"
                + "        <style>\n"
                + "            .styled-url {\n"
                + "                display: inline-block;\n"
                + "                padding: 10px 20px;\n"
                + "                background-color: #007bff;\n"
                + "                color: white;\n"
                + "                text-decoration: none;\n"
                + "                border-radius: 5px;\n"
                + "                font-size: 16px;\n"
                + "                font-weight: bold;\n"
                + "                transition: background-color 0.3s ease;\n"
                + "            }\n"
                + "\n"
                + "            .styled-url:hover {\n"
                + "                background-color: #0056b3;\n"
                + "            }\n"
                + "        </style>\n"
                + "    </head>\n"
                + "    <body>\n"
                + "        <p style=\"text-align: center; margin-top: 20px;\">\n"
                + "            <a href=\"" + link + "\" class=\"styled-url\">Confirm Reset Password</a>\n"
                + "        </p>\n"
                + "    </body>\n"
                + "</html>\n"
                + "";
            mailContent.Body = "Click the link below to confirm your password reset:\n" + url;

            _sendMailService.SendMail(mailContent);

            return Ok(new ResponseDto
            {
                IsSuccess = true,
                Message = "Send mail successfully",
                Result = token
            });

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
    {
        try
        {
            var isValidToken = await _passwordResetService.ValidatePasswordResetToken(model.Token, model.Email);
            if (!isValidToken)
            {
                return BadRequest(new { Message = "Invalid or expired token." });
            }

            await _passwordResetService.ResetPassword(model.Email, model.NewPassword);
            if (await unitOfWork.Complete())
            {
                return Ok("Password has been reset successfully.");
            }
            else
            {
                return BadRequest("Update password unsuccessfully");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }

    }

    //[Authorize]
    //[HttpGet("user-info")]
    //public async Task<ActionResult> GetUserInfo()
    //{
    //    if (User.Identity?.IsAuthenticated == false) return NoContent();

    //    var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);

    //    return Ok(new
    //    {
    //        user.FirstName,
    //        user.LastName,
    //        user.Email,
    //        Address = user.Address?.ToDtos(),
    //    });
    //}

    //[HttpGet("auth")]
    //public Task<ActionResult>
}
