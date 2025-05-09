using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class Objeto 
    {
        //Creacion de objetos de las habilidades pokemon
        Ataque lanzallama = new Ataque("lanzallama", "fuego");
        Ataque cuchillada = new Ataque("cuchillada", "normal");
        Ataque pistolaAgua = new Ataque("pistola agua", "agua");
        Ataque latigo = new Ataque("latigo", "normal");
        Ataque latigoCepa = new Ataque("latigo cepa", "planta");
        Ataque placaje = new Ataque("placaje", "normal");
        Ataque colmilloFuego = new Ataque("colmillo de fuego", "fuego");
        Ataque derribar = new Ataque("derribar", "normal");
        Ataque terremoto = new Ataque("terremoto", "tierra");
        Ataque rasguño = new Ataque("rasguño", "normal");

        //Creacion de los objetos pokemon
        Pokemon charmander = new Pokemon("", 100, "fuego");
        charmander.agregarAtaque(lanzallama);
        charmander.agregarAtaque(cuchillada);
        
        Pokemon squirtle = new Pokemon("", 100, "agua");
        squirtle.agregarAtaque(pistolaAgua);
        squirtle.agregarAtaque(latigo);

        Pokemon bulbasaur = new Pokemon("", 100, "planta");
        bulbasaur.agregarAtaque(latigoCepa);
        bulbasaur.agregarAtaque(placaje);

        Pokemon flareon = new Pokemon("flareon", 100, "fuego");
        flareon.agregarAtaque(colmilloFuego);
        flareon.agregarAtaque(derribar);

        Pokemon sandshrew = new Pokemon("sandshrew", 100, "tierra");
        sandshrew.agregarAtaque(terremoto);
        sandshrew.agregarAtaque(rasguño);

        //Proceso de prueba de metodo "agregarAtaque"
    }
}