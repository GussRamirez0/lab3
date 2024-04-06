using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] compras = {
            {50, 60, 70, 80, 90},
            {100, 200, 300, 400, 500},
            {600, 700, 800, 900, 1000},
            {150, 250, 350, 450, 550},
            {50, 150, 250, 350, 450}
        };

        CalcularCompras(compras);
    }

    public static void CalcularCompras(int[,] listaCompras)
    {
        for (int i = 0; i < listaCompras.GetLength(0); i++)
        {
            int totalCliente = 0;
            for (int j = 0; j < listaCompras.GetLength(1); j++)
            {
                totalCliente += listaCompras[i, j];
            }

            double descuento = totalCliente >= 1000 ? 0.2 : (totalCliente >= 100 ? 0.1 : 0);

            Console.WriteLine($"Cliente {i + 1}: Total a pagar = {totalCliente}");

            if (descuento > 0)
            {
                double precioFinal = totalCliente * (1 - descuento);
                Console.WriteLine($"Cliente {i + 1}: Aplicó un descuento del {descuento * 100}% (Precio final: {precioFinal})");
            }
            else
            {
                Console.WriteLine($"Cliente {i + 1}: No aplicó ningún descuento");
            }
        }
    }
}
