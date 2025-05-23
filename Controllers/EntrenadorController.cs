using Pokedex.Models;
using Pokedex.Utils;
using Pokedex.Views;

namespace Pokedex.Controllers
{
    public class EntrenadorController
    {
        public void CrearEntrenador()
        {
            AsciiView.Textos(1);
            Console.WriteLine("¡Ingrese su nombre de entrenador!:");
            Console.WriteLine("");
            string nombre = string.Empty;
            while (true)
            {
                Console.WriteLine("Recuerda que el nombre no puede estar vacío.");
                nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    break;
                }
                Console.WriteLine("El nombre no puede estar vacío. Inténtalo de nuevo.");
            }

            ConsolaUtil.EsperaryLimpiar();
            Entrenador entrenador = new Entrenador(nombre);
            AsciiView.Textos(2);
            Console.WriteLine($"¡Bienvenido entrenador {nombre}!");
            ConsolaUtil.EsperaryLimpiar();
        }
    }
}