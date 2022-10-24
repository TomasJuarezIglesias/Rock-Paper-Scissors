using System;
using System.ComponentModel.Design;

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("El juego esta empezando!!!!");
            while (true)
            {
                Console.WriteLine("==============================================");
                int respuestaJugador = program.TurnoJugador();
                Console.WriteLine("==============================================");
                int respuestaMaquina = program.TurnoMaquina();
                Console.WriteLine("==============================================");
                string resultado = program.Resultado(respuestaJugador, respuestaMaquina);
                Console.WriteLine(resultado);
                Console.WriteLine("==============================================");
                bool seguir = program.Seguir();
                if (seguir == false)
                {
                    Console.WriteLine("==============================================");
                    Console.WriteLine("Gracias por jugar !!");
                    break;
                }
                Console.Clear();
            }
            Console.ReadLine();
        }


        private int TurnoJugador()
        {
            Console.Write("Seleccione una opcion: \n 1- Piedra \n 2- Papel \n 3- Tireja \nSu respuesta: ");
            string respuesta = Console.ReadLine();

            bool isNumber = int.TryParse(respuesta, out int num);
            if (isNumber == false)
            {
                Console.WriteLine("Ingrese un valor valido");
                return TurnoJugador();
            }

            int respuestaNum = int.Parse(respuesta);
            if (respuestaNum < 1 || respuestaNum > 3)
            {
                Console.WriteLine("Ingrese un valor valido");
                return TurnoJugador();
            }

            return respuestaNum;
        }

        private bool Seguir()
        {
            Console.Write("Quieres seguir jugando? \n1- SI\n2- NO\nSu Respuesta:");
            string respuesta = Console.ReadLine();
            bool isNumber = int.TryParse(respuesta, out int num);
            if (isNumber == false)
            {
                Console.WriteLine("Ingrese un valor valido");
                return Seguir();
            }

            int respuestaNum = int.Parse(respuesta);
            if (respuestaNum < 1 || respuestaNum > 2)
            {
                Console.WriteLine("Ingrese un valor valido");
                return Seguir();
            }

            if (respuestaNum == 2)
            {
                return false;
            }

            return true;
        }

        private int TurnoMaquina()
        {
            int[] opciones = { 1, 2, 3 };
            Random rand = new Random();
            int respuesta = rand.Next(opciones.Length);
            Console.WriteLine($"La maquina eligio: {respuesta + 1}");
            return respuesta + 1;
        }

        private string Resultado(int player, int bot)
        {
            if (player == 1 && bot == 2 || player == 2 && bot == 1 || player == 3 && bot == 1)
            {
                return "Perdiste";
            }
            if (player == bot)
            {
                return "Empate";
            }
            return "Ganaste"; 
        }
       
    }
}