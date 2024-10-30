using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponsAsync(AccountDto accountDto);
        Task<ResponseDto?> UpdateCouponsAsync(AccountDto accountDto);
        Task<ResponseDto?> DeleteCouponsAsync(int id);
        Task<ResponseDto?> Login(LoginDto loginDto, HttpContext httpContext);

    }
}
