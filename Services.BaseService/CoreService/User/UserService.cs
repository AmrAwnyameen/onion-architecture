using Core.Domain.Models.AppModels.Items;
using Services.InterFaces.ICoreService.User;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.Interfaces.IUnitOfWork;

namespace Services.BaseService.CoreService.User
{
    public class UserService : Services.BaseService.BaseService<Card>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Card> Cards()
        {
            return _unitOfWork.Repository<Card>().GetAll().ToList();
        }
    }
}
