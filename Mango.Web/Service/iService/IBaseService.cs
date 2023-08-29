using Mango.Web.Models;

namespace Mango.Web.Service.iService;

public interface IBaseService
{
    Task<ResponseDTO?> SendAsync(RequestDto requestDto);

}
