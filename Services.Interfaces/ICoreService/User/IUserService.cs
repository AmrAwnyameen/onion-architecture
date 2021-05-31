using Core.Domain.Models.AppModels.Items;
using System.Collections.Generic;

namespace Services.InterFaces.ICoreService.User
{
    public interface IUserService : IAppService<Card> 
    {
        IEnumerable<Card> Cards();
    }
}
