using Pokedex.Models;
using Pokedex.Views;
using Pokedex.Utils;
using Pokedex.Data;
using System.Text;
namespace Pokedex.Controllers
{
    public class BatallaController
    {
        public static void BatallaPokemon(Entrenador entrenador,Pokemon aliado, Pokemon enemigo)
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
                Console.WriteLine("Selecciona una opcion!");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Usar pocion");
                Console.WriteLine("3. Huir");
                Console.WriteLine("4. Capturar Pokemon");
                Console.WriteLine("");
                // Se captura la entrada del usuario y se valida
                int opcion = -1;

                // Se inicializan las variables de selección de ataque
                int seleccionAtaque = -1;
                int seleccionAtaque2 = -1;

                try
                {
                    // Se lee la opción del usuario
                    opcion = int.Parse(Console.ReadLine());
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
                    Console.WriteLine("Por favor, seleccione una opción válida.");
                    continue;
                }

                if (opcion == 1)
                {
                    AsciiView.Textos(5);
                    // Si el usuario elige atacar, se procede a seleccionar un ataque
                    Console.WriteLine("Selecciona un numero para elegir un ataque!");
                    Console.WriteLine();
                    for (int i = 0; i < aliado.Ataques.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {aliado.Ataques[i].Nombre}");
                        Console.WriteLine("");
                    }

                    try
                    {
                        // Se selecciona el ataque del aliado
                        seleccionAtaque = int.Parse(Console.ReadLine()) - 1;

                        // Se valida la seleccion del ataque
                        var aliadoAtaque = aliado.Ataques[seleccionAtaque];
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

                    // Se aplica la potencia a los ataques
                    potenciaAliado *= aliado.Ataques[seleccionAtaque].Poder;

                    // Se aplica el daño a los Pokémon
                    enemigo.HP -= potenciaAliado;
                    AtaqueView.AtaqueVista(aliado.Ataques[seleccionAtaque]);
                    Console.WriteLine($"{aliado.Nombre} ataca a {enemigo.Nombre} con {aliado.Ataques[seleccionAtaque].Nombre}!");
                    Console.WriteLine($"{enemigo.Nombre} recibe {potenciaAliado} de daño!!");
                    ConsolaUtil.EsperaryLimpiar();
                }
                else if (opcion == 2)
                {
                    AsciiView.Textos(6);
                    // Si el usuario elige usar una poción, se muestra la lista de pociones
                    Console.WriteLine("Selecciona una pocion!");
                    Console.WriteLine();
                    for (int i = 0; i < PocionData.Pociones.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {PocionData.Pociones[i].Nombre} - {PocionData.Pociones[i].TipoEfecto}");
                        Console.WriteLine("");
                    }

                    try
                    {
                        // Se selecciona la poción
                        int seleccionPocion = int.Parse(Console.ReadLine()) - 1;

                        // Se valida la selección de la poción
                        var pocionSeleccionada = PocionData.Pociones[seleccionPocion];
                        aliado.HP += pocionSeleccionada.Efecto;
                        Console.WriteLine($"{aliado.Nombre} ha usado {pocionSeleccionada.Nombre} y ha recuperado {pocionSeleccionada.Efecto} puntos de vida!");
                        entrenador.Pociones.Remove(pocionSeleccionada);
                        Console.WriteLine($"Pociones restantes: {entrenador.Pociones.Count}");
                        ConsolaUtil.EsperaryLimpiar();
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
                        Console.WriteLine("Por favor, seleccione una poción válida.");
                        continue;
                    }
                }
                else if (opcion == 3)
                {
                    // Si el usuario elige huir, se termina la batalla
                    // 50% de probabilidad de escapar
                    if (new Random().NextDouble() < 0.5)
                    {
                        Console.WriteLine($"{aliado.Nombre} ha huido de la batalla exitosamente!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"{aliado.Nombre} intentó huir, pero no lo logró!");
                        ConsolaUtil.EsperaryLimpiar();
                        // La batalla continúa
                        continue;
                    }
                }
                else if (opcion == 4)
                {
                    // El usuario elige capturar al Pokémon enemigo
                    AsciiView.Textos(7);
                    Console.WriteLine($"¡{entrenador.Nombre} está intentando capturar a {enemigo.Nombre}!");
                    // Se elige una Pokébola
                    if (entrenador.Pokebolas.Count == 0)
                    {
                        Console.WriteLine("No tienes Pokébolas para capturar Pokémon.");
                        continue;
                    } else
                    {
                        Console.WriteLine("Selecciona una Pokébola para capturar:");
                        for (int i = 0; i < entrenador.Pokebolas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {entrenador.Pokebolas[i].Nombre} - Tipo: {entrenador.Pokebolas[i].Tipo} - Efecto de captura: {entrenador.Pokebolas[i].EfectoCaptura}");
                        }

                        int seleccionPokebola = -1;
                        try
                        {
                            seleccionPokebola = int.Parse(Console.ReadLine()) - 1;
                            var pokebolaSeleccionada = entrenador.Pokebolas[seleccionPokebola];
                            if (new Random().Next(0, 250) < pokebolaSeleccionada.EfectoCaptura)
                            {
                                Console.WriteLine($"¡{entrenador.Nombre} ha capturado a {enemigo.Nombre} con {pokebolaSeleccionada.Nombre}!");
                                entrenador.Equipo.Add(enemigo);
                                return; // Termina la batalla si se captura al Pokémon
                            }
                            else
                            {
                                Console.WriteLine($"¡{entrenador.Nombre} ha fallado al capturar a {enemigo.Nombre}!");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor, ingrese un número válido.");
                            continue;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Por favor, seleccione una Pokébola válida.");
                            continue;
                        }
                    }
                }
                else
                {
                    // Si la opción no es válida, se muestra un mensaje de error
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    continue;
                }


                // Se selecciona el ataque del enemigo
                    seleccionAtaque2 = new Random().Next(0, enemigo.Ataques.Count);
                var enemigoAtaque = enemigo.Ataques[seleccionAtaque2];
                double potenciaEnemigo = AtaquePotencia.CalcularPotencia(enemigo, aliado);
                potenciaEnemigo *= enemigo.Ataques[seleccionAtaque2].Poder;
                aliado.HP -= potenciaEnemigo;
                AtaqueView.AtaqueVista(enemigo.Ataques[seleccionAtaque2]);
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