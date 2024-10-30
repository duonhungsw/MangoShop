using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Unility;

namespace Mango.Web.Service
{
    public class AccountServices(IBaseService baseService) : IAccountService
    {
        public Task<ResponseDto?> CreateCouponsAsync(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> Login(LoginDto loginDto, HttpContext httpContext)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginDto,
                Url = SD.AccountAPIBase + "api/Account/Login"
            });
        }

        public Task<ResponseDto?> UpdateCouponsAsync(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }
    }
}
