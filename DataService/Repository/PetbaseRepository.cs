using DataService.Interfaces;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataService.Repository
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
            return this.context.Set<IEntity>().AsNoTracking();
        }
    }
}
