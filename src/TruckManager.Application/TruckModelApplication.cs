using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Repository;

namespace TruckManager.Application
{
    public class TruckModelApplication
    {
        private readonly ITruckModelRepository db;

        public TruckModelApplication(ITruckModelRepository truckModelRepository)
        {
            this.db = truckModelRepository;
        }
    }
}
