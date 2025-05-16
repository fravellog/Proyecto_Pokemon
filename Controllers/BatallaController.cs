using Pokedex.Models;
using Pokedex.Views;
using Pokedex.Utils;
namespace Pokedex.Controllers
{
    public class BatallaController
    {

        public static void BatallaPokemon(Pokemon aliado, Pokemon enemigo)
        {
            //Presentacion de la batalla
            AsciiView.Textos(1);
            Console.WriteLine(@$"¡LA BATALLA HA COMENZADO!
            ¡{aliado.Nombre} VS {enemigo.Nombre}!");
            ConsolaUtil.EsperaryLimpiar();

            // Comienza el bucle de batalla
            while (aliado.HP > 0 && enemigo.HP > 0)
            {
                aliado.MostrarPokemon();
                Console.WriteLine("Elige un ataque:");
                Console.ReadLine();
                try
                {
                    int seleccion = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                
            }

        }
    }
}