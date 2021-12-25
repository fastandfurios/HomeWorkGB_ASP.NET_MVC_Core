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
        [StringLength(255, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Премия")]
        public decimal Salary { get; set; }
    }
}
