namespace Pokedex.Models 
{
    public class Pokemon {
        public string Nombre {get; set;}
        public string Tipo {get; set;}
        public int HP {get; set;}
        public List<Ataque> Ataques {get;} = new List<string>();

        public void agregarAtaque (Ataque ataque) {

            Ataques.Add(ataque);
        }
    }
    
}