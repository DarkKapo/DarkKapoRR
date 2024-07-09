namespace DarkKapoRR.Entidades
{
    public class Region
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public int MilitaryAcademy { get; set; } //No tiene consumo de energía
        public int Hospital { get; set; }
        public int MilitaryBase { get; set; }
        public int School { get; set; }
        public int MissileSystem { get; set; }
        public int SeaPort { get; set; } //Para regiones con acceso al mar
        public int PowerPlant { get; set; } //No tiene consumo de energía
        public int Spaceport { get; set; }
        public int Airport { get; set; }
        public int HouseFund { get; set; }
    }
}
