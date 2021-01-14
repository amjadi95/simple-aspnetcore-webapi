using System.Linq;
using System.Collections.Generic;
using ApiServer.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Data
{
    public class SqlGenericRepo<Entity> : IGenericRepo<Entity> where Entity : DomainEntity
    {
        private readonly AppDbContext _context;
        public SqlGenericRepo(AppDbContext context)
        {
                _context = context;
        }

        public void Add(Entity entity)
        {
            if(entity != null)
            {
                _context.Set<Entity>().Add(entity);
            }            
        }
        public void Delete(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<Entity>().Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Entity GetItemById(int id)
        {
            var dbset = _context.Set<Entity>();
            var entity =dbset.FirstOrDefault(entity => entity.id == id);
            return entity;
        }

        public IQueryable<Entity> GetAll()
        {
            try
            {
                var list = _context.Set<Entity>().AsQueryable();
                return list;
            }
            catch (System.Exception e)
            {
               System.Console.WriteLine(e.Message);
               return null;
            }
        }

        public void Update( Entity newEntity)
        {
            _context.Entry(newEntity).State = EntityState.Modified;            
        }
    }
}