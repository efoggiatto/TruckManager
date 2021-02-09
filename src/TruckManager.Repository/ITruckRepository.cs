using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Domain;

namespace TruckManager.Repository
{
    public interface ITruckRepository 
    {
        ICollection<TruckModel> ListModels();
        Truck GetSingle(string chassis);
        ICollection<Truck> List();
        Truck Add(Truck entity);
        Truck Update(Truck entity);
        Truck Delete(Truck entity);
        Truck Delete(string chassis);
    }
}
