using System.Text;
using Pokedex.Data;
using Pokedex.Views;
using Pokedex.Models;
using Pokedex.Utils;

namespace Pokedex.Controllers
{
    public class PokemonController
    {
        public void pokemonInicial(Entrenador entrenador)
        {
            while (true)
            {
                ConsolaUtil.LimpiarConsola();
                AsciiView.Textos(3);
                ConsolaUtil.escribir("¡Muy bien, es momento de elegir tu pokemon inicial!\n\n");
                ConsolaUtil.LimpiarConsola();
                ConsolaUtil.escribir("1. Charmander\n");
                ConsolaUtil.escribir("2. Squirtle\n");
                ConsolaUtil.escribir("3. Bulbasaur\n");

                ConsolaUtil.escribir("¡Selecciona el número de tu pokemon inicial!:\n\n");

                int seleccionPokemon = -1;
                try
                {
                    seleccionPokemon = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPokemon + 1 < 0 || seleccionPokemon + 1 > 3)
                    {
                        ConsolaUtil.LimpiarConsola();
                        Console.WriteLine("Por favor, seleccione un pokemon válido.");
                        continue;
                    }

                }
                catch (FormatException)
                {
                    ConsolaUtil.LimpiarConsola();
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    ConsolaUtil.LimpiarConsola();
                    Console.WriteLine("Por favor, seleccione un pokemon válido.");
                    continue;
                }
                ConsolaUtil.LimpiarConsola();
                PokemonView.VerPokemon(PokemonData.ListaPokemon()[seleccionPokemon]);
                PokemonData.ListaPokemon()[seleccionPokemon].MostrarPokemon();
                ConsolaUtil.escribir("¿Es correcto? (S/N)\n");
                string confirmacion = Console.ReadLine();
                if (confirmacion.ToUpper() == "S")
                {
                    ConsolaUtil.LimpiarConsola();
                    Pokemon pokemonElegido = PokemonData.ListaPokemon()[seleccionPokemon];
                    ConsolaUtil.escribir($"¡Has elegido a {pokemonElegido.Nombre} como tu pokemon inicial!\n");
                    entrenador.agregarPokemon(pokemonElegido);
                    break;
                }
                else if (confirmacion.ToUpper() == "N")
                {
                    ConsolaUtil.LimpiarConsola();
                    Console.WriteLine("¡Intenta de nuevo!");
                    continue;
                }
                else
                {
                    ConsolaUtil.LimpiarConsola();
                    Console.WriteLine("Opción no válida. Por favor, elige S o N.");
                    continue;
                }
            }
        }
        public static void apodoPokemon(Entrenador entrenador)
        {
            ConsolaUtil.mostrarCarga();
            ConsolaUtil.LimpiarConsola();
            ConsolaUtil.escribir("¡Es momento de ponerle un apodo a tu pokemon!\n");
            while (true)
            {
                ConsolaUtil.escribir("Selecciona el pokemon al que le quieres poner un apodo:");
                for (int i = 0; i < entrenador.Equipo.Count; i++)
                {
                    ConsolaUtil.escribir($"{i + 1}. {entrenador.Equipo[i].Nombre}\n");
                }

                int seleccionPokemon = -1;
                try
                {
                    seleccionPokemon = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPokemon < 0 || seleccionPokemon >= entrenador.Equipo.Count)
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

                Console.WriteLine($"¿Qué apodo le quieres poner a tu {entrenador.Equipo[seleccionPokemon].Especie}?");
                string apodo = Console.ReadLine();
                if (!string.IsNullOrEmpty(apodo))
                {
                    entrenador.Equipo[seleccionPokemon].Nombre = apodo;
                    Console.WriteLine($"¡Has puesto el apodo {apodo} a tu {entrenador.Equipo[seleccionPokemon].Especie}!");
                    ConsolaUtil.EsperaryLimpiar();
                    break;
                }
                else
                {
                    Console.WriteLine("El apodo no puede estar vacío. Inténtalo de nuevo.");
                    continue;
                }
            }
        }
    }
}