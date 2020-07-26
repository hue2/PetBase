using Microsoft.EntityFrameworkCore;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Collections.Generic;
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

        public IQueryable<string> GetNames()
        {
            var names = context.Cats.Select(x => x.Name)
                    .Union(context.Dogs.Select(x => x.Name))
                    .Union(context.Rabbits.Select(x => x.Name));
            return names;
        }
    }
}
