using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TruckManager.ViewModels.Validation
{
    class ModelYearAttribute : ValidationAttribute 
    {
        public ModelYearAttribute()
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if(value == null)
            {
                return new ValidationResult("Ano Modelo não pode ser vazio!");
            }

            if (int.TryParse(value.ToString(), out int v))
            {
                int minYear = DateTime.Now.Year;
                int maxYear = DateTime.Now.AddYears(1).Year;

                if (v < minYear || v > maxYear)
                {
                    return new ValidationResult($"Ano Modelo deve estar entre {minYear} e {maxYear}");
                }
            }
            else
            {
                return new ValidationResult("O Valor precisa ser um número inteiro");
            }

            return ValidationResult.Success;
        }
    }
}
