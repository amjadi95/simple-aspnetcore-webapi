
using System.Linq;
using ApiServer.Models;

namespace ApiServer.Data
{
    public interface IGenericRepo<Entity> where Entity : DomainEntity
    {
        bool SaveChanges();

        Entity GetItemById(int id);
        IQueryable<Entity> GetAll();
        void Add(Entity person);
        void Delete(Entity entity);

        void Update(Entity newEntity);
       
    }
}