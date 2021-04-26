using App.Models.Context;
using Core.InterFaces.IAudit;
using Services.InterFaces.ICoreService;
using System;
using System.Threading.Tasks;
using System.Web;
using UnitOfWork.Interfaces.IUnitOfWork;

namespace Services.BaseService.CoreService
{
    public class AppService<TEntity> : BaseService<TEntity>, IAppService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override TEntity Add(TEntity entity)
        {
            UpdateAudit(entity, true);
            return base.Add(entity);
        }

        public override async Task Remove(TEntity entity)
        {
            UpdateAudit(entity, true);
            await base.Remove(entity);
        }

        private void UpdateAudit(TEntity entity ,bool isNew , string userId =null)
        {
            if (entity is IAudit  model)
            {
                if (isNew)
                {
                    model.CreatedBy = GetUserName(HttpContext.Current.User.Identity.Name) ?? "Anonymous";
                    model.CreatedDate = DateTime.Now;
                }
                else
                {
                    model.UpdatedBy = GetUserName(HttpContext.Current.User.Identity.Name) ?? "Anonymous";
                    model.UpdatedDate = DateTime.Now;
                }
            }
        }

        private void DeleteAudit(TEntity entity, bool isNew, string userId = null)
        {
            if (entity is IDeleteEntity model)
            {
                if (isNew)
                {
                    model.DeletedBy = GetUserName(HttpContext.Current.User.Identity.Name) ?? "Anonymous";
                    model.DeletedDate = DateTime.Now;
                    model.IsDeleted = true;
                }
                else
                {
                    model.DeletedBy = GetUserName(HttpContext.Current.User.Identity.Name) ?? "Anonymous";
                    model.DeletedDate = DateTime.Now;
                    model.IsDeleted = true;
                }
            }
        }

        private string GetUserName(string userName)
        {
            return _unitOfWork.Repository<ApplicationUser>().FirstOrDefault(s=> s.UserName.Equals(userName))?.UserName;
        }
    }

    
}
