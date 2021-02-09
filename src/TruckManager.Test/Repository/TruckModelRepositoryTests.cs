using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Context;
using Microsoft.EntityFrameworkCore;
using TruckManager.Test.Startup;
using TruckManager.Domain;

namespace TruckManager.Repository.Tests
{
    [TestClass()]
    public class TruckModelRepositoryTests
    {
        private TruckModelRepository repo;
        public static DbContextOptions<TruckManagerContext> dbContextOptions { get; }
        public static string connectionString = "server=(localdb)\\MSSQLLocalDB;database=TruckManagerDb;Trusted_Connection=true";

        static TruckModelRepositoryTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckManagerContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public TruckModelRepositoryTests()
        {
            var context = new TruckManagerContext(dbContextOptions);
            DatabaseInit db = new DatabaseInit();
            db.Seed(context);

            repo = new TruckModelRepository(context);
        }

        [TestMethod()]
        public void TruckModel_Insert_Ok()
        {
            var tm = repo.Add(new TruckModel
            {
                ModelCode = "FH-999"
            });
            Assert.IsNotNull(tm);
            Assert.IsInstanceOfType(tm, typeof(TruckModel));
        }
        [TestMethod()]
        public void TruckModel_Insert_Fail()
        {
            Assert.ThrowsException<DbUpdateException>(() =>
                repo.Add(new TruckModel
                {
                    ModelCode = "FH-999",
                    Id = 999
                })
            );
        }

        [TestMethod()]
        public void TruckModel_GetById()
        {
            var tm = repo.GetSingle(5);
            Assert.IsNotNull(tm);
            Assert.IsInstanceOfType(tm, typeof(TruckModel));
        }

        [TestMethod()]
        public void TruckModel_GetList()
        {
            var tms = repo.List();
            Assert.IsNotNull(tms);
            Assert.IsInstanceOfType(tms, typeof(IEnumerable<TruckModel>));
        }


        [TestMethod()]
        public void TruckModel_Update_Ok()
        {
            var tm = repo.GetSingle(5);
            tm.ModelCode = "FH-AS01";
            var result = repo.Update(tm);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TruckModel));
        }


        [TestMethod()]
        public void TruckModel_Update_Fail()
        {
            var tm = repo.GetSingle(5);
            tm.ModelCode = "FH-AS01";
            tm.Id = 99;
            Assert.ThrowsException<NullReferenceException>(() =>
                repo.Update(tm)
            );
        }


        [TestMethod()]
        public void TruckModel_Delete_Ok()
        {
            var tm = repo.Delete(3);
            Assert.IsNotNull(tm);
            Assert.IsInstanceOfType(tm, typeof(TruckModel));
        }


        [TestMethod()]
        public void TruckModel_Delete_Fail()
        {
            var tm = repo.GetSingle(99);
            Assert.IsNull(tm);
            Assert.ThrowsException<ArgumentNullException>(() =>
                repo.Delete(tm)
            );
        }
    }
}