using Pokedex.Models;
using Pokedex.Views;
using Pokedex.Data;
using Pokedex.Utils;
namespace Pokedex.Controllers
{
    public class PocionController
    {
        public static void comprarPocion(Entrenador entrenador)
        {
            Console.Clear();
            AsciiView.Textos(6);
            Console.WriteLine("¡Bienvenido a la tienda de pociones!");
            Console.WriteLine("En esta seccion puede seleccionar la pocion que desea almacenar!");
            while (true)
            {
                ConsolaUtil.LimpiarConsola();
                Console.WriteLine("1. Pocion");
                Console.WriteLine("2. Super Pocion");
                Console.WriteLine("3. Ultra Pocion");
                Console.WriteLine("4. Maxima Pocion");
                Console.WriteLine("5. Salir de la tienda");
                Console.WriteLine("¡Selecciona el número de la poción que deseas comprar!:");
                int seleccionPocion = -1;
                try
                {
                    seleccionPocion = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPocion < 0 || seleccionPocion > PocionData.Pociones.Count - 1)
                    {
                        if (seleccionPocion == 5)
                        {
                            Console.WriteLine("¡Gracias por visitar la tienda de pociones!");
                            ConsolaUtil.EsperaryLimpiar();
                            break;
                        }
                        Console.WriteLine("Por favor, seleccione una poción válida.");
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
                    Console.WriteLine("Por favor, seleccione una poción válida.");
                    continue;
                }
                PocionData.Pociones[seleccionPocion].MostrarPocion();
                Console.WriteLine("¿Es correcto? (S/N)");
                string confirmacion = Console.ReadLine();
                if (confirmacion.ToUpper() == "S")
                {
                    Pocion pocionElegida = PocionData.Pociones[seleccionPocion];
                    Console.WriteLine($"¡Has comprado una {pocionElegida.Nombre}!");
                    entrenador.agregarPocion(pocionElegida);
                    Console.WriteLine($"Ahora tienes {entrenador.Pociones.Count} pociones en tu inventario.");
                }
                else if (confirmacion.ToUpper() == "N")
                {
                    Console.WriteLine("¡Intenta de nuevo!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                    continue;
                }
            }
        }
    }
}