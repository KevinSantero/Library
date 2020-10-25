using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Data.Models;
using Library.Domain.Service.Interface;

namespace Library.Web.Controllers
{
    public class EditorialController : Controller
    {
        private readonly IEditorial _editorial;

        public EditorialController(IEditorial editorial)
        {
            _editorial = editorial;
        }

        // GET: Editorial
        public IActionResult Index()
        {
          return View(_editorial.SelectAllEditorial()) ;
        }
       
        // GET: Editorial/Details/5
        public IActionResult Details(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }

            var editorial = _editorial.GetEditorial((int)id);
            
            if (editorial == null)
            {
                response = NotFound();
            }

            response = View(editorial);
            return response;
        }


        // GET: Editorial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Editorial editorial)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = await _editorial.InsertEditorial(editorial);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se puudo crear la Editorial");
                    response = View(editorial);
                }
            }
            else
            {
                response = View(editorial);
            }

            return response;
        }


        // GET: Editorial/Edit/5
        public IActionResult Edit(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            var edotorial= _editorial.GetEditorial((int)id);
            if (edotorial == null)
            {
                response = NotFound();
            }
            response = View(edotorial);
            return response;
        }

        // POST: Editorial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Editorial editorial)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                bool result = await _editorial.UpdateEditorial(editorial);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo editar la Editorial");
                    response = View(editorial);
                }
            }
            else
            {
                response = View(editorial);
            }
            return response;
        }

        // GET: Editorial/Delete/5
        public IActionResult Delete(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            var  editorial= _editorial.GetEditorial((int)id);
            if (editorial == null)
            {
                response = NotFound();
            }
            response = View(editorial);
            return response;

        }

        // POST: Editorial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            IActionResult response;
            bool result = await _editorial.DeleteEditorial(id);
            if (result)
            {
                response = RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No se pudo eliminar la Editorial");
                response = RedirectToAction(nameof(Index));
            }

            return response;
        }

       
    }
}
