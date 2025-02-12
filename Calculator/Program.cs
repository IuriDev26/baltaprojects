using System;

namespace Calculator
{
    class Program
    {
        static int TotalWidth = Console.WindowWidth;
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                string operation = callMenu();

                switch (operation)
                {
                    case "1": Sum(); break;
                    case "2": Subtract(); break;
                    case "3": Multiply(); break;
                    case "4": Divide(); break;
                    case "5": return;
                    default : 
                        Console.Write("Opção desconhecida, aperte qualquer tecla pra continuar"); 
                        Console.Read();
                        break;
                }

                Console.Write("Pressione qualquer tecla para continuar ");
                Console.ReadLine();

            }
            
        }

        static void Sum()
        {
            DrawTextInterHyphens("Somar");

            Console.Write("Digite o primeiro valor: ");
            double value1 = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o segundo valor: ");
            double value2 = double.Parse(Console.ReadLine());

            DrawResult(value1, value2, value1 + value2, "+");

        }

        static void Subtract()
        {
            DrawTextInterHyphens("Subtrair");

            Console.Write("Digite o primeiro valor: ");
            double value1 = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o segundo valor: ");
            double value2 = double.Parse(Console.ReadLine());

            DrawResult(value1, value2, value1 - value2, "-");
        }
        
        static void Multiply()
        {
            DrawTextInterHyphens("Multiplicar");

            Console.Write("Digite o primeiro valor: ");
            double value1 = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o segundo valor: ");
            double value2 = double.Parse(Console.ReadLine());

            DrawResult(value1, value2, value1 * value2, "x");
        }
        
        static void Divide()
        {
            DrawTextInterHyphens("Dividir");

            Console.Write("Digite o primeiro valor: ");
            double value1 = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o segundo valor: ");
            double value2 = double.Parse(Console.ReadLine());

            DrawResult(value1, value2, value1 * value2, "/");
        }

        static string callMenu()
        {
            DrawTextInterHyphens("Calculator Master 3000");
            Console.WriteLine(new string('-', Console.WindowWidth));
            
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Sair");
            
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.Write("\nEscolha a operação: ");

            string operation = Console.ReadLine();

            if (operation == null)
            {
                operation = "";
            }
            
            return operation;

        }
        
        static void DrawTextInterHyphens(string text)
        {
            Console.Clear();
            Console.WriteLine(new string('-', TotalWidth));
            Console.WriteLine(text);
            Console.WriteLine(new string('-', TotalWidth));
        }

        static void DrawResult(double value1, double value2, double result, string operationSymbol)
        {
            Console.WriteLine($" {value1}");
            Console.Write(operationSymbol);
            Console.WriteLine($"{value2}");
            Console.WriteLine(new string('-', 15));
            Console.WriteLine($" {result}");
            
        }
        
        
        
    }
}