using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Domain;

namespace TruckManager.Repository
{
    public interface ITruckModelRepository
    {
        TruckModel GetSingle(int id);
        ICollection<TruckModel> List();
        TruckModel Add(TruckModel entity);
        TruckModel Update(TruckModel entity);
        TruckModel Delete(TruckModel entity);
        TruckModel Delete(int id);
    }
}
