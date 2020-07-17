using Microsoft.EntityFrameworkCore;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Linq;

namespace Petbase.DataService.Repository
{
    public class PetbaseRepository : IRepository
    {
        private readonly PetbaseContext context;

        public PetbaseRepository(PetbaseContext context)
        {
            this.context = context;
        }

        public IQueryable<IEntity> GetAll<IEntity>() where IEntity : class
        {
            return context.Set<IEntity>().AsNoTracking();
        }
    }
}
