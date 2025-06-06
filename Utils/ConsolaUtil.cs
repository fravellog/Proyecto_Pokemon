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

        public static void mostrarCarga()
        {
            Console.WriteLine("Cargando...");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000); // Espera medio segundo entre puntos
            }
            Console.WriteLine(); // Nueva línea después de los puntos
        }
    }
}