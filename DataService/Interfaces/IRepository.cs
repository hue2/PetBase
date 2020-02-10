using System.Linq;

namespace DataService.Interfaces
{
    public interface IRepository
    {
        IQueryable<IEntity> GetAll<IEntity>() where IEntity : class;
    }
}
