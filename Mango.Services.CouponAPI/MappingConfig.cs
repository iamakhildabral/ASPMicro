using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;

namespace Mango.Services.CouponAPI;
/*
 * We are creating this class because we need frequent conversion of the DTO class to model/entity
 * class and for that we need automapper help.
 */
public class MappingConfig
{
    public static MapperConfiguration RegisterMaps() 
    {
        var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
        return mappingConfig;
    }
}
/*
 * Now register this service in the program.cs
 */
