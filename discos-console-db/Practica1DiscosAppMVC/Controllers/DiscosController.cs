using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace Practica1DiscosAppMVC.Controllers
{
    public class DiscosController : Controller
    {
        // GET: DiscosController
        public ActionResult Index()
        {
            DiscoNegocio negocioDisco = new DiscoNegocio();
            var listaDiscos = negocioDisco.listar();
            return View(listaDiscos);
        }

        // GET: DiscosController/Details/5
        public ActionResult Details(int id)
        {
            DiscoNegocio negocioDisco = new DiscoNegocio();
            var disco = negocioDisco.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // GET: DiscosController/Create
        public ActionResult Create()
        {
            TipoEdicionNegocio negocioTipoEdicion = new TipoEdicionNegocio();
            ViewBag.TipoEdicion = new SelectList(negocioTipoEdicion.listar(), "Id", "Descripcion");
            EstiloNegocio negocioEstilo = new EstiloNegocio();
            ViewBag.Estilo = new SelectList(negocioEstilo.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: DiscosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                DiscoNegocio negocioDisco = new DiscoNegocio();
                negocioDisco.agregar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TipoEdicionNegocio negocioTipoEdicion = new TipoEdicionNegocio();
                ViewBag.TipoEdicion = new SelectList(negocioTipoEdicion.listar(), "Id", "Descripcion");
                EstiloNegocio negocioEstilo = new EstiloNegocio();
                ViewBag.Estilo = new SelectList(negocioEstilo.listar(), "Id", "Descripcion");
                return View();
            }
        }

        // GET: DiscosController/Edit/5
        public ActionResult Edit(int id)
        {
            DiscoNegocio negocioDisco = new DiscoNegocio();
            var disco = negocioDisco.listar().Find(d => d.Id == id);
            TipoEdicionNegocio negocioTipoEdicion = new TipoEdicionNegocio();
            ViewBag.TipoEdicion = new SelectList(negocioTipoEdicion.listar(), "Id", "Descripcion");
            EstiloNegocio negocioEstilo = new EstiloNegocio();
            ViewBag.Estilo = new SelectList(negocioEstilo.listar(), "Id", "Descripcion");
            return View(disco);
        }

        // POST: DiscosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                DiscoNegocio negocioDisco = new DiscoNegocio();
                negocioDisco.modificar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TipoEdicionNegocio negocioTipoEdicion = new TipoEdicionNegocio();
                ViewBag.TipoEdicion = new SelectList(negocioTipoEdicion.listar(), "Id", "Descripcion");
                EstiloNegocio negocioEstilo = new EstiloNegocio();
                ViewBag.Estilo = new SelectList(negocioEstilo.listar(), "Id", "Descripcion");
                return View();
            }
        }

        // GET: DiscosController/Delete/5
        public ActionResult Delete(int id)
        {
            DiscoNegocio negocioDisco = new DiscoNegocio();
            var disco = negocioDisco.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // POST: DiscosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DiscoNegocio negocioDisco = new DiscoNegocio();
                negocioDisco.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
