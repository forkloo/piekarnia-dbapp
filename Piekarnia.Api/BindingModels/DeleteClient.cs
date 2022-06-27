using System;
using System.ComponentModel.DataAnnotations;

namespace Piekarnia.Api.BindingModels
{
    public class DeleteClient
    {
        [Required]
        [Display(Name = "ClientId")]
        public string ClientId { get; set; }
    }
}
