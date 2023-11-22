using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13_Laboratorio_ConsolaNET
{
    internal class Pantallas
    {
        public static int[] satisfaccion = new int[100];
        public static int[] personas = new int[5];
        public static int cont = 0;
        public static int MenuPrincipal()
        {
            string texto = Operaciones.setTitulo("Encuestas de Calidad") +
                "1: Realizar Encuesta\n" +
                "2: Ver datos registrados\n" +
                "3: Eliminar un dato\n" +
                "4: Ordenar datos de menor a mayor\n" +
                "5: Salir\n";
            Console.Write(texto);
            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion > 5) return 0;
            return opcion;
        }
        public static int RealizarEncuesta()
        {
            string texto1 = Operaciones.setTitulo("Nivel de Satisfacción");
            string texto2 = "Qué tan satisfecho está con la\n atención de nuestra tienda?\n" +
                "1: Nada satisfecho\n" +
                "2: No muy satisfecho\n" +
                "3: Tolerable\n" +
                "4: Satisfecho\n" +
                "5: Muy satisfecho\n";
            Console.Write(texto1 + texto2);
            int nivel = Operaciones.getEntero("Ingrese una opción: ", texto1 + texto2);
            if (nivel > 5) return 1;
            else
            {
                satisfaccion[cont] = nivel;
                personas[nivel - 1]++;
                Console.Clear();
                string texto3 = "\n\n ¡Gracias por participar!\n\n\n";
                Console.Write(texto1 + texto3);
                Operaciones.getTecla("Presione una tecla para\n regresar al menú ...");
                cont++;
            }
            return 0;
        }
        public static int VerDatosRegistrados()
        {
            string texto = Operaciones.setTitulo("Ver datos registrados");
            texto += Operaciones.printArreglo(satisfaccion, cont, 0);
            texto +=
                personas[0].ToString("D2") + " personas: Nada satisfecho\n" +
                personas[1].ToString("D2") + " personas: No muy satisfecho\n" +
                personas[2].ToString("D2") + " personas: Tolerable\n" +
                personas[3].ToString("D2") + " personas: Satisfecho\n" +
                personas[4].ToString("D2") + " personas: Muy satisfecho\n";
            Console.Write(texto);
            Operaciones.getTecla("Presione una tecla para regresar ...");
            return 0;
        }
        public static int EliminarUnDato()
        {
            string texto = Operaciones.setTitulo("Eliminar un dato");
            if (cont == 0)
            {
                texto += "\nNo hay datos\n\n";
                Console.Write(texto);
            }
            else
            {
                texto += Operaciones.printArreglo(satisfaccion, cont, 3);
                Console.Write(texto);
                int posicion = Operaciones.getEntero("Ingrese la posición a eliminar: ", texto);
                if (posicion >= cont || posicion < 0) return 3;
                else
                {
                    string texto2 = "===================================\n";
                    cont--;
                    satisfaccion = Operaciones.eliminarDatoArreglo(satisfaccion, cont, posicion);
                    texto2 += Operaciones.printArreglo(satisfaccion, cont, 3);
                    Console.Write(texto2);
                }
            }
            Operaciones.getTecla("Presione una tecla para regresar ...");
            return 0;
        }
        public static int OrdenarDatosMenorAMayor()
        {
            string texto = Operaciones.setTitulo("Ordenar datos");
            if (cont == 0)
            {
                texto += "\nNo hay datos\n\n";
            }
            else
            {
                texto += Operaciones.printArreglo(satisfaccion, cont, 3);
                texto += Operaciones.setTitulo("");
                satisfaccion = Operaciones.ordenarArreglo(satisfaccion, cont);
                texto += Operaciones.printArreglo(satisfaccion, cont, 3);
            }
            Console.Write(texto);
            Operaciones.getTecla("Presione una tecla para regresar ...");
            return 0;
        }
    }
}
