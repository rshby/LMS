﻿using System.Collections.Generic;

namespace LMS.Repository.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> GET();

        Entity Get(Key key);

        int Insert(Entity entity);

        int Update(Entity entity);

        int Delete(Key key);
    }
}
