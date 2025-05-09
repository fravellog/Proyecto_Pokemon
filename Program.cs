using System.Data.Common;
using Pokedex;
/*
Tarea 1:

1. Crear una variable para guardar al entrenador
2. Mostrar mensaje de bienvenida + el nombre del entrenador
using System.Runtime.CompilerServices;
string nombreEntrenador = "Default";
*/

//CREACION DE OBJETOS
Console.Clear();
Pokemon arceus = new Pokemon();

arceus.Nombre = "Arceus";
arceus.HP = 1000;
arceus.Tipo = "normal";
arceus.agregarAtaque("CASTIGO");
arceus.agregarAtaque("canto mortal");

Pokemon charmander = new Pokemon();

charmander.Nombre = "";
charmander.HP = 100;
charmander.Tipo = "fuego";
charmander.agregarAtaque("lanzallama");
charmander.agregarAtaque("cuchillada");

Pokemon squirtle = new Pokemon();

squirtle.Nombre = "";
squirtle.HP = 100;
squirtle.Tipo = "agua";
squirtle.agregarAtaque("pistola agua");
squirtle.agregarAtaque("latigo");

Pokemon bulbasaur = new Pokemon();

bulbasaur.Nombre = "";
bulbasaur.HP = 100;
bulbasaur.Tipo = "planta";
bulbasaur.agregarAtaque("latigo cepa");
bulbasaur.agregarAtaque("placaje");

string nombreEntrenador = "";
Entrenador entrenador = new Entrenador();

int pociones = 5;
int pokebolas = 5;
void luchaPokemon (Pokemon pokemon1, Pokemon pokemon2) {
    Console.Clear();
    Console.WriteLine(@$"¿Listo para la accion?
    ⠀⠀⠀⠀⠀⢀⣠⣤⣶⣶⣿⣿⣿⣿⣿⣶⣶⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣠⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀
⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⠙⣿⣿⣿⣿⣿⣆⠀⠀
⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⢿⣧⡀⠀⢠⣿⠟⠛⠛⠿⣿⡆⠀
⠀⢰⣿⣿⣿⣿⣿⣿⠿⠟⠋⠉⠁⠀⠀⠀⠀⠀⠙⠿⠿⠟⠋⠀⠀⠀⣠⣿⠇⠀
⠀⢸⣿⣿⡿⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣾⠟⠋⠀⠀
⠀⢸⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣴⣾⠿⠛⠉⠀⠀⠀⠀⠀
⠀⠈⢿⣷⣤⣤⣄⣠⣤⣤⣤⣤⣶⣶⣾⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣄⠀⠀⠀⠀
⠀⢸⣿⡛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀
⠀⠀⢻⣧⠀⠈⠙⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀
⠀⠀⠈⢿⣧⠀⠀⠀⠀⠀⠀⠉⠙⠛⠻⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀
⠀⠀⠀⠀⠻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⠟⠀⣠⣾⠟⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠻⣷⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⢀⣤⣾⠟⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⠿⣶⣦⣤⣤⣤⣤⣤⣤⣶⡿⠟⠋⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    A LUCHAR, {pokemon1.Nombre} VS {pokemon2.Nombre}!!!");
    Console.ReadKey();

    int elegirAccion = 0; 
    while (pokemon1.HP > 0 && pokemon2.HP > 0) {
        Random random = new Random();
        Console.Clear();
        Console.WriteLine(@$"
        HP: {pokemon1.HP}
        HP Enemigo: {pokemon2.HP}

        Pociones: {pociones}
        Pokebolas: {pokebolas}
        
        Selecciona una opcion!");
        int contador = 0;
        for (int i = 0; i < pokemon1.Ataques.Count; i++) {
            Console.WriteLine($"{contador+=1}. {pokemon1.Ataques[i]}");
            Console.WriteLine();
            
        }
        Console.WriteLine("3. Pocion");
        Console.WriteLine();
        Console.WriteLine("4. Capturar");
        if (entrenador.Equipo.Count > 1) {
            Console.WriteLine("");
            Console.WriteLine("5. Cambiar pokemon");
        } else

        if (pokemon1.HP < 50) {
            Console.WriteLine();
            Console.WriteLine("6. Huir");
        }
        try {
            elegirAccion = int.Parse(Console.ReadLine());
        } catch (FormatException) {
            Console.Clear();
            Console.WriteLine("No has elegido ningun ataque, intentalo de nuevo!");
            Console.ReadKey();
        }

        if (elegirAccion == 1) {

            elegirAccion -= 1;
            Console.Clear();
            Console.WriteLine($"has usado {pokemon1.Ataques[elegirAccion]}!");
            Console.ReadKey();

            if (pokemon1.Ataques[elegirAccion] == "lanzallama" && pokemon2.Tipo == "planta") {
                Console.WriteLine(@"
    ⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣆⢳⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣾⣷⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠠⣄⠀⢠⣿⣿⣿⣿⡎⢻⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣧⢸⣿⣿⣿⣿⡇⠀⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣾⣿⣿⣿⣿⠃⠀⢸⣿⣿⣿⣿⣿⣿⠀⣄⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⣿⣿⣿⣿⠏⠀⠀⣸⣿⣿⣿⣿⣿⡿⢀⣿⡆⠀
⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⣿⣿⣿⣿⣿⣿⠇⣼⣿⣿⡄
⠀⢰⠀⠀⣴⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀⠀⢠⣿⣿⣿⣿⣿⡟⣼⣿⣿⣿⣧
⠀⣿⡀⢸⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⣸⡿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿
⠀⣿⣷⣼⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⢹⠃⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿
⡄⢻⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⠇
⢳⣌⢿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⠏⠀
⠀⢿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⠋⣠⠀
⠀⠈⢻⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣵⣿⠃⠀
⠀⠀⠀⠙⢿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⡿⠃⠀⠀
⠀⠀⠀⠀⠀⠙⢿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⡿⠋⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣿⣦⣀⠀⠀⠀⠀⢀⣴⠿⠛⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠓⠂⠀⠈⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            
            ¡ES SUPER EFECTIVO!");
                pokemon2.HP -= 20;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "pistola agua" && pokemon2.Tipo == "fuego") {
                Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠃⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡆⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣆⡀⠙⠻⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⠶⠶⠾⠿⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠃⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡆⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣆⡀⠙⠻⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⠶⠶⠾⠿⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ¡ES SUPER EFECTIVO!");
                pokemon2.HP -= 20;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "latigo cepa" && pokemon2.Tipo == "agua") {
                Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣤⣄⣀⣀⡀⠀⠀⠀    
⠀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠶
⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀
⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀
⢀⣠⠞⠋⠉⠛⠻⠿⣿⣿⣿⠿⠟⠋⠀⠀⠀⠀⠀
⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣤⣄⣀⣀⡀⠀⠀⠀
        ⠀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠶
        ⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀
        ⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀
        ⢀⣠⠞⠋⠉⠛⠻⠿⣿⣿⣿⠿⠟⠋⠀⠀⠀⠀⠀
        ⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            
            ¡ES SUPER EFECTIVO!");
                pokemon2.HP -= 20;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "lanzallama" && pokemon2.Tipo == "agua" || pokemon2.Tipo == "normal") {
                Console.WriteLine("No es muy efectivo!");
                pokemon2.HP -= 5;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "latigo cepa" && pokemon2.Tipo == "fuego" || pokemon2.Tipo == "normal") {
                Console.WriteLine("No es muy efectivo!");
                pokemon2.HP -= 5;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "pistola agua" && pokemon2.Tipo == "planta" || pokemon2.Tipo == "normal") {
                Console.WriteLine("No es muy efectivo!");
                pokemon2.HP -= 5;
                Console.ReadKey();
            }
        } else if (elegirAccion == 2) {
            elegirAccion -= 1;
            Console.Clear();
            Console.WriteLine($"has usado {pokemon1.Ataques[elegirAccion]}!");
            Console.ReadKey();
            if (pokemon1.Ataques[elegirAccion] == "cuchillada") {
                Console.WriteLine("Es efectivo!");
                pokemon2.HP -= 10;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "latigo") {
                Console.WriteLine("Es efectivo!!");
                pokemon2.HP -= 10;
                Console.ReadKey();
            } else if (pokemon1.Ataques[elegirAccion] == "placaje") {
                Console.WriteLine("Es efectivo!!");
                pokemon2.HP -= 10;
                Console.ReadKey();
            }

        } else if (elegirAccion == 3) {
            if (pociones > 0) {
                Console.Clear();
                Console.WriteLine("Has utilizado una pocion de curacion!");
                pokemon1.HP += 30;
                pociones -= 1;
                Console.ReadKey();
            } else {
                Console.Clear();
                Console.WriteLine("Has utilizado todas las pociones, no puedes volver a usarlas!");
                Console.ReadKey();
            }
        } else if (elegirAccion == 4) {
            Console.Clear();
            Console.WriteLine($"Has lanzado una pokebola hacia {pokemon2.Nombre}!");
            double captura = random.NextDouble();
            if (captura < 0.5) {
                Console.WriteLine("Felicidades!, has podido capturarlo!");
                entrenador.agregarPokemon(pokemon2);
                Console.ReadKey();
                pokebolas -= 1;
                break;
            } else {
                Console.WriteLine($"{pokemon2.Nombre} Escapo de la pokebola!");
                pokebolas -= 1;
                Console.ReadKey();
            }
        
        } else if (elegirAccion == 5 && entrenador.Equipo.Count > 1) {
            while (true) {
                Console.Clear();
                Console.WriteLine(@"Has decicido cambiar de pokemon!");
                double escape = random.NextDouble();
                int contadorEquipo = 0;
                int cambiarPokemon = 0;
                for (int i = 0; i < entrenador.Equipo.Count; i++) {
                    Console.WriteLine($"{contadorEquipo+=1} {entrenador.Equipo[i].Nombre}");
                    Console.WriteLine();
                }
                try {
                    cambiarPokemon = int.Parse(Console.ReadLine());
                    cambiarPokemon -= 1;
                } catch (FormatException) {
                    Console.WriteLine("No has elegido ninguna de las opciones, vuelve a intentarlo!");
                    Console.ReadKey();
                }

                if (cambiarPokemon > entrenador.Equipo.Count || cambiarPokemon < 0 || cambiarPokemon == null) {
                    Console.WriteLine("No has elegido ninguna de las opciones, vuelve a intentarlo!");
                } else {
                    pokemon1 = entrenador.Equipo[cambiarPokemon];
                    Console.WriteLine($"¡Cambiaste de pokemon, estas usando a {entrenador.Equipo[cambiarPokemon].Nombre}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
            

        } else if (elegirAccion == 6 && pokemon1.HP < 50) {
            Console.Clear();
            Console.WriteLine($"Has decidido intentar huir!");
            Console.ReadKey();
            double escape = random.NextDouble();
                if (escape < 0.5) {
                    Console.WriteLine($"{pokemon2.Nombre} te dejo escapar!");
                    Console.ReadKey();
                    break;
                } else {
                    Console.WriteLine($"{pokemon2.Nombre} no te permitio escapar!");
                    Console.ReadKey();
                }
        }
        
        int ataqueEnemigo = random.Next(pokemon2.Ataques.Count);
        Console.WriteLine($"{pokemon2.Nombre} utilizo {pokemon2.Ataques[ataqueEnemigo]}!");
        Console.ReadKey();

        //ATAQUES DEL POKEMON SALVAJE
        if (pokemon2.Ataques[ataqueEnemigo] == "CASTIGO" || pokemon2.Ataques[ataqueEnemigo] == "canto mortal") {
            Console.WriteLine(@"
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⡀⢀⠀⢠⠀⠀⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢠⢤⣀⠀⠀⠀⠈⣆⢧⠈⡆⢸⠀⠀⠀⢰⢡⠇⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀
⠀⠀⠀⢀⠀⠀⣯⢀⣨⠃⠀⠀⠀⠸⡜⣄⣣⢸⠀⠀⠀⡜⡌⠀⠀⠀⠀⢀⡜⡁⠀⠀⠀⠀⠀
⠀⠀⠙⢮⡳⢄⠈⠁⠀⢠⠴⠍⣛⣚⣣⢳⢽⡀⣏⣲⣀⢧⡥⠤⠶⢤⣠⢎⠜⠁⠀⠀⠀⠀⠀
⠀⠠⣀⠀⠙⢦⡑⢄⢀⣾⣧⡎⠁⠀⠙⡎⡇⡇⡇⠹⢪⣀⡓⣦⢀⣼⣵⠋⢀⠴⣊⠔⠁⠀⠀
⠀⠀⠈⠑⢦⣀⠙⣲⣝⢭⡚⠃⠀⠀⠀⠸⠸⣹⠁⠀⠀⠀⠉⣹⣪⣎⡸⢞⡵⠊⠁⣀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⣷⢯⣨⠷⣝⠦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠵⣪⢶⣙⡤⠖⢉⣀⠤⠖⠂
⠀⠀⠀⠀⠀⢀⡞⢠⠾⠓⢮⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢬⣺⡯⢕⢲⠉⣥⣀⡀⠀⠀
⠀⠀⢀⡤⣀⢈⡷⠻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠘⠀⢱⢾⠘⢇⢴⠁⠀⠀
⠀⠀⢻⣀⡼⢘⣧⢀⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⢙⣞⠆⠀⠀⠀⠀⠀
⠀⠀⠀⠉⠀⢿⡀⠈⠧⡤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠇⣹⣦⠇⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠸⢤⡴⢺⡧⣴⡶⢗⡣⠀⡀⠀⠀⠀⡄⠀⢀⣄⠢⣔⡞⣤⠦⡇⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣀⡤⣖⣯⡗⣪⢽⡻⣅⠀⣜⡜⠀⠀⠀⠸⡜⡌⣮⡣⡙⢗⢏⡽⠁⠰⡏⠙⡆⠀⠀
⠀⠀⣒⡭⠖⣋⡥⣞⣿⡚⠉⠉⢉⢟⣞⣀⣀⣀⠐⢦⢵⠹⡍⢳⡝⢮⡷⢝⢦⡀⠉⠙⠁⠀⠀
⠐⠊⢡⠴⠚⠕⠋⠹⣍⡉⠹⢧⢫⢯⣀⣄⣀⠈⣹⢯⣀⣧⢹⡉⠙⢦⠙⣄⠑⢌⠲⣄⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠘⠧⡴⣳⣃⣸⠦⠴⠖⢾⣥⠞⠛⠘⣆⢳⡀⠈⠳⡈⠳⡄⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⡜⡱⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡄⢣⠀⠀⠉⠀⠈⠂⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⠞⡼⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡀⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ¡ES SUPER EFECTIVO!");
            pokemon1.HP -= 40;
            Console.ReadKey();
        }
        
        //ATAQUES DE PRIMEROS ENEMIGOS POKEMON
        if (pokemon2.Ataques[ataqueEnemigo] == "lanzallama" && pokemon1.Tipo == "planta") {
            Console.WriteLine(@"
    ⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣆⢳⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣾⣷⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠠⣄⠀⢠⣿⣿⣿⣿⡎⢻⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣧⢸⣿⣿⣿⣿⡇⠀⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣾⣿⣿⣿⣿⠃⠀⢸⣿⣿⣿⣿⣿⣿⠀⣄⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⣿⣿⣿⣿⠏⠀⠀⣸⣿⣿⣿⣿⣿⡿⢀⣿⡆⠀
⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⣿⣿⣿⣿⣿⣿⠇⣼⣿⣿⡄
⠀⢰⠀⠀⣴⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀⠀⢠⣿⣿⣿⣿⣿⡟⣼⣿⣿⣿⣧
⠀⣿⡀⢸⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⣸⡿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿
⠀⣿⣷⣼⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⢹⠃⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿
⡄⢻⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⠇
⢳⣌⢿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⠏⠀
⠀⢿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⠋⣠⠀
⠀⠈⢻⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣵⣿⠃⠀
⠀⠀⠀⠙⢿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⡿⠃⠀⠀
⠀⠀⠀⠀⠀⠙⢿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⡿⠋⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣿⣦⣀⠀⠀⠀⠀⢀⣴⠿⠛⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠓⠂⠀⠈⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            
            ¡ES SUPER EFECTIVO!");
            pokemon1.HP -= 20;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "pistola agua" && pokemon1.Tipo == "fuego") {
            Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠃⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡆⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣆⡀⠙⠻⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⠶⠶⠾⠿⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠃⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡆⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣆⡀⠙⠻⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⠶⠶⠾⠿⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ¡ES SUPER EFECTIVO!");
            pokemon1.HP -= 20;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "latigo cepa" && pokemon1.Tipo == "agua") {
            Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣤⣄⣀⣀⡀⠀⠀⠀    
⠀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠶
⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀
⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀
⢀⣠⠞⠋⠉⠛⠻⠿⣿⣿⣿⠿⠟⠋⠀⠀⠀⠀⠀
⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣤⣄⣀⣀⡀⠀⠀⠀
        ⠀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠶
        ⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀
        ⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀
        ⢀⣠⠞⠋⠉⠛⠻⠿⣿⣿⣿⠿⠟⠋⠀⠀⠀⠀⠀
        ⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            
            ES SUPER EFECTIVO!");
            pokemon1.HP -= 20;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "lanzallama" && pokemon1.Tipo == "agua") {
            Console.WriteLine("No es muy efectivo!");
            pokemon1.HP -= 5;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "latigo cepa" && pokemon1.Tipo == "fuego") {
            Console.WriteLine("No es muy efectivo!");
            pokemon1.HP -= 5;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "pistola agua" && pokemon1.Tipo == "planta") {
            Console.WriteLine("No es muy efectivo!");
            pokemon1.HP -= 5;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "cuchillada") {
            Console.WriteLine("Es efectivo!");
            pokemon1.HP -= 10;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "latigo") {
            Console.WriteLine("Es efectivo!!");
            pokemon1.HP -= 10;
            Console.ReadKey();
        } else if (pokemon2.Ataques[ataqueEnemigo] == "placaje") {
            Console.WriteLine("Es efectivo!!");
            pokemon1.HP -= 10;
            Console.ReadKey();
        } 
    }
    
}

//SE CREA Y SE CONFIRMA EL NOMBRE DEL ENTRENADOR

while (true) {
    Console.WriteLine("Hola jugador!, ingresa tu nombre de entrenador!");
    nombreEntrenador = Console.ReadLine();
    if (nombreEntrenador != "") {
        entrenador.Nombre = nombreEntrenador;
        break;
    } else if (nombreEntrenador == "") {
        Console.WriteLine("Aun no has dicho tu nombre, vuelve a intentarlo!");
        Console.ReadKey();
    }
    
}

Console.WriteLine(@$"BIENVENIDO {nombreEntrenador}!, preparate para tu nueva aventura!");
Console.WriteLine(@"                                  ,'\
    _.----.        ____         ,'  _\   ___    ___     ____
_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.
\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |
 \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |
   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |
    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |
     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |
      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |
       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |
        \_.-'       |__|    `-._ |              '-.|     '-.| |   |
                                `'                            '-._|");
Console.Write("Presiona cualquier boton para continuar.");
Console.ReadKey();

Console.Clear();
int eleccion = 0;
while (true) {
    Console.WriteLine(@"Elija su pokemon inicial!
    1. Charmander
    2. Squirtle
    3. Bulbasaur");
    try {
        eleccion = int.Parse(Console.ReadLine());
    } catch (FormatException) {  
        Console.WriteLine("Ingresaste una opcion no valida, vuelve a intentarlo!");
        Console.ReadKey();
        Console.Clear();
    }

    if (eleccion > 3 || eleccion <= 0 || eleccion == null) {
        Console.WriteLine("No has seleccionado a ninguno de los pokemones, vuelve a intentarlo!");
        Console.ReadKey();
    } else {
        string seleccionado = eleccion switch {
            1 => @"Charmander!
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠤⠒⠊⠉⠁⠒⠦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣰⡊⠁⠀⠀⠀⠀⠀⠀⠀⠈⠳⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢠⣿⠁⠀⠀⠀⠀⠀⠀⣴⣶⣀⠀⠙⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⣏⡏⠀⠀⠀⠀⠀⠀⠀⡼⢉⠟⣆⠀⢱⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢠⠞⠛⠀⠀⠀⠀⠀⠀⠀⢰⠗⠊⠀⢸⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣰⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣆⣀⣀⡞⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⠀⠀
⠀⠀⠀⠘⣦⣀⠁⠀⠀⠂⠀⠀⠀⠀⠀⢀⣀⣀⡴⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣼⢿⠀⠀⠀
⠀⡟⠓⠤⣘⣿⣿⡒⠒⠶⠒⠒⠚⠋⣿⣉⠽⢋⠆⠀⠀⡄⠀⠀⠀⣀⡤⠶⣶⠀⠀⠀⠀⠀⢠⣿⠉⢀⡈⠷⢿⠀
⢾⡻⣏⠀⠀⠉⠻⣷⣦⠤⠤⠤⠤⢾⣯⣵⡞⠁⠀⠀⠘⠓⠒⠉⠉⠀⠉⡿⠿⣤⠀⠀⠀⠀⠀⢻⣧⣼⡇⠀⢸⡄
⠀⠑⢄⠀⠀⠀⠀⠀⢹⠏⠀⠈⠉⠁⠀⠈⠑⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠞⠁⠀⠀⠀⠀⠀⢀⡿⢿⣧⣄⠀⢷
⠀⠀⠀⠱⣄⠀⠀⠀⡎⠀⠀⠀⠀⠀⠀⠀⠀⠈⢦⠀⠀⠀⠀⠀⠀⣀⡴⠃⠀⠀⠀⠀⠀⠀⠀⣸⠀⠈⣿⣿⣆⡼
⠀⠀⠀⠀⠈⠓⢤⣸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢧⠀⠀⠒⠲⡋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣄⠀⠀⢈⣿⠃
⠀⠀⠀⠀⠀⠀⠀⣹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠶⡞⢻⠋⠀
⠀⠀⠀⠀⠀⠀⠀⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠘⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡇⣾⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⠀⠀⢹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡞⠀⡏⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀⠀⠀⠀⣠⠏⠀⢰⠇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⡠⠚⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⣀⡀⣀⡀⡿⠦⢄⣀⣀⣀⠤⠴⠊⠁⠀⢠⡟⠀⠀⠀
⠀⠀⠀⠀⠀⢀⡞⠁⠀⠈⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⡼⠀⠀⠀⠀⠘⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⡟⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠈⠳⣄⡀⠀⠀⠀⢀⡼⠁⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⣀⣴⡾⠋⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠘⢦⡀⠀⠀⠀⠀⠀⢀⡿⠑⠒⠀⣏⠀⠀⠀⠀⠀⠀⠀⣟⣒⠒⠒⠒⣊⣩⠔⠋⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣀⡤⠖⠚⠻⣶⠀⠀⠀⠀⢯⡀⠀⠀⠀⢘⡆⠀⠀⠀⠀⣠⡞⠁⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠠⣾⣟⣱⢦⡀⠀⠀⠀⠀⣀⣀⣨⠇⠀⠀⠀⢸⢀⡀⢀⣀⢀⣉⣻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢉⣉⡉⠉⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠘⢿⣸⣿⣸⣿⣼⡋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            2 => @"Squirtle!
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣠⠤⠤⠤⠤⣄⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠶⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠢⣄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠋⠁⠀⠀⠀⠀⢀⣀⡐⢄⠀⠀⠀⠀⠀⠀⠈⠳⣄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡞⠁⠀⠀⠀⠀⠀⡜⠁⠀⣿⡌⠀⠀⠀⠀⠀⠀⠀⠀⠈⢆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⣸⣷⣤⣾⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠊⣼⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢤⡀⠀⠀⠀⢰⡇⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⡜⣼⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡎⠀⠉⠲⣄⣀⣼⡇⠀⠀⠀⠀⠀⠀⠻⠿⣿⣟⡼⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠉⠉⠁⠀⡏⠑⠌⠓⢬⣧⠀⠀⠀⠀⠘⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⠿⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣇⠀⠀⠀⠇⠀⠀⠀⠀⠙⣆⠀⠀⠀⠀⠀⠈⠉⠓⠒⠲⠤⢤⣀⠀⠂⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀
⠀⠀⠀⠀⢀⣠⠤⠖⠒⠒⠒⠦⢤⡀⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠈⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠲⠤⠤⠒⠋⢉⠟⠀⠀⠀⠀
⠀⠀⢀⡴⠋⠁⠀⠀⠀⠀⠀⠀⠀⠙⢦⠀⠀⠀⢠⡞⠹⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡠⠋⠀⠀⠀⠀⠀
⠀⣠⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢇⠀⢠⡟⠀⠀⠹⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⠈⠑⠢⢤⣀⣀⠀⠀⠀⠀⢀⣀⡤⠖⠯⣀⠀⠀⠀⠀⠀⠀
⢀⡟⠀⠀⠀⠀⠠⠴⠤⣀⠀⠀⠀⠀⠀⢸⣠⡟⠀⠀⠀⠀⢹⣄⠀⠀⠀⠀⠀⠀⢀⣼⡁⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⢻⠀⠀⠀⠀⠀⠉⠢⣄⣀⡀⠀
⢸⡇⠀⠀⠀⠀⠀⠀⠀⠘⡆⠀⠀⠀⠀⢈⣿⡇⠀⠀⠀⠀⢸⠉⢢⣀⡀⢀⣀⣴⠟⠀⠙⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡆⠀⠀⠀⠀⠀⠀⠀⠀⢇⡀
⠘⣇⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⢸⡇⣷⠀⠀⠀⢀⡞⠀⢰⠏⠉⠉⠁⢸⡀⠀⠀⠀⠈⠓⠶⠤⣤⣄⣀⣠⡤⠴⡇⠀⠀⠀⠀⠀⠀⠀⠀⡔⠁
⠀⠹⣆⠀⠀⠀⠀⠀⢀⡼⠁⠀⠀⠀⠀⢸⠁⠸⡆⠀⣠⠞⠀⢀⡞⠀⠀⠀⠀⠘⡇⠀⠀⠀⠀⠀⠀⠀⠀⢸⠃⠀⠀⢰⣧⣀⣀⡀⠀⢀⣀⣠⠴⠃⠀
⠀⠀⠹⡓⠦⠤⠤⠖⠋⠀⠀⠀⠀⠀⠀⢸⠀⠀⠹⡴⠁⠀⢠⠞⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⡞⠀⠀⠀⣸⠀⠀⠉⠉⠉⠉⠀⠀⠀⠀⠀
⠀⠀⠀⠘⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⢸⢁⡠⠴⢧⡀⠀⠀⠀⠀⣀⠔⠳⣄⠀⠀⠀⠀⠀⠀⡼⠁⠀⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠘⣇⣠⡿⠋⠀⠀⠀⠙⢦⣀⡠⠞⠁⠀⠀⠈⠙⠶⣤⣀⡀⣰⠃⠀⠀⣠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠙⢦⣀⠀⠀⠀⠀⠀⠀⣸⠏⠀⠀⠀⠀⠀⠀⠈⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣹⠋⠉⠉⣹⠏⠙⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⠲⢤⣄⣀⣠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⠀⠀⠀⠀⠀⡰⠃⢀⣤⠞⠁⠀⠀⠘⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡽⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣻⠶⠤⠤⠤⠤⠤⢤⣞⡥⠖⠋⠀⠀⠀⠀⠀⠀⢹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠟⠒⠀⠀⠒⠒⠺⢯⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠎⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀⠀⠀⠀⠀⢄⣈⠆⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⢄⡀⠀⠀⠀⠀⠀⠀⢀⠞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣄⠀⠀⠀⠀⢀⣠⠴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢇⣀⡤⠖⢄⠀⣰⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⠒⠒⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠈⠙⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            3 => @"Bulbasaur!
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠉⢳⠴⢲⠂⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⠤⠤⠤⠤⠤⠤⠤⠤⠤⠖⠊⠀⣠⠎⠀⡞⢹⠏⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠊⠁⠀⠀⠀⠀⠀⢀⡠⠤⠄⠀⠀⠀⠁⠀⠀⢀⠀⢸⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣠⠤⠤⠄⣀⠀⠀⠀⠀⢀⣌⠀⠀⠀⠀⠀⢀⣠⣆⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠘⡄⠀⠀⠀⠀
⠀⠀⠀⠀⡴⠁⠀⠀⠐⠛⠉⠁⠀⠀⣉⠉⠉⠉⠑⠒⠉⠁⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢧⠀⠱⡀⠀⠀⠀
⠀⠀⠀⢰⣥⠆⠀⠀⠀⣠⣴⣶⣿⣿⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⢇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡆⠀⠑⡄⠀⠀
⠀⠀⢀⡜⠁⠀⠀⢀⠀⠻⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠀⠀⠸⡀⠀
⠀⢀⣮⢖⣧⢠⠀⣿⠇⠀⠀⠁⠀⠀⠀⠠⠀⢀⣠⣴⣤⡀⠀⠀⠀⠈⡗⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⢱⠀
⠀⣼⠃⣼⣿⠘⠀⠀⠀⢠⣶⣿⡆⠀⠀⠁⣠⠊⣸⣿⣿⣿⡄⠀⠀⠀⡇⠀⢑⣄⠀⠀⠀⠀⠀⠀⢠⠃⠀⠀⠸⡆
⠀⣿⢰⣿⣿⠀⠀⠀⠀⠙⠻⠿⠁⠀⠀⠠⠁⠀⣿⣿⣿⣿⡇⠀⠀⠀⠇⠀⢻⣿⣷⣦⣀⡀⣀⠠⠋⠀⠀⠀⢀⡇
⠈⠉⠺⠿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⢿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠈⢿⣿⣿⣿⣿⢦⡀⠀⠀⠀⠀⡸⠀
⠘⣟⠦⢀⠀⠀⢠⠀⠀⡠⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠁⣀⠔⠀⠀⠀⠀⠀⠀⠀⠛⠻⠟⠋⠀⠙⢦⠀⣠⠜⠀⠀
⠀⠈⠑⠤⡙⠳⣶⣦⣤⣤⣤⣤⣤⣤⣤⣤⣴⣶⡶⠞⠁⠀⠀⣠⠖⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠈⢯⠁⠀⠀⠀
⠀⠀⠀⠀⠈⢳⠤⣙⡻⠿⣿⣿⣿⣿⡿⠿⠛⠉⠀⢀⣀⡤⡚⠁⠀⠀⠀⠀⠀⠀⣧⠖⣁⣤⣦⠀⠀⠈⢇⠀⠀⠀
⠀⠀⠀⠀⠀⢸⠀⢀⣩⣍⠓⠒⣒⠒⠒⠒⠒⠊⠉⠁⢀⡟⠀⠀⣾⣷⠀⠀⠀⠀⠏⢴⣿⣿⣿⠀⠀⠀⢸⠀⠀⠀
⠀⠀⠀⠀⠀⠘⣶⣿⣿⣿⠀⠀⠈⠒⢄⣀⡀⠀⠀⠀⣼⣶⣿⡇⠈⠋⠀⠀⠀⡼⠀⠈⠻⣿⡿⠀⠀⠀⢸⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠹⡿⠿⠋⠀⠀⠀⠀⡜⠁⠈⢯⡀⢺⣿⣿⣿⠃⠀⠀⠀⢀⣼⣇⠀⠀⠀⠀⠀⠀⠀⠀⡞⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣿⣦⣄⣠⣀⣠⠞⠀⠀⠀⠈⠛⣿⡛⠛⠁⠀⠀⠀⣠⠊⠀⠈⢦⣄⣀⣀⣀⣀⢀⡼⠁⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠛⠉⠀⠀⠀⠀⠀⠀⠘⠛⠿⣿⠷⡾⠗⠊⠁⠀⠀⠀⠈⠉⠙⠛⠛⠛⠉⠀⠀⠀⠀⠀"
        };

        Console.Clear();
        if (eleccion == 1) {
            entrenador.Equipo.Add(charmander);
        } else if (eleccion == 2) {
            entrenador.Equipo.Add(squirtle);
        } else if (eleccion == 3) {
            entrenador.Equipo.Add(bulbasaur);
        }
        Console.Clear();
        Console.WriteLine($"FELICIDADES!, tu pokemon inicial sera {seleccionado}");
        Console.Write("Presiona cualquier boton para continuar.");
        Console.ReadKey();

        while (true) {
            Console.WriteLine("Asignale a tu pokemon un nombre nuevo!");
            entrenador.Equipo[0].Nombre = Console.ReadLine();

            if (entrenador.Equipo[0].Nombre == "") {
                Console.WriteLine("No le has dado ningun nombre, vuelve a intentarlo!");
            } else {
                Console.WriteLine($"FELICIDADES, el nombre de tu pokemon sera {entrenador.Equipo[0].Nombre}");
                break;
            }
        }
        break;
    }

}

//AL MOMENTO DE CONSEGUIR EL POKEMON INICIAL, SELECCIONA AL POKEMON RIVAL
int elegirEnemigo = 0; 
while (true) {
    if (eleccion == 1) {
        squirtle.Nombre = "squirtle";
        bulbasaur.Nombre = "bulbasaur";
        Console.WriteLine(@"Seleccione su rival!
        1. Squirtle
        2. Bulbasaur");
        try {
            elegirEnemigo = int.Parse(Console.ReadLine());
        } catch (FormatException) {
            Console.WriteLine("Ingresaste una opcion no valida, vuelve a intentarlo!");
            Console.ReadKey();
            Console.Clear();
        }

        if (elegirEnemigo == 1) {
            Console.Clear();
            Console.WriteLine($"PREPARATE, tu enemigo sera Squirtle, preparate para la lucha!");
            luchaPokemon(charmander, squirtle);
            Console.ReadKey();
            break;
        } else if (elegirEnemigo == 2) {
            Console.Clear();
            Console.WriteLine($"PREPARATE, tu enemigo sera Bulbasaur, preparate para la lucha!");
            luchaPokemon(charmander, bulbasaur);
            Console.ReadKey();
            break;
        } else {
            Console.Clear();
            Console.WriteLine("No seleccionaste ninguna de las opciones, vuelve a intentarlo!");
        }
    } else if (eleccion == 2) {
        charmander.Nombre = "charmander";
        bulbasaur.Nombre = "bulbasaur";
        Console.WriteLine(@"Seleccione su rival!
        1. Charmander
        2. Bulbasaur");
        try {
            elegirEnemigo = int.Parse(Console.ReadLine());
        } catch (FormatException) {
            Console.WriteLine("Ingresaste una opcion no valida, vuelve a intentarlo!");
            Console.ReadKey();
            Console.Clear();
        }

        if (elegirEnemigo == 1) {
            Console.Clear();
            Console.WriteLine($"PREPARATE, tu enemigo sera Charmander, preparate para la lucha!");
            luchaPokemon(squirtle, charmander);
            Console.ReadKey();
            break;
        } else if (elegirEnemigo == 2) {
            Console.Clear();
            Console.WriteLine($"PREPARATE, tu enemigo sera Bulbasaur, preparate para la lucha!");
            luchaPokemon(squirtle, bulbasaur);
            Console.ReadKey();
            break;
        } else {
            Console.Clear();
            Console.WriteLine("No seleccionaste ninguna de las opciones, vuelve a intentarlo!");
        }
    } else if (eleccion == 3) {
        charmander.Nombre = "charmander";
        charmander.Nombre = "squirtle";
        Console.WriteLine(@"Seleccione su rival!
        1. Charmander
        2. Squirtle");
        try {
            elegirEnemigo = int.Parse(Console.ReadLine());
        } catch (FormatException) {
            Console.WriteLine("Ingresaste una opcion no valida, vuelve a intentarlo!");
            Console.ReadKey();
            Console.Clear();
        }

        if (elegirEnemigo == 1) {
            Console.Clear();
            Console.WriteLine($"PREPARATE, tu enemigo sera Charmander, preparate para la lucha!");
            luchaPokemon(bulbasaur, charmander);
            Console.ReadKey();
            break;
        } else if (elegirEnemigo == 2) {
            Console.Clear();
            Console.WriteLine($"PREPARATE, tu enemigo sera Squirtle, preparate para la lucha!");
            luchaPokemon(bulbasaur, squirtle);
            Console.ReadKey();
            break;
        } else {
            Console.Clear();
            Console.WriteLine("No seleccionaste ninguna de las opciones, vuelve a intentarlo!");
        }
    } else {
        Console.Clear();
        Console.WriteLine("No has seleccionado ninguna de las opciones, vuelve a intentarlo!");
        Console.ReadKey();
    }
}

if (entrenador.Equipo[0].HP <= 0) {
    Console.WriteLine(@$"Que pena...has perdido la batalla, pero no te preocupes!
    ¡Habra mas suerte para la proxima, {entrenador.Nombre}!");
    Console.ReadKey();
} else {
    int elegirCamino = 0;
    Console.WriteLine("FELICIDADES, HAS GANADO LA PELEA!");
    Console.ReadKey();
    while (true) {
        Console.Clear();
        Console.WriteLine(@"¿Deseas explorar un poco mas?
        1. SI, me gustaria explorar un poco mas!
        2. Descansare para esta ocasion");

        try {
            elegirCamino = int.Parse(Console.ReadLine());
        } catch (FormatException) {
            Console.Clear();
            Console.WriteLine("No ingresaste una opcion valida, vuelve a intentarlo!");
            Console.ReadKey();
        }

        if (elegirCamino == 1) {
            Console.WriteLine("¡Muy bien!, Comencemos a explorar!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(@$"
  ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠴⠶⠒⣒⡒⠒⠤⠄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⡀⠀⠀⠀⠀⠀⢠⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⠤⣀⠀⠁⠒⠄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⠆⢧⣀⡀⠀⠀⠀⣞⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣤⡀⠀⠀⠉⠐⠒⠂⠒⠒⠒⠂⠉⠁⠀⢸⠀⠸⡀⠀⠉⠒⢴⡋⢣⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢿⣦⣄⣠⣤⣤⣤⣤⣤⣤⣀⣀⠀⣼⠀⠀⢣⠀⠀⠀⠀⣉⣺⡀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⠿⣿⣿⣿⣿⣿⣿⣿⣿⣾⠀⣀⠀⠓⠀⠀⠀⠹⠣⡱⡀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠻⣿⣿⣿⡀⢸⣷⣦⣤⣀⠀⠀⢣⢹⡇⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠈⠛⣷⠀⢿⣿⣿⣿⣿⣶⠞⠚⠃⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⡒⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠳⣄⠈⠱⢦⣙⣿⣿⡿⢧⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣄⠳⡀⠀⠀⠀⣀⡀⠤⣤⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⣀⠼⠀⠀⠑⠢⠼⡀⠀⠈⠉⠉⠁⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣆⢈⡲⠒⠉⢀⡤⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣲⠤⠒⠈⠁⠀⠀⠀⠀⡤⠀⠈⣗⢄⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡿⢸⣿⣆⣰⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠦⣄⡀⠀⠀⠀⠀⠀⡜⠀⠀⠀⠘⡀⠈⠢⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠞⠀⢀⣙⣟⠈⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣖⢤⡀⠀⠠⡃⠀⠀⠀⠀⢗⣒⡤⠜⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠔⠁⠀⣠⠎⠉⢻⣦⠈⠣⡀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⢀⠾⣿⡿⠟⠀⢰⢧⠀⠀⠀⠀⣻⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⡎⠀⠀⡴⠁⠀⠀⠀⠙⢷⡄⠘⢄⠀⠀⠀⢀⢤⣊⣁⣈⡉⠒⢴⡓⠋⠁⠀⠀⠀⢸⡄⢣⡀⠀⠀⡟⢤⡀⠀⠀⠀⠀⠀
⠴⠮⠭⢤⡀⠈⠑⢄⠀⠀⢸⠀⠀⡼⢁⣀⣀⣀⠀⠀⠈⠻⣆⠀⠳⠔⣪⣟⣭⠷⠛⠓⠛⠛⠶⠮⢿⣷⣂⡄⠀⢸⣷⡀⠑⠤⣼⡡⠔⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠈⢆⠀⠀⠓⢐⠏⠀⡸⠁⠀⠀⠀⣀⠬⠓⠊⠉⣹⡗⢀⣶⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⠞⠻⠁⠀⣼⣿⣷⣄⣸⣿⡄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⢷⠄⢠⠊⠀⢰⠃⡀⠤⠒⣿⠅⠀⠀⠀⢰⠁⣰⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠳⢾⣷⠀⢸⢤⡤⠖⠉⠀⠀⠀⠀⢀⡎⠴⠻⠤⠤⢀⣀⠀⠀⣀⠀⠴⠎⠁⠀⠀⠀⢀⠀⠀⣿⣿⣿⢾⣽⡿⡇⠱⢄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢘⣾⡄⣼⠁⠀⠀⠀⠀⠀⠀⠀⠘⢷⢦⣤⣤⣤⣤⣬⣱⣏⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⢠⣿⣾⣿⣯⣿⣿⡿⠀⠀⠉⣢⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢸⣚⡇⢼⢔⡦⢄⣀⠀⠀⠀⠀⠀⠸⣧⠺⣍⠉⣉⠀⠀⠘⡷⠄⠀⠀⠀⠀⠀⠀⡸⢁⣾⢯⣿⣟⡾⣽⣿⣇⠀⢴⣴⠋⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠸⣏⢧⠘⡄⠈⠒⠤⡉⠐⡄⠀⠀⣠⣻⢇⠻⣦⡀⠉⠁⠒⢸⣼⠀⠀⠀⠀⠀⡰⢃⣾⣿⣿⣿⣾⣽⣿⣿⣿⡄⢸⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡎⣧⠘⡄⠀⠀⠘⡷⠇⢠⢞⡯⡱⢎⣷⣶⣝⣦⣄⡀⡼⣿⠀⠀⠀⠀⣰⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⢸⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡬⢳⡘⡄⠀⢀⣾⢞⡵⣋⢶⡽⠻⣿⣿⣿⡏⠉⡟⣹⡿⡀⠀⠀⠀⣿⡛⣿⡿⣿⣿⡟⠋⢻⣿⣿⣿⠀⠀⢧⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡱⢛⡜⢦⣾⡵⣋⢶⡽⠋⠀⠀⢻⣿⡟⠀⣸⠀⣏⠇⡇⠀⠀⢀⡟⣿⣏⠶⣱⠏⠀⠀⢸⣿⡉⠛⢄⠀⠈⢆⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⢩⢞⣶⣾⡗⡿⣏⠀⢄⠉⠉⣿⡉⠀⠀⡇⠀⣟⠀⠈⠒⠐⣺⣏⢿⣿⣾⠃⠀⠀⠀⠘⡍⢷⡀⠀⠈⠒⢺⠄⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢟⣎⣾⣿⠻⡜⣇⠈⢧⡌⠀⢸⠁⢧⢀⣸⡇⠀⠹⡀⠀⢠⠞⢘⣧⣞⣻⡛⣧⠀⠀⠀⠀⢹⠀⡑⢄⠢⠤⡟⠘⡄⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⣣⠞⣬⠿⠚⢵⣍⢎⡳⣄⢳⡀⢹⠆⡾⠊⡇⠇⠀⢠⡇⠠⠟⢁⣼⡷⠋⠙⢷⣩⢧⡀⠀⠀⠀⣇⠘⡈⢆⠀⢻⠃⡶⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⣚⣵⠟⠁⠀⠀⠀⠈⢹⢶⠭⣗⣵⡃⡸⡰⠋⡼⠀⠀⠀⠃⠀⡔⠉⠁⠀⠀⠀⠀⠙⠻⣧⡀⠀⠀⠘⡄⢣⠈⠆⠀⢰⠁⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠿⠓⠉⠀⠀⠀⠀⠀⠀⡰⠁⢸⠐⡄⠀⢠⡷⢁⠜⠀⠀⠀⣀⣴⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⡷⢈⡆⠀⠀⡇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡇⢠⣾⠀⢱⠀⣿⣧⠃⠀⠀⣠⢞⢿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⠸⠀⠀⣸⡇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⣱⣇⠀⠈⡆⡇⣿⠀⣠⠚⣡⠏⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡇⠀⡆⠀⡏⡇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡷⢪⣧⡀⢀⡇⢻⡇⠀⣴⢫⢱⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢧⠀⠇⢸⠀⣇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡥⡇⠱⣾⣇⠘⣷⣞⢣⢳⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢇⠈⡜⠀⢸⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⠃⠀⠈⢿⣆⢿⢧⢣⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢳⣷⠀⠘⡆⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢾⡜⣧⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢷⡀⢰⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣘⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣮⡇
            ¡Te has topado con un {arceus.Nombre}!");
            Console.ReadKey();
            luchaPokemon(entrenador.Equipo[0], arceus);
            if (entrenador.Equipo[0].HP > 0 && entrenador.Equipo[1].HP > 0) {
                Console.WriteLine("¡FELICIDADES!, pudiste sobrevivir al combate!");
                Console.ReadKey();
                Console.WriteLine("Sera mejor descansar por el viaje, ¡hiciste un gran trabajo!");
                Console.ReadKey();
                Console.WriteLine("¡Nos vemos en una proxima ocasion!");
                break;
            } else {
                Console.WriteLine("Vaya...tu pokemon quedo demasiado debilitado para continuar");
                Console.ReadKey();
                Console.WriteLine($"¡Pero no te preocupes {entrenador.Nombre}!, en una proxima vez tendras mas suerte");
                Console.ReadKey();
                Console.WriteLine("¡Nos volveremos a ver pronto!");
                break;
            }
            
        } else if (elegirCamino == 2) {
            Console.WriteLine($"No hay problema {entrenador.Nombre}!, ha sido suficiente viaje por hoy.");
            Console.ReadKey();
            Console.WriteLine("¡Nos vemos en una proxima ocasion!");
            break;
        } else {
            Console.WriteLine("No has seleccionado ninguna de las opciones, vuelve a intentarlo!");
            Console.ReadKey();
        }
    }
    
}