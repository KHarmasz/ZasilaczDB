using Microsoft.AspNetCore.Mvc;
using ZasilaczDB.Models;
using ZasilaczDB.Serwisy;

namespace ZasilaczDB.Controllers
{
    public class ZasilaczController : Controller
    {
        IZasilaczSerwis serwis;

        public ZasilaczController(IZasilaczSerwis serwis)
        {
            this.serwis = serwis;
        }
        public IActionResult Lista()
        {
            var Zasilacze = serwis.ListaZasilaczy();
            return View(Zasilacze);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Zasilacz zasilacz)
        {
            serwis.DodajZasilacz(zasilacz);
            return RedirectToAction("Lista", "Zasilacz");
        }
        public IActionResult Edit(int id)
        {
            var ZasilaczDoEdycji = serwis.ZnajdzZasilacz(id);
            return View(ZasilaczDoEdycji);
        }

        [HttpPost]
        public IActionResult Edit(Zasilacz zasilacz)
        {
            serwis.EdytujZasilacz(zasilacz);
            return RedirectToAction("Lista", "Zasilacz");
        }

        public IActionResult Delete(int id)
        {
            serwis.UsunZasilacz(id);
            return RedirectToAction("Lista", "Zasilacz");
        }

        [HttpPost]
        public IActionResult Delete(Zasilacz zasilacz)
        {
            serwis.UsunZasilacz(zasilacz.Id);
            return RedirectToAction("Lista", "Zasilacz");
        }

    }
}
