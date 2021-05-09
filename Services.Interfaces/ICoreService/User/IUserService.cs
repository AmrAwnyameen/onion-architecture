using App.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.User
{
   public interface IUserService : IAppService<Card> 
    {
        IEnumerable<Card> Cards();
    }
}
