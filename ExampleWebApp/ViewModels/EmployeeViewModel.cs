using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Длина фамилии должна быть от 2 до 255 символов")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 255 символов")]
        public string Name { get; set; }

        [Display(Name = "Премия")]
        [Range(0, Double.PositiveInfinity)]
        public decimal Salary { get; set; }
    }
}
