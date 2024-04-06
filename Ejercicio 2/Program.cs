using System;

namespace Ejercicio2
{
    class Program
    {
        static char[,] tablero = new char[3, 3];
        static bool turnoJugador1 = true;

        static void Main(string[] args)
        {
            InicializarTablero();
            MostrarTablero();

            while (!JuegoTerminado())
            {
                JugarTurno();
                MostrarTablero();
            }

            MostrarResultado();
        }

        static void InicializarTablero()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tablero[i, j] = ' ';
                }
            }
        }

        static void MostrarTablero()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void JugarTurno()
        {
            int fila, columna;
            do
            {
                Console.WriteLine("Turno del jugador " + (turnoJugador1 ? "1 (X)" : "2 (O)"));
                Console.Write("Ingrese fila (0-2): ");
                fila = int.Parse(Console.ReadLine());
                Console.Write("Ingrese columna (0-2): ");
                columna = int.Parse(Console.ReadLine());
            } while (!MovimientoValido(fila, columna));

            tablero[fila, columna] = turnoJugador1 ? 'X' : 'O';
            turnoJugador1 = !turnoJugador1;
        }

        static bool MovimientoValido(int fila, int columna)
        {
            if (fila < 0 || fila >= 3 || columna < 0 || columna >= 3)
            {
                Console.WriteLine("Movimiento inválido. La fila y columna deben estar entre 0 y 2.");
                return false;
            }
            if (tablero[fila, columna] != ' ')
            {
                Console.WriteLine("Casilla ocupada. Por favor, elige otra.");
                return false;
            }
            return true;
        }

        static bool JuegoTerminado()
        {
            // Verificar filas y columnas
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] != ' ' && tablero[i, 0] == tablero[i, 1] && tablero[i, 0] == tablero[i, 2])
                    return true;
                if (tablero[0, i] != ' ' && tablero[0, i] == tablero[1, i] && tablero[0, i] == tablero[2, i])
                    return true;
            }

            // Verificar diagonales
            if (tablero[0, 0] != ' ' && tablero[0, 0] == tablero[1, 1] && tablero[0, 0] == tablero[2, 2])
                return true;
            if (tablero[0, 2] != ' ' && tablero[0, 2] == tablero[1, 1] && tablero[0, 2] == tablero[2, 0])
                return true;

            // Verificar si hay casillas vacías
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == ' ')
                        return false;
                }
            }

            return true; // Si no hay casillas vacías, el juego termina en empate
        }

        static void MostrarResultado()
        {
            if (JuegoTerminado())
            {
                Console.WriteLine("¡Juego terminado!");
                if (turnoJugador1)
                    Console.WriteLine("¡Gana el jugador 2!");
                else
                    Console.WriteLine("¡Gana el jugador 1!");
            }
            else
            {
                Console.WriteLine("¡Empate!");
            }
        }
    }
}
