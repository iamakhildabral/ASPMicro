namespace Mango.Services.CouponAPI.Models.DTO
{
    /*
     * We are using automapper for converting Coupon to CouponDto
     */
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
