using System;
using System.ComponentModel.DataAnnotations;
using Piekarnia.Common.Enums;

namespace Piekarnia.Api.BindingModels
{
    public class EditClient
    {
        [Required]
        [Display(Name = "Name")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string ClientSurname { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string ClientMail { get; set; }
        [Required]
        [Display(Name = "City")]
        public string ClientCity { get; set; }

    }
}
