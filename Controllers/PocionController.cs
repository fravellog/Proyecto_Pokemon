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
            while (true)
            {
                ConsolaUtil.LimpiarConsola();
                AsciiView.Textos(7);
                ConsolaUtil.escribir("¡Bienvenido a la tienda de pociones!\n");
                ConsolaUtil.escribir("En esta seccion puede seleccionar la pocion que desea almacenar (MAX. 3)!\n\n");
                ConsolaUtil.escribir("1. Pocion\n");
                ConsolaUtil.escribir("2. Super Pocion\n");
                ConsolaUtil.escribir("3. Ultra Pocion\n");
                ConsolaUtil.escribir("4. Maxima Pocion\n");
                ConsolaUtil.escribir("5. Salir de la tienda\n");
                ConsolaUtil.escribir("¡Selecciona el número de la poción que deseas comprar!:\n\n");
                int seleccionPocion = -1;
                try
                {
                    seleccionPocion = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPocion < 0 || seleccionPocion > PocionData.Pociones.Count - 1)
                    {
                        if (seleccionPocion == 4)
                        {
                            ConsolaUtil.LimpiarConsola();
                            ConsolaUtil.escribir("¡Gracias por visitar la tienda de pociones!\n");
                            ConsolaUtil.EsperaryLimpiar();
                            break;
                        }
                        ConsolaUtil.escribir("Por favor, seleccione una poción válida.\n");
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
                ConsolaUtil.LimpiarConsola();
                PocionData.Pociones[seleccionPocion].MostrarPocion();
                ConsolaUtil.escribir("¿Es correcto? (S/N)\n");
                string confirmacion = Console.ReadLine();
                if (confirmacion.ToUpper() == "S" && entrenador.Pociones.Count < 3)
                {
                    ConsolaUtil.LimpiarConsola();
                    Pocion pocionElegida = PocionData.Pociones[seleccionPocion];
                    ConsolaUtil.escribir($"¡Has comprado una {pocionElegida.Nombre}!\n");
                    entrenador.agregarPocion(pocionElegida);
                    ConsolaUtil.escribir($"Ahora tienes {entrenador.Pociones.Count} pociones en tu inventario.\n");
                    ConsolaUtil.EsperaryLimpiar();
                }
                else if (confirmacion.ToUpper() == "N")
                {
                    ConsolaUtil.LimpiarConsola();
                    ConsolaUtil.escribir("¡Intenta de nuevo!\n");
                    continue;
                }
                else if (confirmacion.ToUpper() == "S" && entrenador.Pociones.Count == 3)
                {
                    ConsolaUtil.LimpiarConsola();
                    ConsolaUtil.escribir("¡No puedes llevar mas pociones!\n");
                    ConsolaUtil.EsperaryLimpiar();
                    continue;
                }
                else
                {
                    ConsolaUtil.LimpiarConsola();
                    ConsolaUtil.escribir("Opción no válida, por favor intente de nuevo.\n");
                    continue;
                }
            }
        }
    }
}