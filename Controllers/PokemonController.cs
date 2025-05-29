using System.Text;
using Pokedex.Data;
using Pokedex.Views;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonController
    {
        public void pokemonInicial(Entrenador entrenador)
        {
            Console.Clear();
            AsciiView.Textos(3);
            Console.WriteLine("¡Muy bien, es momento de elegir tu pokemon inicial!");
            while (true)
            {
                Console.WriteLine("1. Charmander");
                Console.WriteLine("2. Squirtle");
                Console.WriteLine("3. Bulbasaur");

                Console.WriteLine("¡Selecciona el número de tu pokemon inicial!:");

                int seleccionPokemon = -1;
                try
                {
                    seleccionPokemon = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPokemon+1 < 0 || seleccionPokemon+1 > 3)
                    {
                        Console.WriteLine("Por favor, seleccione un pokemon válido.");
                        continue;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Por favor, seleccione un pokemon válido.");
                    continue;
                    
                }
                PokemonView.VerPokemon(seleccionPokemon + 1);
                PokemonData.ListaPokemon()[seleccionPokemon].MostrarPokemon();
                Console.WriteLine("¿Es correcto? (S/N)");
                string confirmacion = Console.ReadLine();
                if (confirmacion.ToUpper() == "S")
                {
                    Pokemon pokemonElegido = PokemonData.ListaPokemon()[seleccionPokemon];
                    Console.WriteLine($"¡Has elegido a {pokemonElegido.Nombre} como tu pokemon inicial!");
                    entrenador.agregarPokemon(pokemonElegido);
                    break;
                }
                else if (confirmacion.ToUpper() == "N")
                {
                    Console.WriteLine("¡Intenta de nuevo!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, elige S o N.");
                    continue;
                }
            }
        }
    }
}