using ZasilaczDB.Models;
using Zasilacze;

namespace ZasilaczDB.Serwisy
{
    public class ZasilaczSerwis : IZasilaczSerwis
    {

        Baza baza;

        public ZasilaczSerwis(Baza baza)
        {
            this.baza = baza;
        }
        public virtual void DodajZasilacz(Zasilacz zasilacz)
        {
            baza.Zasilacz.Add(zasilacz);
            baza.SaveChanges();
        }

        public List<Zasilacz> ListaZasilaczy()
        {

            return baza.Zasilacz.ToList();
        }

        public void UsunZasilacz(int id)
        {
            var ZasilaczDoUsuniecia = baza.Zasilacz.Find(id);
            baza.Zasilacz.Remove(ZasilaczDoUsuniecia);
            baza.SaveChanges();
        }

        public void EdytujZasilacz(Zasilacz zasilacz)
        {
            baza.Entry(zasilacz).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            baza.SaveChanges();
        }

        public Zasilacz ZnajdzZasilacz(int id)
        {
            return baza.Zasilacz.Find(id);
        }
    }
}
