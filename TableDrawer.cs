namespace Drawers
{

    public class DibujarTablas
    {
        public static void DibujaTabla(string[,] tabla)
        {
            int num1 = 0;
            for (int index1 = 0; index1 < tabla.GetLength(0); ++index1)
            {
                for (int index2 = 0; index2 < tabla.GetLength(1); ++index2)
                {
                    if (tabla[index1, index2] != null && tabla[index1, index2].Length > num1)
                        num1 = tabla[index1, index2].Length;
                }
            }
            int num2 = num1 + 2;
            for (int index3 = 0; index3 < tabla.GetLength(1); ++index3)
            {
                if (index3 == 0)
                    Console.Write("╔");
                for (int index4 = 0; index4 < num2 - 1; ++index4)
                    Console.Write("═");
                if (index3 < tabla.GetLength(1) - 1)
                    Console.Write("╦");
                if (index3 == tabla.GetLength(1) - 1)
                    Console.Write("╗");
            }
            Console.WriteLine();
            for (int index5 = 0; index5 < tabla.GetLength(0); ++index5)
            {
                for (int index6 = 0; index6 < tabla.GetLength(1); ++index6)
                {
                    Console.CursorLeft = num2 * index6;
                    Console.Write("║");
                    Console.ForegroundColor = index5 != 0 ? ConsoleColor.White : ConsoleColor.Red;
                    Console.Write(" {0} ", (object)tabla[index5, index6]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (index5 == 0 || index5 == tabla.GetLength(0) - 1)
                {
                    Console.CursorLeft = num2 * tabla.GetLength(1);
                    //Aceptar argument out of range exception



                    
                    Console.Write("║");
                    Console.WriteLine();
                    for (int index7 = 0; index7 < tabla.GetLength(1); ++index7)
                    {
                        if (index7 == 0 && index5 < tabla.GetLength(0) - 1)
                            Console.Write("╠");
                        if (index7 == 0 && index5 == tabla.GetLength(0) - 1)
                            Console.Write("╚");
                        for (int index8 = 0; index8 < num2 - 1; ++index8)
                            Console.Write("═");
                        if (index7 < tabla.GetLength(1) - 1)
                        {
                            if (index5 < tabla.GetLength(0) - 1)
                                Console.Write("╬");
                            else
                                Console.Write("╩");
                        }
                        if (index7 == tabla.GetLength(1) - 1)
                        {
                            if (index5 == tabla.GetLength(0) - 1)
                                Console.Write("╝");
                            else
                                Console.Write("╣");
                        }
                    }
                }
                else
                {
                    Console.CursorLeft = num2 * tabla.GetLength(1);
                    Console.Write("║");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}