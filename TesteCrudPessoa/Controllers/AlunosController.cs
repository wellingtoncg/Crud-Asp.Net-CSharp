using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteCrudPessoa.Models;
using TesteCrudPessoa.Models.ViewModels;
using TesteCrudPessoa.Services;

namespace TesteCrudPessoa.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AlunosService _alunoService;

        public AlunosController(AlunosService alunosService)
        {
            _alunoService = alunosService;
        }

        public IActionResult Index()
        {
            var list = _alunoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            _alunoService.Insert(aluno);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _alunoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _alunoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _alunoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _alunoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }


            AlunosFormViewModel viewModel = new AlunosFormViewModel { Aluno = obj };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }
            _alunoService.Update(aluno);
            return RedirectToAction(nameof(Index));
            
        }
    }
}