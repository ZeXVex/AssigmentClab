using System.Collections.Generic;
using LampApp.Core.Entity;

namespace LampApp.Core.DomainService
{
    public interface ILampRepository
    {
        //Create Data
        //No Id when enter, but Id when exits
        Lamp Create(Lamp lamp);
        //Read Data
        Lamp ReadById(int id);
        IEnumerable<Lamp> ReadAll();
        //Update Data
        Lamp Update(Lamp lampUpdate);
        //Delete Data
        Lamp Delete(int id);
    }
}