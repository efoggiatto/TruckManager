using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Context;
using TruckManager.Domain;

namespace TruckManager.Test.Startup
{
    public class DatabaseInit
    {

        public void Seed(TruckManagerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.TruckModels.AddRange(
                new TruckModel() { ModelCode = "FH-100" },
                new TruckModel() { ModelCode = "FH-120" },
                new TruckModel() { ModelCode = "FH-130" },
                new TruckModel() { ModelCode = "FH-140" },
                new TruckModel() { ModelCode = "FH-150" },
                new TruckModel() { ModelCode = "FM-120" },
                new TruckModel() { ModelCode = "FM-130" },
                new TruckModel() { ModelCode = "FM-140" },
                new TruckModel() { ModelCode = "FM-150" }
                );

            context.Trucks.AddRange(
                new Truck() { Chassis = "ASDFGPOIUQER00001", TruckModelId = 1, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00002", TruckModelId = 1, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00003", TruckModelId = 2, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00004", TruckModelId = 5, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00005", TruckModelId = 5, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00006", TruckModelId = 5, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00007", TruckModelId = 9, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00008", TruckModelId = 9, BuildingYear = 2021, ModelYear = 2021 },
                new Truck() { Chassis = "ASDFGPOIUQER00009", TruckModelId = 9, BuildingYear = 2021, ModelYear = 2021 }
                );
            context.SaveChanges();
        }
    }
}
