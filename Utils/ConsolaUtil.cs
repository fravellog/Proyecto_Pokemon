namespace Pokedex.Utils
{
    public class ConsolaUtil
    {
        public static void LimpiarConsola()
        {
            Console.Clear();
        }

        public static void EsperaryLimpiar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            LimpiarConsola();
        }
    }
}