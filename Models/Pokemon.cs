using Pokedex.Utils;
namespace Pokedex.Models
{
    public class Pokemon
    {
        public string Especie { get; set; }
        public string Nombre { get; set; }
        public double HP { get; set; }
        public TipoNaturaleza Tipo { get; set; }
        public List<Ataque> Ataques { get; set; } = new List<Ataque>();
        public Pokemon(string especie, string nombre, double hp, TipoNaturaleza tipo)
        {
            Especie = especie;
            Nombre = nombre;
            HP = hp;
            Tipo = tipo;
            Ataques = new List<Ataque>();
        }
        public void agregarAtaque(Ataque ataque)
        {
            Ataques.Add(ataque);
        }
        public void MostrarEquipo()
        {
            ConsolaUtil.escribir($"Especie: {Especie}\n");
            ConsolaUtil.escribir($"Apodo: {Nombre}\n");
            ConsolaUtil.escribir($"Tipo: {Tipo}\n");
            ConsolaUtil.escribir($"HP: {HP}\n");
            ConsolaUtil.escribir("Ataques:\n");
            int contador = 1;
            foreach (var ataque in Ataques)
            {
                ConsolaUtil.escribir($"{contador}- {ataque.Nombre} ({ataque.Tipo})\n");
                contador++;
            }
        }

        public void MostrarPokemon()
        {
            ConsolaUtil.escribir($"Especie: {Especie}\n");
            ConsolaUtil.escribir($"Tipo: {Tipo}\n");
            ConsolaUtil.escribir($"HP: {HP}\n");
            ConsolaUtil.escribir("Ataques:\n");
            foreach (var ataque in Ataques)
            {
                Console.WriteLine($"- {ataque.Nombre} ({ataque.Tipo})\n");
            }
        }
    }

}