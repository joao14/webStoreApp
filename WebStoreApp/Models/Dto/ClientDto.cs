using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoreApp.Models.Dto
{
	public class ClientDto
	{
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(3)]
        public string Edad { get; set; }
        [Required]
        [MaxLength(100)]
        public string Correo { get; set; }
    }
}

