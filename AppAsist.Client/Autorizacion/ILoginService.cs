using AppAsist.Shared.DTO;

namespace AppAsist.Client.Autorizacion
{
    public interface ILoginService
    {
        Task Login(UserTokenDTO tokenDTO);
        Task Logout();
    }
}