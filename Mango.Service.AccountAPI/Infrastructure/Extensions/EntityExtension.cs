using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Models.Dto;

namespace Mango.Service.AccountAPI.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static void UpdateAppUser(this User appUser, UserViewModel appUserVM)
        {
            appUser.FirstName = appUserVM.FirstName;
            appUser.LastName = appUserVM.LastName;
            appUser.UserName = appUserVM.UserName;
            appUser.PhoneNumber = appUserVM.PhoneNumber;
            appUser.Email = appUserVM.Email;
            appUser.Password = appUserVM.Password;
            appUser.PictureUrl = appUserVM.PictureUrl;
            appUser.IsDeleted = appUserVM.IsDeleted;
        }
    }
}
