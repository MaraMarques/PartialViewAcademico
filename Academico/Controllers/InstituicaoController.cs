using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "Hogwarts",
                Endereco = "Escócia"
            },
            new Instituicao()
            {
                InstituicaoID= 2,
                Nome = "Mansao X",
                Endereco = "Escocia"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
        public IActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instituicao instiuicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instiuicao.InstituicaoID).First());
            instituicoes.Add(instiuicao);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public IActionResult Delete(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }
    }
}
