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
                Console.WriteLine("Selecciona un numero para elegir un ataque!");
                Console.WriteLine();
                for (int i = 0; i < aliado.Ataques.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {aliado.Ataques[i].Nombre}");
                }
                //Se crean dos variables para guardar el ataque del aliado y el ataque del enemigo
                int seleccionAtaque = -1;
                int seleccionAtaque2 = -1;
                try
                {
                    // Se selecciona el ataque del aliado
                    seleccionAtaque = int.Parse(Console.ReadLine()) - 1;

                    // Se selecciona el ataque del enemigo
                    seleccionAtaque2 = new Random().Next(0, enemigo.Ataques.Count);

                    // Se valida la seleccion del ataque
                    var aliadoAtaque = aliado.Ataques[seleccionAtaque];
                    var enemigoAtaque = enemigo.Ataques[seleccionAtaque2];
                }
                catch (FormatException)
                {
                    // Si la entrada no es un número, se muestra un mensaje de error
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Si el número está fuera de rango, se muestra un mensaje de error
                    Console.WriteLine("Por favor, seleccione un ataque válido.");
                    continue;
                }
                // Se calcula la potencia de los ataques
                double potenciaAliado = AtaquePotencia.CalcularPotencia(aliado, enemigo);
                double potenciaEnemigo = AtaquePotencia.CalcularPotencia(enemigo, aliado);

                // Se aplica la potencia a los ataques
                potenciaAliado *= aliado.Ataques[seleccionAtaque].Poder;
                potenciaEnemigo *= enemigo.Ataques[seleccionAtaque2].Poder;

                // Se aplica el daño a los Pokémon
                enemigo.HP -= potenciaAliado;
                aliado.HP -= potenciaEnemigo;
                Console.WriteLine($"{aliado.Nombre} ataca a {enemigo.Nombre} con {aliado.Ataques[seleccionAtaque].Nombre}!");
                Console.WriteLine($"{enemigo.Nombre} recibe {potenciaAliado} de daño!!");
                Console.WriteLine($"{enemigo.Nombre} ataca a {aliado.Nombre} con {enemigo.Ataques[seleccionAtaque2].Nombre}!");
                Console.WriteLine($"{aliado.Nombre} recibe {potenciaEnemigo} de daño!!");

                ConsolaUtil.EsperaryLimpiar();
            }



            ConsolaUtil.LimpiarConsola();
            // Fin de la batalla
            Console.WriteLine($"{aliado.Nombre} VS {enemigo.Nombre}");
            Console.WriteLine("¡La batalla ha terminado!");
            if (aliado.HP <= 0 && enemigo.HP <= 0)
            {
                Console.WriteLine("¡Ambos Pokémon han caído!");
            }
            else if (aliado.HP <= 0)
            {
                Console.WriteLine($"{enemigo.Nombre} ha ganado la batalla!, mejor suerte la proxima vez!");
            }
            else
            {
                Console.WriteLine($"{aliado.Nombre} ha ganado la batalla!, felicidades!");
            }

        }
    }
}