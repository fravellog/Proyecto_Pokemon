using Pokedex.Models;

namespace Pokedex.Data
{
    public static class PocionData
    {
        public static List<Pocion> Pociones = new List<Pocion>()
        {
            new Pocion("Poción", "Recupera 20 puntos de vida", 20),
            new Pocion("Superpoción", "Recupera 50 puntos de vida", 50),
            new Pocion("Hipopoción", "Recupera 100 puntos de vida", 70),
            new Pocion("Máxima poción", "Recupera todos los puntos de vida", 9999)
        };
    }
}