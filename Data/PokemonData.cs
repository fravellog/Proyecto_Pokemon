using Pokedex.Models;

namespace Pokedex.Data
{

    public static class PokemonData
    {
        public static List<Pokemon> ListaPokemon()
        {
            return new List<Pokemon>
            {
                new Pokemon("charmander", "fuego",100)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("lanzallama", "fuego"),
                        new Ataque("cuchillada", "normal")
                    }
                },
                new Pokemon("squirtle", "agua", 100)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("pistola agua", "agua"),
                        new Ataque("latigo", "normal")
                    }
                },
                new Pokemon("", "planta", 100)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("latigo cepa", "planta"),
                        new Ataque("placaje", "normal")
                    }
                },
                new Pokemon("flareon", "fuego", 100)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("colmillo de fuego", "fuego"),
                        new Ataque("derribar", "normal")
                    }
                },
                new Pokemon("sandshrew", "tierra", 100)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("terremoto", "tierra"),
                        new Ataque("rasguño", "normal")
                    }
                },
                new Pokemon("jolteon", "electrico", 100)
                {
                    Ataques = new List<Ataque>
                    {
                        new Ataque("onda de trueno", "electrico"),
                        new Ataque("ataque rapido", "normal")
                    }
                }

            };
        }
    }

}