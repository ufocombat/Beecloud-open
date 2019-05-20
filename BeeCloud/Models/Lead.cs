using System;
using System.ComponentModel.DataAnnotations;

namespace BeeCloud.Models
{
    public class Lead
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        public String Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        public String Email { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        public String Phone { get; set; }

        [DataType(DataType.MultilineText)]
        public String Message { get; set; }
    }
}
