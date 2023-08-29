using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _responseDTO = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> couponList = _db.Coupons.ToList();
                _responseDTO.Result = _mapper.Map<IEnumerable<CouponDto>>(couponList);
            }
            catch (Exception ex)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        [HttpGet("/{id}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First((x => x.CouponId == id));
                _responseDTO.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responseDTO.Success=false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("GetByCode{code}")]
        public ResponseDTO GetByCode(string code) 
        {
            try
            {
                /*
                 * We are ony using First because it will throw error if not matched
                 * while FirstandDefault will simply make the coupon as null which wont throw any error 
                 * to set the success message
                 */
                var coupon = _db.Coupons.First(x => x.CouponCode == code);
                _responseDTO.Result = _mapper.Map<CouponDto>(coupon);            }
            catch (Exception ex)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        [HttpPost]
        public ResponseDTO Post([FromBody]CouponDto coupon)
        {
            try
            {
                var userCoupon = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Add(userCoupon);
                _db.SaveChanges();
                _responseDTO.Result = coupon;
            }
            catch (Exception ex)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        [HttpPut]
        public ResponseDTO Put([FromBody]CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(coupon);
                _db.SaveChanges();
                _responseDTO.Result = couponDto;
            }
            catch (Exception ex)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

        [HttpDelete]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(u=> u.CouponId == id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

    }
}
