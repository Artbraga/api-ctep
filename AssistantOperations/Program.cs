using AssistantOperations.Boletos;
using AssistantOperations.Menu;
using System;

namespace AssistantOperations
{
    class Program
    {
        private static readonly string[] Options = new[] {
            "Nenhum",
            "Migrar Boletos"
        };
        static void Main(string[] args)
        {
            var option = Choice();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            if (option.HasFlag(MenuOption.Boleto))
            {
                Console.WriteLine($"Iniciando a extração dos boletos.");
                BoletoExtractor.Run();
            }
            sw.Stop();
            if (option == MenuOption.None) return;
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Operação encerrada em {sw.ElapsedMilliseconds}ms");
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine(" - - - - - - - - - - - - - -Programa encerrado!- - - - - - - - - - - - - - ");
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.ReadKey();
        }

        public static MenuOption Choice()
        {
            const int startX = 10;
            const int startY = 4;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("Utilize as setas ↑ e ↓ para escolher");
                Console.WriteLine("Aperte <enter> para confirmar");

                for (int i = 0; i < Options.Length; i++)
                {
                    Console.SetCursorPosition(startX, startY + i);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Blue;

                    Console.Write(
                        (i == currentSelection ? ">> " : "   ")
                        +
                        Options[i]
                    );

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection > default(int))
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + 1 < Options.Length)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return MenuOption.None;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            Console.WriteLine();
            return ParseOption(currentSelection);
        }

        private static MenuOption ParseOption(int optionIndex)
        {
            switch (optionIndex)
            {
                case 0:
                    return MenuOption.None;
                case 1:
                    return MenuOption.Boleto;
                default:
                    return MenuOption.None;
            }
        }
    }
}
