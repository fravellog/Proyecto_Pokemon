namespace Pokedex.Models
{
    public class Pokebola
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int EfectoCaptura { get; set; }

        public Pokebola(string nombre, string tipo, int efectoCaptura)
        {
            Nombre = nombre;
            Tipo = tipo;
            EfectoCaptura = efectoCaptura;
        }
    }
}