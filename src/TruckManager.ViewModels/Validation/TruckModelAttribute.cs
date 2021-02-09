using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace TruckManager.ViewModels.Validation
{
    public class TruckModelAttribute : ValidationAttribute
    {
        public TruckModelAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("Modelo não pode ser vazio!");
            }
            else
            {
                string v = value.ToString();

                if (!Regex.IsMatch(v, @"[Ff][hHmM][\D]?[a-zA-Z0-9]*"))
                {
                    return new ValidationResult("Modelos devem obrigatoriamente iniciar com FH ou FM");
                }
            }
            return ValidationResult.Success;
        }
    }
}
