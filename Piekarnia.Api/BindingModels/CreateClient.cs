using System;
using System.ComponentModel.DataAnnotations;

namespace Piekarnia.Api.BindingModels
{
    public class CreateClient
    {
        [Required]
        [Display(Name = "Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string ClientSurname { get; set; }

        [Required]
        [Display(Name = "City")]
        public string ClientCity { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        public string ClientMail { get; set; }
    }
}
