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

