using Pokedex.Models;
using Pokedex.Utils;
using Pokedex.Views;

namespace Pokedex.Controllers
{
    public class EntrenadorController
    {
        public void CrearEntrenador(Entrenador entrenador)
        {
            AsciiView.Textos(1);
            Console.WriteLine("¡Ingrese su nombre de entrenador!:");
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Recuerda que el nombre no puede estar vacío.");
                entrenador.Nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrenador.Nombre))
                {
                    break;
                }
                Console.WriteLine("El nombre no puede estar vacío. Inténtalo de nuevo.");
            }

            ConsolaUtil.EsperaryLimpiar();
            AsciiView.Textos(2);
            Console.WriteLine($"¡Bienvenido entrenador {entrenador.Nombre}!");
            ConsolaUtil.EsperaryLimpiar();
        }
    }
}