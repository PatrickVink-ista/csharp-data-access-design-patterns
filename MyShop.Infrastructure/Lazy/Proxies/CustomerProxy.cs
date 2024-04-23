using MyShop.Domain.Models;

namespace MyShop.Infrastructure.Lazy.Proxies;

public class CustomerProxy : Customer
{
    public override byte[] ProfilePicture => base.ProfilePicture ??= ProfilePictureService.GetFor(Name);
}
