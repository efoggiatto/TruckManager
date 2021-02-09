using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckManager.Context;
using TruckManager.Domain;

namespace TruckManager.Repository
{
    public class TruckModelRepository: ITruckModelRepository
    {
        private readonly TruckManagerContext db;

        public TruckModelRepository(TruckManagerContext context) 
        {
            this.db = context;
        }

        public TruckModel Add(TruckModel entity)
        {
            db.TruckModels.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public TruckModel Delete(TruckModel entity)
        {
            db.TruckModels.Remove(entity);
            db.SaveChanges();
            return entity;
        }

        public TruckModel Delete(int id)
        {
            TruckModel tm = db.TruckModels.FirstOrDefault(x => x.Id == id);
            db.TruckModels.Remove(tm);
            db.SaveChanges();
            return tm;
        }

        public TruckModel GetSingle(int id)
        {
            return db.TruckModels.Include(x=>x.Trucks).FirstOrDefault(x => x.Id== id);
        }

        public ICollection<TruckModel> List()
        {
            return db.TruckModels.OrderBy(x=>x.ModelCode).ToList();
        }

        public TruckModel Update(TruckModel entity)
        {
            TruckModel UpdateEntity = db.TruckModels.FirstOrDefault(x => x.Id == entity.Id);            
            UpdateEntity.ModelCode = entity.ModelCode;
            db.SaveChanges();
            return UpdateEntity;
        }
    }
}
