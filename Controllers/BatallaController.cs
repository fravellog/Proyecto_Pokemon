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
            // Se muestra un mensaje de carga y se limpia la consola
            ConsolaUtil.mostrarCarga();
            ConsolaUtil.LimpiarConsola();
            //Seleccionar Pokemon antes de la batalla
            //Presentacion de la batalla
            AsciiView.Textos(5);
            ConsolaUtil.escribir($"¡LA BATALLA HA COMENZADO!\n");
            ConsolaUtil.escribir($"¡{aliado.Nombre} VS {enemigo.Nombre}!\n");
            ConsolaUtil.EsperaryLimpiar();

            // Comienza el bucle de batalla
            while (aliado.HP > 0 && enemigo.HP > 0)
            {
                // Se muestra el estado de los Pokémon
                ConsolaUtil.LimpiarConsola();
                ConsolaUtil.escribir($"{aliado.Nombre}\n");
                ConsolaUtil.escribir($"HP: {aliado.HP}\n\n");
                ConsolaUtil.escribir($"{enemigo.Nombre}\n");
                ConsolaUtil.escribir($"HP: {enemigo.HP}\n\n");
                // Se muestran las opciones de acción al usuario
                ConsolaUtil.escribir("Elige el numero de la accion!\n");
                ConsolaUtil.escribir("1. Atacar\n");
                ConsolaUtil.escribir("2. Usar pocion\n");
                ConsolaUtil.escribir("3. Huir\n");
                ConsolaUtil.escribir("4. Capturar Pokemon\n\n");
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
                    ConsolaUtil.EsperaryLimpiar();
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Si el número está fuera de rango, se muestra un mensaje de error
                    Console.WriteLine("Por favor, seleccione una opción válida.");
                    ConsolaUtil.EsperaryLimpiar();
                    continue;
                }

                if (opcion == 1)
                {
                    ConsolaUtil.LimpiarConsola();
                    AsciiView.Textos(6);
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
                        ConsolaUtil.EsperaryLimpiar();
                        continue;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // Si el número está fuera de rango, se muestra un mensaje de error
                        Console.WriteLine("Por favor, seleccione un ataque válido.");
                        ConsolaUtil.EsperaryLimpiar();
                        continue;
                    }
                    // Se calcula la potencia de los ataques
                    double potenciaAliado = AtaquePotencia.CalcularPotencia(aliado, enemigo);

                    // Se aplica la potencia a los ataques
                    potenciaAliado *= aliado.Ataques[seleccionAtaque].Poder;

                    // Se aplica el daño a los Pokémon
                    enemigo.HP -= potenciaAliado;
                    Console.WriteLine($"{aliado.Nombre} ataca a {enemigo.Nombre} con {aliado.Ataques[seleccionAtaque].Nombre}!");
                    Console.WriteLine($"{enemigo.Nombre} recibe {potenciaAliado} de daño!!");
                    AtaqueView.AtaqueVista(aliado.Ataques[seleccionAtaque]);
                    ConsolaUtil.EsperaryLimpiar();
                }
                else if (opcion == 2)
                {
                    if (entrenador.Pociones.Count == 0)
                    {
                        // Si el entrenador no tiene pociones, se muestra un mensaje
                        ConsolaUtil.escribir("No tienes pociones para usar!\n");
                        ConsolaUtil.EsperaryLimpiar();
                        continue;
                    }
                    else
                    {
                        ConsolaUtil.LimpiarConsola();
                        AsciiView.Textos(6);
                        // Si el usuario elige usar una poción, se muestra la lista de pociones
                        for (int i = 0; i < entrenador.Pociones.Count; i++)
                        {
                            ConsolaUtil.escribir($"{i + 1}. {entrenador.Pociones[i].Nombre} - Efecto: {entrenador.Pociones[i].Efecto}\n");
                        }
                        ConsolaUtil.escribir("Selecciona una pocion!\n");
                        try
                        {
                            // Se selecciona la poción
                            int seleccionPocion = int.Parse(Console.ReadLine()) - 1;

                            // Se valida la selección de la poción
                            var pocionSeleccionada = entrenador.Pociones[seleccionPocion];
                            object locker = new object();
                            Thread curacion = new Thread(() =>
                            {
                                ConsolaUtil.escribir($"Curando a {aliado.Nombre}...\n");
                                lock (locker)
                                {
                                    // Simula el tiempo de curación
                                    for (int i = 0; i < pocionSeleccionada.Efecto; i++)
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        aliado.HP += 1; 
                                        Console.Write($"Salud actual: {aliado.HP}");
                                        Thread.Sleep(500);
                                    }
                                }
                            });
                            ConsolaUtil.escribir($"{aliado.Nombre} ha usado {pocionSeleccionada.Nombre} y ha recuperado {pocionSeleccionada.Efecto} puntos de vida!\n");
                            entrenador.Pociones.Remove(pocionSeleccionada);
                            ConsolaUtil.escribir($"Pociones restantes: {entrenador.Pociones.Count}\n");
                            curacion.Start();
                            ConsolaUtil.EsperaryLimpiar();
                        }
                        catch (FormatException)
                        {
                            // Si la entrada no es un número, se muestra un mensaje de error
                            Console.WriteLine("Por favor, ingrese un número válido.");
                            ConsolaUtil.EsperaryLimpiar();
                            continue;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            // Si el número está fuera de rango, se muestra un mensaje de error
                            Console.WriteLine("Por favor, seleccione una poción válida.");
                            ConsolaUtil.EsperaryLimpiar();
                            continue;
                        }
                    }
                }
                else if (opcion == 3)
                {
                    // Si el usuario elige huir, se termina la batalla
                    // 50% de probabilidad de escapar
                    if (new Random().NextDouble() < 0.5)
                    {
                        ConsolaUtil.escribir($"{aliado.Nombre} ha huido de la batalla exitosamente!\n");
                        ConsolaUtil.EsperaryLimpiar();
                        return;
                    }
                    else
                    {
                        ConsolaUtil.escribir($"{aliado.Nombre} intentó huir, pero no lo logró!\n");
                        ConsolaUtil.EsperaryLimpiar();
                        // La batalla continúa
                    }
                }
                else if (opcion == 4)
                {
                    ConsolaUtil.LimpiarConsola();
                    // El usuario elige capturar al Pokémon enemigo
                    AsciiView.Textos(7);
                    ConsolaUtil.escribir($"¡{entrenador.Nombre} está intentando capturar a {enemigo.Nombre}!\n");
                    // Se elige una Pokébola
                    if (entrenador.Pokebolas.Count == 0)
                    {
                        ConsolaUtil.escribir("No tienes Pokébolas para capturar Pokémon.\n");
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < entrenador.Pokebolas.Count; i++)
                        {
                            ConsolaUtil.escribir($"{i + 1}. {entrenador.Pokebolas[i].Nombre} - Tipo: {entrenador.Pokebolas[i].Tipo} - Efecto de captura: {entrenador.Pokebolas[i].EfectoCaptura}\n");
                        }
                        ConsolaUtil.escribir("¡Selecciona una Pokébola para capturar!\n\n");
                        int seleccionPokebola = -1;
                        try
                        {
                            seleccionPokebola = int.Parse(Console.ReadLine()) - 1;
                            var pokebolaSeleccionada = entrenador.Pokebolas[seleccionPokebola];
                            if (new Random().Next(0, 250) < pokebolaSeleccionada.EfectoCaptura)
                            {
                                PokemonView.VerPokemon(enemigo);
                                ConsolaUtil.escribir($"¡{entrenador.Nombre} ha capturado a {enemigo.Nombre} con {pokebolaSeleccionada.Nombre}!\n");
                                entrenador.Equipo.Add(enemigo);
                                ConsolaUtil.EsperaryLimpiar();
                                return; // Termina la batalla si se captura al Pokémon
                            }
                            else
                            {
                                ConsolaUtil.escribir($"¡{entrenador.Nombre} ha fallado al capturar a {enemigo.Nombre}!\n");
                                ConsolaUtil.EsperaryLimpiar();
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
                    ConsolaUtil.LimpiarConsola();
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
                ConsolaUtil.escribir($"{enemigo.Nombre} ataca a {aliado.Nombre} con {enemigo.Ataques[seleccionAtaque2].Nombre}!\n");
                ConsolaUtil.escribir($"{aliado.Nombre} recibe {potenciaEnemigo} de daño!!\n");
                AtaqueView.AtaqueVista(enemigo.Ataques[seleccionAtaque2]);
                ConsolaUtil.EsperaryLimpiar();
            }



            ConsolaUtil.LimpiarConsola();
            // Fin de la batalla
            Console.WriteLine($"{aliado.Nombre} VS {enemigo.Nombre}");
            Console.WriteLine("¡La batalla ha terminado!");
            ConsolaUtil.EsperaryLimpiar();
            if (aliado.HP <= 0 && enemigo.HP <= 0)
            {
                Console.WriteLine("¡Ambos Pokémon han caído!");
                ConsolaUtil.EsperaryLimpiar();
            }
            else if (aliado.HP <= 0)
            {
                Console.WriteLine($"{enemigo.Nombre} ha ganado la batalla!, mejor suerte la proxima vez!");
                ConsolaUtil.EsperaryLimpiar();
            }
            else
            {
                AsciiView.Textos(8);
                Console.WriteLine($"{aliado.Nombre} ha ganado la batalla!, felicidades!");
                ConsolaUtil.EsperaryLimpiar();
            }

        }
    }
}