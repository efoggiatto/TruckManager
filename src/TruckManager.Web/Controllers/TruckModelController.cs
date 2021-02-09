using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManager.Domain;
using TruckManager.Repository;
using TruckManager.ViewModels;

namespace TruckManager.Web.Controllers
{
    public class TruckModelController : Controller
    {
        private readonly ITruckModelRepository db;

        public TruckModelController(ITruckModelRepository truckModelRepository)
        {
            this.db = truckModelRepository;
        }

        public IActionResult Index()
        {
            List<TruckModel> tmList = db.List().ToList();
            List<TruckModelViewModel> list = new List<TruckModelViewModel>();
            foreach(TruckModel tm in tmList)
            {
                list.Add(new TruckModelViewModel
                {
                    Text = tm.ModelCode,
                    Value = tm.Id.ToString()
                });
            }
            return View(list);
        }

        public ICollection<TruckModel> ListModels()
        {
            return db.List();
        }
        [HttpGet, Route("TruckModel/Create")]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("TruckModel/Create")]
        public IActionResult Create(TruckModelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TruckModel tm = new TruckModel
            {
                ModelCode = model.Text
            };

            db.Add(tm);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("TruckModel/Details/{id}")]
        public IActionResult Details(int id)
        {
            TruckModel tm = db.GetSingle(id);
            TruckModelViewModel tmvm = new TruckModelViewModel
            {
                Value = tm.Id.ToString(),
                Text = tm.ModelCode
            };
            return View(tmvm);
        }

        [HttpGet, Route("TruckModel/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            TruckModel tm = db.GetSingle(id);
            TruckModelViewModel tmvm = new TruckModelViewModel
            {
                Value = tm.Id.ToString(),
                Text = tm.ModelCode
            };
            return View(tmvm);
        }


        [HttpPost, Route("TruckModel/Editar")]
        public IActionResult Editar(TruckModelViewModel truck)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TruckModel tm = new TruckModel
            {
                Id = Convert.ToInt32(truck.Value),
                ModelCode = truck.Text
            };
            db.Update(tm);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("TruckModel/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            TruckModel tm = db.GetSingle(id);
            TruckModelViewModel tmvm = new TruckModelViewModel
            {
                Value = tm.Id.ToString(),
                Text = tm.ModelCode
            };
            return View(tmvm);
        }

        [HttpPost, Route("TruckModel/DeletePost/{id}")]
        public IActionResult DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TruckModel tm = db.GetSingle(id);
            
            if (tm.Trucks.Count > 0)
            {
                ModelState.AddModelError("Text", "Este modelo está sendo utilizado, remova primeiro os caminhões que o utilizam");
                //return View("Delete", new TruckModelViewModel { Value = tm.Id.ToString(), Text = tm.ModelCode });
                return View("Delete", new TruckModelViewModel { Value = tm.Id.ToString(), Text = tm.ModelCode });
            }

            
            db.Delete(tm);
            return RedirectToAction("Index");
        }
    }
}
