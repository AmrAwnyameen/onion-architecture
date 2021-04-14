using Services.Interfaces.IBaseServices;

namespace Services.InterFaces.ICoreService
{
    public interface IAppService<TEntity>: IBaseService<TEntity> where TEntity : class
    {

    }
}
