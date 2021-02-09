using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Context;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using TruckManager.Repository;
using TruckManager.Test.Startup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckManager.Web.Controllers;
using TruckManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TruckManager.Test.ControllersTests
{
    [TestClass()]
    public class TruckControllerTest
    {
        private TruckRepository repo;
        public static DbContextOptions<TruckManagerContext> dbContextOptions { get; }
        public static string connectionString = "server=(localdb)\\MSSQLLocalDB;database=TruckManagerDb;Trusted_Connection=true";

        static TruckControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckManagerContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public TruckControllerTest()
        {
            var context = new TruckManagerContext(dbContextOptions);
            DatabaseInit db = new DatabaseInit();
            db.Seed(context);

            repo = new TruckRepository(context);
        }

        [TestMethod()]
        public void GetTruckList_Ok_Result()
        {
            var controller = new TruckController(repo);
            var data = controller.Index();
            ViewResult result = data as ViewResult;
            Assert.IsInstanceOfType(result.Model, typeof(List<TruckViewModel>));
        }

        [TestMethod()]
        public void DeleteTruck_Fail()
        {
            var controller = new TruckController(repo);
            var truck = new TruckViewModel
            {
                Chassis = "ASDFASDFASDFASDFA",
                BuildingYear = 2020,
                ModelYear = 2021
            };

            var data = controller.Delete(truck);
            ViewResult result = data as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod()]
        public void DeleteTruck_Ok()
        {
            var controller = new TruckController(repo);
            
            var truck = repo.List().FirstOrDefault();
            TruckViewModel tvm = new TruckViewModel
            {
                Chassis = truck.Chassis,
                ModelYear = truck.ModelYear,
                BuildingYear = truck.BuildingYear
            };

            var data = controller.Delete(tvm);
            RedirectToActionResult result = data as RedirectToActionResult;
            Assert.AreEqual("Index", result.ActionName);

            Assert.IsNull(repo.GetSingle(truck.Chassis));
        }

    }
}
