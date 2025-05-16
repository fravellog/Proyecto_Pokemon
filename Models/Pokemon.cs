namespace Pokedex.Models 
{
    public class Pokemon
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int HP { get; set; }
        public List<Ataque> Ataques { get; set; } = new List<Ataque>();
        public Pokemon(string nombre, string tipo, int hp)
        {
            Nombre = nombre;
            Tipo = tipo;
            HP = hp;
            Ataques = new List<Ataque>();
        }
        public void agregarAtaque(Ataque ataque)
        {
            Ataques.Add(ataque);
        }
        public void MostrarPokemon()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine("Ataques:");
            int contador = 1;
            foreach (var ataque in Ataques)
            {
                Console.WriteLine($"{contador}- {ataque.Nombre} ({ataque.Tipo})");
                contador++;
            }
        }
    }
    
}