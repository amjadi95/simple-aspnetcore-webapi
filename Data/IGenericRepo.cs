
using System.Linq;
using ApiServer.Models;

namespace ApiServer.Data
{
    public interface IGenericRepo<Entity> where Entity : DomainEntity
    {
        bool SaveChanges();

        Entity GetItemById(int id);
        IQueryable<Entity> GetAll();
        Entity Add(Entity person);
        void Delete(Entity entity);

        Entity Update(Entity newEntity);
       
    }
}