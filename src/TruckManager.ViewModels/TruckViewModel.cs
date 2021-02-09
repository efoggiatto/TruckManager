using System;
using System.ComponentModel.DataAnnotations;
using TruckManager.ViewModels.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace TruckManager.ViewModels
{
    public class TruckViewModel
    {
        [MaxLength(17)]
        public string Chassis { get; set; }

        [Required]
        public SelectListItem TruckModel {get;set;}

        [Required, BuildYear]
        public int BuildingYear { get; set; }

        [Required, ModelYear]
        public int ModelYear { get; set; }

        public TruckViewModel()
        {
           
            BuildingYear = DateTime.Now.Year;
            ModelYear = DateTime.Now.Year;
        }

        
    }
}
