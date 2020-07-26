using System.Linq;

namespace Petbase.DataService.Interfaces
{
    public interface IRepository
    {
        IQueryable<IEntity> GetAll<IEntity>() where IEntity : class;
    }
}
