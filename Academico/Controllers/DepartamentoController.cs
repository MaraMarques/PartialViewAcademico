using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class DepartamentoController : Controller
    {
        private static List<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento()
            {
                DepartamentoID = 1,
                Nome = "Sistemas de Informação"
            },
            new Departamento()
            {
                DepartamentoID= 42,
                Nome = "Armário"
            }
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            departamento.DepartamentoID = departamentos.Select(d => d.DepartamentoID).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            return View(departamentos.Where(d => d.DepartamentoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(d => d.DepartamentoID == departamento.DepartamentoID).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
    }
}
