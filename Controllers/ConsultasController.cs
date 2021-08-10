using Consultorio.Models;
using Consultorio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    public class ConsultasController : Controller
    {
        IConsultasService service;
        IPacienteService pacienteService;

        public ConsultasController(IConsultasService service, IPacienteService pacienteService)
        {
            this.service = service;
            this.pacienteService = pacienteService;
        }

        public IActionResult Index()
        {
   

            return View(service.getAll());
        }

        [HttpGet]
        public IActionResult Create()
        {   var pacientes = pacienteService.getAll();
            ViewBag.listaDePacientes = new SelectList(pacientes, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consultas consultas)
        {
            var pacientes = pacienteService.getAll();
            ViewBag.listaDePacientes = new SelectList(pacientes, "Id", "Nome");
            if (!ModelState.IsValid) return View(consultas);

            if (service.create(consultas))
              return  RedirectToAction(nameof(Index));
            else
            {
               
                return  View(consultas);
            }
        }  
            

        public IActionResult Read(int? id)
        {
            Consultas consultas = service.get(id);
            return consultas != null ?
                View(consultas) :
                NotFound();
        }

        public IActionResult Update(int? id)
        {
            var pacientes = pacienteService.getAll();
            ViewBag.listaDePacientes = new SelectList(pacientes, "Id", "Nome");
            Consultas consultas = service.get(id);
            return consultas != null ?
                View(consultas) :
                NotFound();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult Update(Consultas consultas)
        {
            var pacientes = pacienteService.getAll();
            ViewBag.listaDePacientes = new SelectList(pacientes, "Id", "Nome");
            if (!ModelState.IsValid) return View(consultas);

            if (service.update(consultas)) 
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(consultas);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (service.delete(id)) 
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
