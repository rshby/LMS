using LMS.Context;
using LMS.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;

        //Constructor
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }

        public int Delete(Key key)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Entity> GET()
        {
            throw new System.NotImplementedException();
        }

        public Entity Get(Key key)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(Entity entity)
        {
            throw new System.NotImplementedException();
        }

        public int Update(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
