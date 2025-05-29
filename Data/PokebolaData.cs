using Pokedex.Models;
namespace Pokedex.Data
{
    public static class PokebolaData
    {
        public static List<Pokebola> Pokebolas = new List<Pokebola>()
        {
            new Pokebola("Pokebola", "Básica", 50),
            new Pokebola("Superbola", "Mejorada", 100),
            new Pokebola("Ultrabola", "Avanzada", 200),
            new Pokebola("Masterball", "Élite", 9999)
        };
    }
}