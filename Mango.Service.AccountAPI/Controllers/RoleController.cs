using Book.Core.Interfaces;
using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.AccountAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(IRoleService roleService, IUnitOfWork unitOfWork, AccountDbContext accountDbContext) : ControllerBase
{
    [HttpGet("ListRole")]
    public async Task<ActionResult<IEnumerable<Role>>> GetAll()
    {
        var list = await roleService.GetAllAsync();
        return Ok(list);
    }
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Role>>> Add(Role role)
    {
        roleService.Create(role);
        if (await unitOfWork.Complete())
        {
            return Ok(role);
        }
        else
        {
            return BadRequest("Create unsuccessfully");
        }
    }
}
