using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TruckManager.ViewModels.Validation;

namespace TruckManager.ViewModels
{
    public class TruckEditViewModel
    {
        [MaxLength(17)]
        public string Chassis { get; set; }

        [Required]
        public SelectListItem TruckModel { get; set; }
        public IEnumerable<SelectListItem> TruckModelList { get; set; }

        [Required, BuildYear]
        public int BuildingYear { get; set; }

        [Required, ModelYear]
        public int ModelYear { get; set; }

        public TruckEditViewModel()
        {
            BuildingYear = DateTime.Now.Year;
            ModelYear = DateTime.Now.Year;
        }
    }
}
