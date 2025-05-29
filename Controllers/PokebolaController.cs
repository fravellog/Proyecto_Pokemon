using Pokedex.Models;
using Pokedex.Data;
using Pokedex.Utils;
using Pokedex.Views;
namespace Pokedex.Controllers
{
    public class PokebolaController
    {
        public static void comprarPokebola(Entrenador entrenador)
        {
            ConsolaUtil.LimpiarConsola();
            AsciiView.Textos(7);
            Console.WriteLine("Bienvenido a la tienda de Pokebolas!");
            Console.WriteLine("En esta sección puede seleccionar la Pokebola que desea almacenar!");
            while (true)
            {
                Console.WriteLine("1. Pokebola");
                Console.WriteLine("2. Superbola");
                Console.WriteLine("3. Ultrabola");
                Console.WriteLine("4. Masterball");
                Console.WriteLine("5. Salir de la tienda");
                Console.WriteLine("¡Selecciona el número de la Pokebola que deseas comprar!:");

                int seleccionPokebola = -1;
                try
                {
                    seleccionPokebola = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPokebola < 0 || seleccionPokebola > PokebolaData.Pokebolas.Count - 1)
                    {
                        if (seleccionPokebola == 4)
                        {
                            Console.WriteLine("¡Gracias por visitar la tienda de Pokebolas!");
                            ConsolaUtil.EsperaryLimpiar();
                            break;
                        }
                        Console.WriteLine("Por favor, seleccione una Pokebola válida.");
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
                    Console.WriteLine("Por favor, seleccione una Pokebola válida.");
                    continue;
                }

                PokebolaData.Pokebolas[seleccionPokebola].MostrarPokebola();
                Console.WriteLine("¿Es correcto? (S/N)");
                string confirmacion = Console.ReadLine();

                if (confirmacion.ToUpper() == "S")
                {
                    entrenador.agregarPokebola(PokebolaData.Pokebolas[seleccionPokebola]);
                    Console.WriteLine($"¡Has comprado una {PokebolaData.Pokebolas[seleccionPokebola].Nombre}!");
                    Console.WriteLine($"Ahora tienes {entrenador.Pokebolas.Count} Pokebolas en tu inventario.");
                    ConsolaUtil.EsperaryLimpiar();
                }
                else if (confirmacion.ToUpper() == "N")
                {
                    Console.WriteLine("¡Intenta de nuevo!");
                }
            }
        }
    }
}