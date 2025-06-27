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
    ConsolaUtil.escribir("¿Qué te gustaría hacer?\n");
    ConsolaUtil.escribir("1. Ver mis Pokémones\n");
    ConsolaUtil.escribir("2. Explorar el mundo\n");
    ConsolaUtil.escribir("3. Ver mi inventario\n");
    ConsolaUtil.escribir("4. Salir del juego\n\n");

    int opcion = int.Parse(Console.ReadLine());

    if (opcion == 1)
    {
        while (true)
        {
            ConsolaUtil.LimpiarConsola();
            int opcionCambioNombre = 0;
            ConsolaUtil.escribir("Tus Pokémones:\n");
            foreach (var pokemon in entrenador.Equipo)
            {
                pokemon.MostrarEquipo();
            }
            ConsolaUtil.escribir("¿Desea cambiar el nombre de sus pokemones?\n");
            ConsolaUtil.escribir("1. Sí\n");
            ConsolaUtil.escribir("2. No\n\n");
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
                break;
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
        }
    }
    else if (opcion == 2)
    {
        Console.Clear();
        ConsolaUtil.escribir("Explorando el mundo...\n");
        ConsolaUtil.mostrarCarga();

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
                ConsolaUtil.escribir("Selecciona un Pokémon de tu equipo para luchar!\n");
                for (int i = 0; i < entrenador.Equipo.Count; i++)
                {
                    ConsolaUtil.escribir($"{i + 1}. {entrenador.Equipo[i].Nombre} ({entrenador.Equipo[i].Especie})\n");
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
            ConsolaUtil.escribir("No has encontrado nada interesante en tu exploración...\n");
            ConsolaUtil.EsperaryLimpiar();
        }
    }
    else if (opcion == 3)
    {
        ConsolaUtil.LimpiarConsola();
        ConsolaUtil.escribir("Pociones:\n");
        foreach (var pocion in entrenador.Pociones)
        {
            pocion.MostrarPocion();
        }
        ConsolaUtil.escribir("PokeBolas:\n");
        foreach (var pokebola in entrenador.Pokebolas)
        {
            pokebola.MostrarPokebola();
        }
        ConsolaUtil.escribir("¿Le gustaria comprar más pociones o Pokebolas?\n");
        ConsolaUtil.escribir("1. Comprar Pociones\n");
        ConsolaUtil.escribir("2. Comprar Pokebolas\n");
        ConsolaUtil.escribir("3. No comprar\n\n");
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
        ConsolaUtil.escribir("¡Gracias por jugar!\n");
        break;
    }
    else
    {
        Console.WriteLine("Opción no válida, intenta de nuevo.");
    }
}