using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CouponAPI : ControllerBase
{
    private readonly AppDbContext _db;
    private ResponseDto responseDto;
    private IMapper _mapper;
    public CouponAPI(AppDbContext db, IMapper mapper)
    {
        _db = db;
        responseDto = new ResponseDto();
        _mapper = mapper;
    }
    [HttpGet("ListCoupon")]
    public async Task<ActionResult<ResponseDto>> ListCoupon()
    {
        try
        {
            IEnumerable<Coupon> list = await _db.Coupons.ToListAsync();
            responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(list);
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }
        return responseDto;
    }
    [HttpGet("GetById")]
    public async Task<ActionResult<ResponseDto>> GetById(int id)
    {
        try
        {
            var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.CouponId == id);

            responseDto.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }
        return responseDto;
    }
    [HttpDelete("Delete")]
    public async Task<ActionResult<ResponseDto>> Delete(int id)
    {
        try
        {
            var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.CouponId == id);
            _db.Coupons.Remove(coupon);
            await _db.SaveChangesAsync();
            responseDto.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }
        return responseDto;
    }
    [HttpGet("GetByCode")]
    public async Task<ActionResult<ResponseDto>> GetByCode(string code)
    {
        try
        {
            var coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.CouponCode.ToLower() == code.ToLower());
            responseDto.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }
        return responseDto;
    }
    [HttpPost("Add")]
    public async Task<ActionResult<ResponseDto>> Add([FromBody] CouponDto couponDto)
    {
        try
        {
            Coupon coupon = _mapper.Map<Coupon>(couponDto);
            _db.Coupons.Add(coupon);
            await _db.SaveChangesAsync();
            responseDto.Result = coupon;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }
        return responseDto;
    }
    [Authorize]
    [HttpPut("Update")]
    public async Task<ActionResult<ResponseDto>> Update([FromBody] CouponDto couponDto)
    {
        try
        {
            Coupon coupon = _mapper.Map<Coupon>(couponDto);
            _db.Coupons.Update(coupon);
            await _db.SaveChangesAsync();
            responseDto.Result = coupon;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }
        return responseDto;
    }
}
