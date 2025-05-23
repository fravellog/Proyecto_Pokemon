using Pokedex.Models;

namespace Pokedex.Data
{

    public static class PokemonData
    {
        public static List<Pokemon> ListaPokemon()
        {
            return new List<Pokemon>
            {
                new Pokemon("charmander", 200, TipoNaturaleza.Fuego)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("lanzallama", 20, TipoNaturaleza.Fuego),
                        new Ataque("cuchillada", 10, TipoNaturaleza.Normal)
                    }
                },
                new Pokemon("squirtle", 200, TipoNaturaleza.Agua)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("pistola agua", 20, TipoNaturaleza.Agua),
                        new Ataque("latigo", 10, TipoNaturaleza.Normal)
                    }
                },
                new Pokemon("bulbasaur", 200, TipoNaturaleza.Planta)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("latigo cepa", 20, TipoNaturaleza.Planta),
                        new Ataque("placaje", 10, TipoNaturaleza.Normal)
                    }
                },
                new Pokemon("flareon", 200, TipoNaturaleza.Fuego)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("colmillo de fuego", 20, TipoNaturaleza.Fuego),
                        new Ataque("derribar", 10, TipoNaturaleza.Normal)
                    }
                },
                new Pokemon("sandshrew", 200, TipoNaturaleza.Tierra)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("terremoto", 20, TipoNaturaleza.Tierra),
                        new Ataque("rasguño", 10, TipoNaturaleza.Normal)
                    }
                },
                new Pokemon("jolteon", 200, TipoNaturaleza.Electrico)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("onda de trueno", 20, TipoNaturaleza.Electrico),
                        new Ataque("ataque rapido", 10, TipoNaturaleza.Normal)
                    }
                }

            };
        }
    }

}