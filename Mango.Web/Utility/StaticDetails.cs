namespace Mango.Web.Utility;

public class StaticDetails
{
    /*
     * For storing base url for the coupon api which we can use while
     * registering the dependency in the program file
     */
    public static string CouponAPIBase { get; set; }
    public enum ApiType
    {
        GET,
        POST, 
        PUT, 
        DELETE

    }
}
