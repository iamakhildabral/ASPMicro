/*
 * Setting this class to make a common response for all
 * The called APIs.
 * Since Resulting Objecgt, Message and SuccessCode need to be passed
 * we have created this class with those parameters
 */

namespace Mango.Services.CouponAPI.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = true;
        public String Message { get; set; } = String.Empty;

    }
}
