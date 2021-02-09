using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckManager.Context;
using TruckManager.Domain;

namespace TruckManager.Repository
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckManagerContext db;

        public TruckRepository(TruckManagerContext context) 
        {
            this.db = context;
        }

        public Truck Add(Truck entity)
        {
            db.Trucks.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public Truck Delete(Truck entity)
        {
            db.Trucks.Remove(entity);
            db.SaveChanges();
            return entity;
        }

        public Truck Delete(string chassis)
        {
            Truck t = db.Trucks.FirstOrDefault(x => x.Chassis == chassis);
            db.Trucks.Remove(t);
            db.SaveChanges();
            return t;
        }

        public Truck GetSingle(string chassis)
        {
            return db.Trucks.Include(x=>x.TruckModel).FirstOrDefault(x => x.Chassis == chassis);
        }

        public ICollection<Truck> List()
        {
            return db.Trucks.Include(x=>x.TruckModel).OrderBy(x=>x.TruckModel.ModelCode).ToList();
        }

        public ICollection<TruckModel> ListModels()
        {
            return db.TruckModels.ToList();
        }

        public Truck Update(Truck entity)
        {
            Truck UpdateEntity = db.Trucks.FirstOrDefault(x => x.Chassis == entity.Chassis);
            UpdateEntity.BuildingYear = entity.BuildingYear;
            UpdateEntity.ModelYear = entity.ModelYear;
            UpdateEntity.TruckModelId = entity.TruckModelId;
            db.SaveChanges();
            return UpdateEntity;
        }
    }
}
