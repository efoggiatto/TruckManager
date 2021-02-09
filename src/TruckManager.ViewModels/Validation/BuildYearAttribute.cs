using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TruckManager.ViewModels.Validation
{
    public class BuildYearAttribute : ValidationAttribute
    {
        public BuildYearAttribute()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("Ano de Fabricação não pode ser vazio!");
            }

            if (int.TryParse(value.ToString(), out int v))
            {
                int allowedValue = DateTime.Now.Year;
                if (v != allowedValue)
                {
                    return new ValidationResult($"O único valor disponível é o ano atual ({allowedValue})");
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
