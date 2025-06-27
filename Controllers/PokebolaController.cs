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
            ConsolaUtil.escribir("Bienvenido a la tienda de Pokebolas!\n");
            ConsolaUtil.escribir("En esta sección puede seleccionar la Pokebola que desea almacenar (MAX. 5)!\n\n");
            while (true)
            {
                ConsolaUtil.escribir("1. Pokebola\n");
                ConsolaUtil.escribir("2. Superbola\n");
                ConsolaUtil.escribir("3. Ultrabola\n");
                ConsolaUtil.escribir("4. Masterball\n");
                ConsolaUtil.escribir("5. Salir de la tienda\n");
                ConsolaUtil.escribir("¡Selecciona el número de la Pokebola que deseas comprar!:\n\n");

                int seleccionPokebola = -1;
                try
                {
                    seleccionPokebola = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPokebola < 0 || seleccionPokebola > PokebolaData.Pokebolas.Count - 1)
                    {
                        if (seleccionPokebola == 4)
                        {
                            ConsolaUtil.escribir("¡Gracias por visitar la tienda de Pokebolas!\n");
                            ConsolaUtil.EsperaryLimpiar();
                            break;
                        }
                        ConsolaUtil.escribir("Por favor, seleccione una Pokebola válida.\n");
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
                ConsolaUtil.escribir("¿Es correcto? (S/N)\n");
                string confirmacion = Console.ReadLine();

                if (confirmacion.ToUpper() == "S" && entrenador.Pokebolas.Count < 5)
                {
                    entrenador.agregarPokebola(PokebolaData.Pokebolas[seleccionPokebola]);
                    ConsolaUtil.escribir($"¡Has comprado una {PokebolaData.Pokebolas[seleccionPokebola].Nombre}!\n");
                    ConsolaUtil.escribir($"Ahora tienes {entrenador.Pokebolas.Count} Pokebolas en tu inventario.\n");
                    ConsolaUtil.EsperaryLimpiar();
                }
                else if (confirmacion.ToUpper() == "N")
                {
                    ConsolaUtil.escribir("¡Intenta de nuevo!\n");
                }
                else if (confirmacion.ToUpper() == "S" && entrenador.Pokebolas.Count == 5)
                {
                    ConsolaUtil.escribir("¡No puedes llevar más Pokebolas!\n");
                    ConsolaUtil.EsperaryLimpiar();
                    continue;
                }
            }
        }
    }
}