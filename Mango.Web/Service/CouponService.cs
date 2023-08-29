using Mango.Web.Models;
using Mango.Web.Service.iService;
using Mango.Web.Utility;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {   
        /*
         * Adding Base Service dependency because it handle all the Http Request
         */
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService) { 
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = couponDto,
                URL = StaticDetails.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                URL = StaticDetails.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/GetByCode/"+couponCode
            });
        }


        public async Task<ResponseDTO?> GetCouponByIdAsync(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/" + couponId
            });
        }

        public async Task<ResponseDTO?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = couponDto,
                URL = StaticDetails.CouponAPIBase + "/api/coupon"
            });
        }
    }
}
