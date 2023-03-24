using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreApp.Models
{
	public class Client
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Edad { get; set; }
        [Required]
        public string Correo { get; set; }

        public Client() { }

        public Client(string Id, string Nombre, string Edad, string Correo)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Correo = Correo;


        }
    }
}

