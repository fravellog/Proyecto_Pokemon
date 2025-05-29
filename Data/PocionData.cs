using Pokedex.Models;

namespace Pokedex.Data
{
    public static class PocionData
    {
        public static List<Pocion> Pociones = new List<Pocion>()
        {
            new Pocion("Pocion", "Recupera 20 puntos de vida", 20),
            new Pocion("Superpocion", "Recupera 50 puntos de vida", 50),
            new Pocion("Ultrapocion", "Recupera 100 puntos de vida", 100),
            new Pocion("Máxima pocion", "Recupera todos los puntos de vida", 9999)
        };
    }
}