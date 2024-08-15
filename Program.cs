using System;
using System.IO;

internal class Program
{
    static dynamic[,] ultimaMatriz; // Variable global para almacenar la última matriz resultante
    static string ultimaOperacion = "Ninguna operación realizada aún.";

    static void Main(string[] args)
    {
        int i = 1;
        while (i == 1)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a mi programa de Suma, Resta y Multiplicación de Matrices");
            Console.WriteLine("Elige una opción del MENÚ:");
            Console.WriteLine("1.SUMA");
            Console.WriteLine("2.RESTA");
            Console.WriteLine("3.MULTIPLICACIÓN");
            Console.WriteLine("4.Ultima Operación realizada");
            Console.WriteLine("5.SALIR");
            int opcion = int.Parse(validar("Elige una opción: ").ToString());
            switch (opcion)
            {
                case 1:
                    suma();
                    break;
                case 2:
                    resta();
                    break;
                case 3:
                    multiplicacion();
                    break;
                case 4:
                    MostrarUltimaOperacion();
                    break;
                case 5:
                    i = 2;
                    break;
            }
        }
        Console.ReadKey();
    }

    public static void suma()
    {
        int filas = int.Parse(validar("Ingresa el numero de filas de las matrices: ").ToString());
        int columnas = int.Parse(validar("Ingresa el numero de colunmas de las matrices: ").ToString());
        Console.WriteLine("Ingresa los datos de la matriz 1: ");
        dynamic[,] matriz_1 = llenar_matriz(filas, columnas);
        Console.WriteLine("Ingresa los datos de la matriz 2: ");
        dynamic[,] matriz_2 = llenar_matriz(filas, columnas);
        ultimaMatriz = operaciones(matriz_1, matriz_2, 1);
        ultimaOperacion = "Suma";
        MostrarMatriz(ultimaMatriz);
    }

    public static void resta()
    {
        int filas = int.Parse(validar("Ingresa el numero de filas de las matrices: ").ToString());
        int columnas = int.Parse(validar("Ingresa el numero de colunmas de las matrices: ").ToString());
        Console.WriteLine("Ingresa los datos de la matriz 1: ");
        dynamic[,] matriz_1 = llenar_matriz(filas, columnas);
        Console.WriteLine("Ingresa los datos de la matriz 2: ");
        dynamic[,] matriz_2 = llenar_matriz(filas, columnas);
        ultimaMatriz = operaciones(matriz_1, matriz_2, 2);
        ultimaOperacion = "Resta";
        MostrarMatriz(ultimaMatriz);
    }

    public static void multiplicacion()
    {
        int filas = int.Parse(validar("Ingresa el numero de filas de las matrices: ").ToString());
        int columnas = int.Parse(validar("Ingresa el numero de colunmas de las matrices: ").ToString());
        Console.WriteLine("Ingresa los datos de la matriz 1: ");
        dynamic[,] matriz_1 = llenar_matriz(filas, columnas);
        Console.WriteLine("Ingresa los datos de la matriz 2: ");
        dynamic[,] matriz_2 = llenar_matriz(filas, columnas);
        ultimaMatriz = operaciones(matriz_1, matriz_2, 3);
        ultimaOperacion = "Multiplicación";
        MostrarMatriz(ultimaMatriz);
    }

    // Función para validar número entero
    public static dynamic validar(string n)
    {
        bool b = true;
        double r = 0;
        while (b)
        {
            try
            {
                Console.WriteLine(n);
                r = Convert.ToDouble(Console.ReadLine());
                b = false;
            }
            catch
            {
                Console.WriteLine("El formato del número es incorrecto");
            }
        }
        return r;
    }

    public static dynamic[,] llenar_matriz(int fila, int columna)
    {
        Console.WriteLine("=======================================================");
        dynamic[,] matriz_1 = new dynamic[fila, columna];
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                matriz_1[i, j] = validar($"Ingresa el valor correspondiente de la posicion:[{i},{j}] ");
            }
        }
        return matriz_1;
    }

    static dynamic operaciones(dynamic[,] matriz_n1, dynamic[,] matriz_n2, int opcion)
    {
        if (opcion == 1)
        {
            dynamic[,] MatResultante = new dynamic[matriz_n1.GetLength(0), matriz_n1.GetLength(1)];

            for (int i = 0; i < matriz_n1.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_n2.GetLength(1); j++)
                {
                    MatResultante[i, j] = matriz_n1[i, j] + matriz_n2[i, j];
                }
            }
            return MatResultante;
        }
        else if (opcion == 2)
        {
            dynamic[,] MatResultante = new dynamic[matriz_n1.GetLength(0), matriz_n1.GetLength(1)];
            for (int i = 0; i < matriz_n1.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_n2.GetLength(1); j++)
                {
                    MatResultante[i, j] = matriz_n1[i, j] - matriz_n2[i, j];
                }
            }
            return MatResultante;
        }
        else if (opcion == 3)
        {
            int filasA = matriz_n1.GetLength(0);
            int columnasA = matriz_n1.GetLength(1);
            int columnasB = matriz_n2.GetLength(1);

            dynamic[,] resultado = new dynamic[filasA, columnasB];

            for (int i = 0; i < filasA; i++)
            {
                for (int j = 0; j < columnasB; j++)
                {
                    resultado[i, j] = 0;
                    for (int k = 0; k < columnasA; k++)
                    {
                        resultado[i, j] += matriz_n1[i, k] * matriz_n2[k, j];
                    }
                }
            }
            return resultado;
        }
        else
        {
            Console.WriteLine("No se ha realizado ninguna operación");
            dynamic[,] MatResultante = new dynamic[matriz_n1.GetLength(0), matriz_n1.GetLength(1)];
            return MatResultante;
        }
    }

    static void MostrarMatriz(dynamic[,] matriz)
    {
        string rutaArchivo = "resultados.txt";
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                int filas = matriz.GetLength(0);
                int columnas = matriz.GetLength(1);
                Console.WriteLine("Resultado de la operación:");
                escritor.WriteLine("El resultado de la operación es:");
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        string contenido = (matriz[i, j] + "\t");
                        Console.Write("|" + contenido);
                        escritor.Write("|" + contenido);
                    }
                    Console.WriteLine("|");
                    escritor.WriteLine("|");
                }
            }
            Console.WriteLine("La Matriz calculada se ha guardado en el archivo resultados.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error al escribir en el archivo: " + ex.Message);
        }
        Console.ReadKey();
    }

    static void MostrarUltimaOperacion()
    {
        if (ultimaMatriz != null)
        {
            Console.WriteLine($"Mostrando la última operación realizada: {ultimaOperacion}");
            MostrarMatriz(ultimaMatriz);
        }
        else
        {
            Console.WriteLine("No se ha realizado ninguna operación aún.");
        }
    }
}