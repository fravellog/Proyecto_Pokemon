namespace Pokedex.Models 
{
    public class Pokemon
    {
        public string Nombre { get; set; }
        public double HP { get; set; }
        public TipoNaturaleza Tipo { get; set; }
        public List<Ataque> Ataques { get; set; } = new List<Ataque>();
        public Pokemon(string nombre, double hp, TipoNaturaleza tipo)
        {
            Nombre = nombre;
            HP = hp;
            Tipo = tipo;
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