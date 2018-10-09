using System.Collections.Generic;
using System.Linq;
using LampApp.Core.DomainService;
using LampApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace LampApp.Infrastructure.Data.Repositories
{
    public class LampRepositories : ILampRepository
    {
        readonly LampAppContext _ltx;

        public LampRepositories(LampAppContext ctx)
        {
            _ltx = ctx;
        }
        
        public Lamp Create(Lamp lamp)
        {
            var lam = _ltx.Lamps.Add(lamp).Entity;
            _ltx.SaveChanges();
            return lam;
        }

        public Lamp ReadById(int id)
        {
            return _ltx.Lamps
                .FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Lamp> ReadAll()
        {
            return _ltx.Lamps;
        }

        public Lamp Update(Lamp lampUpdate)
        {
            var newOrderLines = new List<OrderLine>(lampUpdate.OrderLines);
            _ltx.Attach(lampUpdate).State = EntityState.Modified;
            _ltx.OrderLines.RemoveRange(
                _ltx.OrderLines.Where(ol => ol.LampId == lampUpdate.Id));

            foreach (var ol in newOrderLines)
            {
                _ltx.Entry(ol).State = EntityState.Added;
            }
            _ltx.SaveChanges();
            return lampUpdate;
        }

        public Lamp Delete(int id)
        {
            var remove = _ltx.Remove(new Lamp {Id = id}).Entity;
            _ltx.SaveChanges();
            return remove;
        }
    }
}