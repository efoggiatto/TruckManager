using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckManager.Domain;
using TruckManager.Repository;
using TruckManager.ViewModels;

namespace TruckManager.Web.Controllers
{
    public class TruckController : Controller
    {
        private readonly ITruckRepository truckRepository;

        public TruckController(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;
        }
        [Route("Truck")]
        public IActionResult Index()
        {
            List<TruckViewModel> trucks = new List<TruckViewModel>();
            var list = truckRepository.List();
            foreach(var truck in list)
            {
                TruckViewModel tvm = new TruckViewModel
                {
                    Chassis = truck.Chassis,
                    BuildingYear = truck.BuildingYear,
                    ModelYear = truck.ModelYear,
                    TruckModel = new SelectListItem
                    {
                        Text = truck.TruckModel.ModelCode,
                        Value = truck.TruckModel.Id.ToString()
                    }
                };
                trucks.Add(tvm);
            }

            return View(trucks);
        }

        [HttpGet, Route("Truck/Create")]
        public IActionResult Create(TruckEditViewModel entity)
        {
            if(entity == null || entity.Chassis == null)
            {
                TruckEditViewModel entity1 = new TruckEditViewModel();
                entity1.TruckModelList = PopulateList();
                return View(entity1);
            }
            return View(entity);
            
        }

        private IEnumerable<SelectListItem> PopulateList()
        {
            List<SelectListItem> models = new List<SelectListItem>();
            

            models.Add(new SelectListItem
            {
                Value = "-1",
                Text = "Selecione um modelo",
                Selected = true
            });

            var lst = truckRepository.ListModels();

            foreach(var item in lst)
            {
                models.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.ModelCode
                });
            }
            return models;
        }

        [HttpPost, Route("truck/Create")]
        public IActionResult Create(TruckViewModel truck)
        {            
            if (!ModelState.IsValid )
            {
                TruckEditViewModel tevm = new TruckEditViewModel
                {
                    Chassis = truck.Chassis,
                    BuildingYear = truck.BuildingYear,
                    ModelYear = truck.ModelYear,
                    TruckModelList = PopulateList(),
                    TruckModel = new SelectListItem
                    {
                        Value = truck.TruckModel.Value
                    }
                };
                return View(tevm);
            }
            if(truck.TruckModel.Value == "-1")
            {
                TruckEditViewModel tevm = new TruckEditViewModel
                {
                    Chassis = truck.Chassis,
                    BuildingYear = truck.BuildingYear,
                    ModelYear = truck.ModelYear,
                    TruckModelList = PopulateList(),
                    TruckModel = new SelectListItem
                    {
                        Value = truck.TruckModel.Value
                    }
                };
                ModelState.AddModelError("TruckModel.Value", "Você deve selecionar um modelo");
                return View("Create", tevm);
            }

            Truck t = new Truck
            {
                Chassis = RandomString(17),
                BuildingYear = truck.BuildingYear,
                ModelYear = truck.ModelYear,
                TruckModelId = Convert.ToInt32(truck.TruckModel.Value)
            };

            truckRepository.Add(t);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("Truck/Details")]
        public IActionResult Details(string chassis)
        {
            Truck t = truckRepository.GetSingle(chassis);
            TruckViewModel tvm = new TruckViewModel
            {
                Chassis = t.Chassis,
                BuildingYear = t.BuildingYear,
                ModelYear = t.ModelYear,
                TruckModel = new SelectListItem
                {
                    Text = t.TruckModel.ModelCode,
                    Value = t.TruckModel.Id.ToString()
                }
            };
            return View(tvm);
        }

        [HttpGet, Route("Truck/Edit")]
        public IActionResult Edit(string chassis)
        {
            if (chassis == null)
            {
                return RedirectToAction("Index");
            }

            Truck t = truckRepository.GetSingle(chassis);
            List<TruckModel> truckModels = truckRepository.ListModels().ToList();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach(TruckModel tmodel in truckModels)
            {
                listItems.Add(new SelectListItem
                {
                    Value = tmodel.Id.ToString(),
                    Text = tmodel.ModelCode,
                    Selected = tmodel.Id == t.TruckModelId
                });
            }

            TruckEditViewModel tevm = new TruckEditViewModel
            {
                Chassis = t.Chassis,
                BuildingYear = t.BuildingYear,
                ModelYear = t.ModelYear,
                TruckModelList = listItems,
                TruckModel = new SelectListItem
                {
                    Value = t.TruckModel.Id.ToString(),
                    Text = t.TruckModel.ModelCode,
                    Selected = true
                }
            };

            return View(tevm);
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost, Route("Truck/Edit")]
        public IActionResult Edit(TruckViewModel truck)
        {
            if (!ModelState.IsValid)
            {
                TruckEditViewModel tevm = new TruckEditViewModel
                {
                    Chassis = truck.Chassis,
                    BuildingYear = truck.BuildingYear,
                    ModelYear = truck.ModelYear,
                    TruckModelList = PopulateList(),
                    TruckModel = new SelectListItem
                    {
                        Value = truck.TruckModel.Value
                    }
                };
                return View(tevm);
            }
            Truck t = new Truck
            {
                Chassis = truck.Chassis,
                BuildingYear = truck.BuildingYear,
                ModelYear = truck.ModelYear,
                TruckModelId = Convert.ToInt32(truck.TruckModel.Value)
            };

            truckRepository.Update(t);

            return RedirectToAction("Index");

        }

        [HttpGet, Route("Truck/Delete")]
        public IActionResult Delete(string chassis)
        {
            if(chassis == null)
            {
                return RedirectToAction("Index");
            }
            Truck t = truckRepository.GetSingle(chassis);
            TruckViewModel tvm = new TruckViewModel
            {
                Chassis = t.Chassis,
                BuildingYear = t.BuildingYear,
                ModelYear = t.ModelYear,
                TruckModel = new SelectListItem
                {
                    Text = t.TruckModel.ModelCode,
                    Value = t.TruckModel.Id.ToString()
                }
            };
            return View(tvm);
        }

        [HttpPost, Route("Truck/Delete")]
        public IActionResult Delete(TruckViewModel truck)
        {
            Truck t = truckRepository.GetSingle(truck.Chassis);

            if(t == null)
            {
                return View("Delete", truck.Chassis);
            }

            truckRepository.Delete(t);
            return RedirectToAction("Index");
        }

    }
}
