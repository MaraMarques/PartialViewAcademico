using Academico.Data;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academico.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly AcademicoContext _context;

        public InstituicaoController(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
        }
        public IActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ("Nome", "Endereco")]Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Erro", "Não foi possível cadastrar a instituição");
            }
            return View(instituicao);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("InstituicaoID", "Nome", "Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        public IActionResult Details(int id)
        {
            return null;
        }

        public IActionResult Delete(int id)
        {
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instituicao instituicao)
        {
            return null;
        }
        private bool InstituicaoExists(long? id)
        {
            return (_context.Instituicoes?.Any(e => e.InstituicaoID == id)).GetValueOrDefault();
        }
    }
}
