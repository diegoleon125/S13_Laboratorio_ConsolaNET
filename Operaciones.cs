using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13_Laboratorio_ConsolaNET
{
    internal class Operaciones
    {
        public static int getEntero(string prefijo, string reemplazo)
        {
            int respuesta = 0;
            bool correcto = false;
            do
            {
                string numeroTexto = getTextoPantalla("===================================\n" + prefijo);
                correcto = int.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.Clear();
                    Console.Write(reemplazo + "===================================\n");
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);
            if (respuesta < 1) return 0;
            return respuesta;
        }
        public static string getTextoPantalla(string prefijo)
        {
            Console.Write(prefijo);
            return Console.ReadLine();
        }
        public static void getTecla(string prefijo)
        {
            Console.Write("===================================\n" + prefijo);
            Console.ReadKey();
        }
        public static string setTitulo(string titulo)
        {
            return "===================================\n" + titulo + "\n" + "===================================\n";
        }
        public static string printArreglo(int[] arreglo, int longitud, int numero)
        {
            string texto = "";
            for (int i = 0; i < longitud; i++)
            {
                if (i % 5 == 0) texto += "\n";
                switch (numero)
                {
                    case 2: texto += i.ToString("D2") + ":"; break;
                    case 3: texto += i.ToString("D3") + ":"; break;
                }
                texto += "[" + arreglo[i] + "]  ";
                if (longitud - 1 == i) texto += "\n\n";
            }
            return texto;
        }
        public static int[] eliminarDatoArreglo(int[] arreglo, int longitud, int posicion)
        {
            for (int i = 0; i < longitud; i++)
            {
                if (i >= posicion) arreglo[i] = arreglo[i + 1];
            }
            return arreglo;
        }
        public static int[] ordenarArreglo(int[] arreglo, int longitud)
        {
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud - 1; j++)
                {
                    if (arreglo[j] > arreglo[j + 1])
                    {
                        int aux = arreglo[j + 1];
                        arreglo[j + 1] = arreglo[j];
                        arreglo[j] = aux;
                    }
                }
            }
            return arreglo;
        }
    }
}
