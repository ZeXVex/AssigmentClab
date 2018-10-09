using System.Collections.Generic;
using System.Linq;
using LampApp.Core.DomainService;
using LampApp.Core.Entity;

namespace LampApp.Core.ApplicationService.Services
{
    public class LampService : ILampService
    {
        readonly ILampRepository _lampRepo;
        readonly IOrderRepository _orderRepo;

        public LampService(ILampRepository lampRepository,
            IOrderRepository orderRepository)
        {
            _lampRepo = lampRepository;
            _orderRepo = orderRepository;
        }

        public Lamp NewLamp(string Name, string Color, string Company, double Price, int Qty)
        {
            var lamp = new Lamp()
            {
                Name = Name,
                Color = Color,
                Designer = Company,
                Price = Price,
                Qty = Qty
            };
            return lamp;
        }

        public Lamp CreateLamp(Lamp lamp)
        {
            return _lampRepo.Create(lamp);
        }

        public Lamp FindLampById(int id)
        {
            return _lampRepo.ReadById(id);
        }

        public List<Lamp> GetAllLamp()
        {
            return _lampRepo.ReadAll().ToList();
        }

        public Lamp UpdateLamp(Lamp lampUpdate)
        {
            return _lampRepo.Update(lampUpdate);
        }

        public Lamp DeleteLamp(int id)
        {
            return _lampRepo.Delete(id);
        }
    }
}