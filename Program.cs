using System.Data.Common;
using Pokedex;
using Pokedex.Controllers;
using Pokedex.Models;
using Pokedex.Data;
using Pokedex.Views;
using Pokedex.Utils;
using System.Text;
/*
Tarea 1:

1. Crear una variable para guardar al entrenador
2. Mostrar mensaje de bienvenida + el nombre del entrenador
using System.Runtime.CompilerServices;
string nombreEntrenador = "Default";
*/

// SE CREA EL ENTRENADOR
Console.Clear();
Entrenador entrenador = new Entrenador();

// SELECCIONA EL NOMBRE DEL ENTRENADOR
EntrenadorController crearEntrenador = new EntrenadorController();
crearEntrenador.CrearEntrenador(entrenador);

// SELECCIONA EL POKEMON INICIAL
PokemonController elegirPokemon = new PokemonController();
elegirPokemon.pokemonInicial(entrenador);

while (true)
{
    ConsolaUtil.EsperaryLimpiar();
    Console.WriteLine("¿Qué te gustaría hacer?");
    Console.WriteLine("1. Ver mis Pokémones");
    Console.WriteLine("2. Explorar el mundo");
    Console.WriteLine("3. Ver mi inventario");
    Console.WriteLine("4. Salir del juego");

    int opcion = int.Parse(Console.ReadLine());

    if (opcion == 1)
    {
        while (true)
        {
            ConsolaUtil.LimpiarConsola();
            int opcionCambioNombre = 0;
            Console.WriteLine("Tus Pokémones:");
            foreach (var pokemon in entrenador.Equipo)
            {
                pokemon.MostrarEquipo();
            }
            Console.WriteLine("¿Desea cambiar el nombre de sus pokemones?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");
            try
            {
                opcionCambioNombre = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
                continue;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Por favor, selecciona una opción válida.");
                continue;
            }
            if (opcionCambioNombre == 1)
            {
                PokemonController.apodoPokemon(entrenador);
            }
            else if (opcionCambioNombre == 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida, intenta de nuevo.");
                continue;
            }
            PokemonController.apodoPokemon(entrenador);
            break;
        ConsolaUtil.EsperaryLimpiar();
        }
    }
    else if (opcion == 2)
    {
        Console.Clear();
        Console.WriteLine("Explorando el mundo...");
        ConsolaUtil.EsperaryLimpiar();

        if (new Random().NextDouble() < 0.5)
        {
            Console.WriteLine("¡Has encontrado un Pokémon salvaje!");
            var ListaPokemon = PokemonData.ListaPokemon();
            int pokemonAleatorio = new Random().Next(ListaPokemon.Count);
            Pokemon enemigo = ListaPokemon[pokemonAleatorio];
            PokemonView.VerPokemon(enemigo);
            enemigo.MostrarPokemon();
            ConsolaUtil.EsperaryLimpiar();
            while (true)
            {
                Console.WriteLine("Selecciona un Pokémon de tu equipo para luchar!");
                for (int i = 0; i < entrenador.Equipo.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {entrenador.Equipo[i].Nombre} ({entrenador.Equipo[i].Especie})");
                }
                try
                {
                    int seleccionPokemon = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionPokemon < 0 || seleccionPokemon >= entrenador.Equipo.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        BatallaController.BatallaPokemon(entrenador, entrenador.Equipo[seleccionPokemon], enemigo);
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Por favor, selecciona un Pokémon válido.");
                    continue;
                }
            }
        }
        else
        {
            Console.WriteLine("No has encontrado nada interesante en tu exploración...");
            ConsolaUtil.EsperaryLimpiar();
        }
    }
    else if (opcion == 3)
    {
        ConsolaUtil.LimpiarConsola();
        Console.WriteLine("Pociones:");
        foreach (var pocion in entrenador.Pociones)
        {
            pocion.MostrarPocion();
        }
        Console.WriteLine("PokeBolas:");
        foreach (var pokebola in entrenador.Pokebolas)
        {
            pokebola.MostrarPokebola();
        }
        Console.WriteLine("¿Le gustaria comprar más pociones o Pokebolas?");
        Console.WriteLine("1. Comprar Pociones");
        Console.WriteLine("2. Comprar Pokebolas");
        Console.WriteLine("3. No comprar");
        try
        {
            int opcionCompra = int.Parse(Console.ReadLine());

            if (opcionCompra == 1)
            {
                PocionController.comprarPocion(entrenador);
            }
            else if (opcionCompra == 2)
            {
                PokebolaController.comprarPokebola(entrenador);
            }
            else if (opcionCompra == 3)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                ConsolaUtil.EsperaryLimpiar();
            }  
        }
        catch (FormatException)
        {
            Console.WriteLine("Por favor, ingresa un número válido.");
            continue;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Por favor, selecciona una opción válida.");
            continue;
        }
    }
    else if (opcion == 4)
    {
        Console.WriteLine("¡Gracias por jugar!");
        break;
    }
    else
    {
        Console.WriteLine("Opción no válida, intenta de nuevo.");
    }
}