using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TruckManager.ViewModels.Validation;

namespace TruckManager.ViewModels
{
    public class TruckModelViewModel
    {
        public string Value { get; set; }

        [Required, MaxLength(10), TruckModel]
        public string Text { get; set; }
    }
}
