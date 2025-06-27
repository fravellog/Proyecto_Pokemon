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
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(500); // Espera un segundo entre puntos
            }
            Console.WriteLine(); // Nueva línea después de los puntos
        }
        static object locker = new object();

        public static void escribir(string texto, int delay = 25)
        {
            lock (locker) // Asegura que solo un hilo escriba a la vez
            {
                foreach (char c in texto)
                {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay); // Espera un tiempo antes de escribir el siguiente carácter
                }
            }
        }
    }
}