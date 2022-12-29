using ZasilaczDB.Models;

namespace ZasilaczDB.Serwisy
{
    public interface IZasilaczSerwis
    {
        List<Zasilacz> ListaZasilaczy();

        void DodajZasilacz(Zasilacz zasilacz);

        void UsunZasilacz(int id);

        void EdytujZasilacz(Zasilacz zasilacz);

        Zasilacz ZnajdzZasilacz(int id);
    }
}
