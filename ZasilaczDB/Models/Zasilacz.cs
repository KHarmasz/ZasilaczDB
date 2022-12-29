namespace ZasilaczDB.Models
{
    public class Zasilacz
    {
        public int Id { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        public int Moc { get; set; }

        public string Certyfikat { get; set; }

        public int Cena { get; set; }
    }
}
