using API.Contexts;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Context : MyContexts
        where Entity : class
    {
        private readonly MyContexts myContexts;
        private readonly DbSet<Entity> entities;
      
        public GeneralRepository(MyContexts myContexts)
        {
            this.myContexts = myContexts;
            entities = myContexts.Set<Entity>();
        }
        public int Delete(Key key)
        {
            var cari = entities.Find(key);
            //entities.Remove(cari);
            myContexts.Entry(cari).State = EntityState.Deleted;
            var save = myContexts.SaveChanges();
            return save;
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            var findAll = entities.Find(key); //universitiesid tipenya int, sedangkan yg di general repo itu tipenya string
            return findAll;
        }

        public Entity GetById(Key key)
        {
            var findId = entities.Find(key);
            return findId;
        }

        public int Insert(Entity e)
        {
            myContexts.Entry(e).State = EntityState.Added;
            var post = myContexts.SaveChanges();
            return post;
        }


        public int Update(Entity e, Key key)
        {
            try
            {
                //var findRecord = GetById(key);
                entities.Attach(e);
                var newEntry = myContexts.Entry(e);

                newEntry.State = EntityState.Modified;
                var update = myContexts.SaveChanges();
                return update;
            }
            catch (Exception)
            {
                return 0;
            }
            

        }

       
    }
}
