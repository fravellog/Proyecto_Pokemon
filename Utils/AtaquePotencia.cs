using Pokedex.Models;

namespace Pokedex.Utils
{
    public class AtaquePotencia
    {
        public static double CalcularPotencia(Pokemon atacante, Pokemon defensor)
        {
            if (atacante.Tipo == TipoNaturaleza.Fuego && defensor.Tipo == TipoNaturaleza.Planta) return 2.0;
            if (atacante.Tipo == TipoNaturaleza.Planta && defensor.Tipo == TipoNaturaleza.Agua) return 2.0;
            if (atacante.Tipo == TipoNaturaleza.Agua && defensor.Tipo == TipoNaturaleza.Fuego) return 2.0;
            if (atacante.Tipo == TipoNaturaleza.Electrico && defensor.Tipo == TipoNaturaleza.Agua) return 2.0;
            if (atacante.Tipo == TipoNaturaleza.Tierra && defensor.Tipo == TipoNaturaleza.Electrico) return 2.0;
            if (atacante.Tipo == TipoNaturaleza.Planta && defensor.Tipo == TipoNaturaleza.Electrico) return 2.0;

            if (atacante.Tipo == TipoNaturaleza.Planta && defensor.Tipo == TipoNaturaleza.Fuego) return 0.5;
            if (atacante.Tipo == TipoNaturaleza.Fuego && defensor.Tipo == TipoNaturaleza.Agua) return 0.5;
            if (atacante.Tipo == TipoNaturaleza.Fuego && defensor.Tipo == TipoNaturaleza.Tierra) return 0.5;
            if (atacante.Tipo == TipoNaturaleza.Agua && defensor.Tipo == TipoNaturaleza.Planta) return 0.5;
            
            return 1.0;
        }
    }
}