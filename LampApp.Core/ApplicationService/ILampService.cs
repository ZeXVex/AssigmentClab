using System.Collections.Generic;
using LampApp.Core.Entity;

namespace LampApp.Core.ApplicationService
{
    public interface ILampService
    {
        //New Lmap
        Lamp NewLamp(string Name, 
                    string Color,
                    string Company,
                    double Price,
                    int Qty);
        
        //Create //POST
        Lamp CreateLamp(Lamp lamp);
        
        //Read  //GET
        Lamp FindLampById(int id);
        List<Lamp> GetAllLamp();
        //List<Lamp> GetAllByCompany(string company);
        //List<Lamp> GetAllByQty(int Qty);
        
        //Update //PUT
        Lamp UpdateLamp(Lamp lampUpdate);
        
        //Delete //DELETE
        Lamp DeleteLamp(int id);
    }
}