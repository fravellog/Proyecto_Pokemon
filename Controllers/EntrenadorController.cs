using Pokedex.Models;
using Pokedex.Utils;
using Pokedex.Views;

namespace Pokedex.Controllers
{
    public class EntrenadorController
    {
        public void CrearEntrenador(Entrenador entrenador)
        {
            ConsolaUtil.LimpiarConsola();
            AsciiView.Textos(1);
            ConsolaUtil.escribir("¡Ingrese su nombre de entrenador!:\n\n");
            while (true)
            {
                ConsolaUtil.escribir("Recuerda que el nombre no puede estar vacío.\n");
                entrenador.Nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrenador.Nombre))
                {
                    break;
                }
                ConsolaUtil.escribir("El nombre no puede estar vacío. Inténtalo de nuevo.\n");
            }

            ConsolaUtil.EsperaryLimpiar();
            AsciiView.Textos(2);
            ConsolaUtil.escribir($"¡Bienvenido entrenador {entrenador.Nombre}!\n");
            ConsolaUtil.EsperaryLimpiar();
        }
    }
}