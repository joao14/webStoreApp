using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Data;
using WebStoreApp.Models;
using WebStoreApp.Models.Dto;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStoreApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ApplicationDbContext _db;

        public ClientController(ILogger<ClientController> logger, ApplicationDbContext db)
        {
            this._logger = logger;
            this._db = db;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllClients()
        {
            return Json(_db.Clients.ToList());
        }

        //Put Client
        [HttpPut]
        public JsonResult UpdateClient(string id, ClientDto clientDto)
        {
            if (clientDto == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error en el DTO");
            }

            Client client = new()
            {
                Id = id,
                Nombre = clientDto.Nombre,
                Edad = clientDto.Edad,
                Correo = clientDto.Correo
            };

            _db.Clients.Update(client);
            _db.SaveChanges();

            return Json(new { success = true });
        }

        //Delete Client
        [HttpDelete]
        public JsonResult DeleteClient(string id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error en el DTO");
            }

            Client? client = _db.Clients.FirstOrDefault(client => client.Id == id);

            if (client == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error get info client");
            }

            _db.Clients.Remove(client);
            _db.SaveChanges();

            return Json(new { success = true });
        }

        //Post Client
        [HttpPost]
        public JsonResult CreateClient(ClientDto clientDto)
        {
            if (clientDto == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error en el DTO");
            }

            Client client = new()
            {
                Nombre = clientDto.Nombre,
                Edad = clientDto.Edad,
                Correo = clientDto.Correo
            };

            _db.Clients.Add(client);
            _db.SaveChanges();

            Client? client_ = _db.Clients.FirstOrDefault(client => client.Nombre == clientDto.Nombre);

            return Json(new { success = true });
        }

    }
}

  

