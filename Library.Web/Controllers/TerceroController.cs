using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecnicalTestPersonas.Data.Models;
using TecnicalTestPersonas.Domain.Service.Interface;

namespace TecnicalTestPersonas.Web.Controllers
{
    public class TerceroController : Controller
    {
        private readonly ITercero _Tercero;

        public TerceroController(ITercero Tercero)
        {
            _Tercero = Tercero;
        }

        // GET: Tercero
        public IActionResult Index()
        {
          return View();
        }
       
        // GET: Tercero/Details/5
        public IActionResult Details(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }

            var Tercero = _Tercero.GetTercero((int)id);
            
            if (Tercero == null)
            {
                response = NotFound();
            }

            response = View(Tercero);
            return response;
        }

        // GET: Tercero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tercero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nombre,Apellido,CorreoElectronico1,CorreoElectronico2,Tel1,Tel2,Direccion1,Direccion2 ")] Tercero Tercero)
        {
            IActionResult response;
            if (ModelState.IsValid)
            {
                var tercero = _Tercero.GetTerceroByDocumento(Tercero.Documento);
                if (tercero != null)
                {
                    ModelState.AddModelError(string.Empty, "Ya existe esta persona");
                    response = View(Tercero);
                    return response;
                }

                var Val =new Regex(@"/^[a-zA-Z-9]+$/");

                if (!Val.IsMatch(Tercero.Documento))//controlo que el nombre sea solo letras
                {
                    ModelState.AddModelError(string.Empty, "NO se aceptan caracteres especiales");
                    response = View(Tercero);
                    return response;
                }

                Val = new Regex(@"/^[a-zA-Z]+$/");
                if (!Val.IsMatch(Tercero.Nombre))//controlo que el nombre sea solo letras
                {
                    ModelState.AddModelError(string.Empty, "el nombre solo debe contener letras");
                    response = View(Tercero);
                    return response;
                }

                if (!Val.IsMatch(Tercero.Apellido))//controlo que el nombre sea solo letras
                {
                    ModelState.AddModelError(string.Empty, "el apellido solo debe contener letras");
                    response = View(Tercero);
                    return response;
                }

                bool result = await _Tercero.InsertTercero(Tercero);
                if (result)
                {
                    response = RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se puudo crear la Tercero");
                    response = View(Tercero);
                }
            }
            else
            {
                response = View(Tercero);
            }

            return response;
        }


        // GET: Tercero/Edit/5
        public IActionResult Edit(int? id)
        {
            IActionResult response;
            if (id == null)
            {
                response = NotFound();
            }
            var edotorial= _Tercero.GetTercero((int)id);
            if (edotorial == null)
            {
                response = NotFound();
            }
            response = View(edotorial);
            return response;
        }

       
    }
}
