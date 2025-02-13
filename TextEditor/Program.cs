using System;
using System.ComponentModel.Design;

namespace TextEditor
{
    class Program
    {
        static int WindowWidth = Console.WindowWidth;
        
        static void Main(string[] args)
        {
            while(true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', WindowWidth));
            Console.WriteLine("Welcome to TextEditor!");
            Console.WriteLine(new string('-', WindowWidth));

            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar Arquivo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine(new string('-', WindowWidth));

            Console.Write("Escolha a opção desejada: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: OpenFile(); break;
                case 2: CreateFile(); break;
                case 0: System.Environment.Exit(0); break;
                default: InvalidOption(); break;
                
                
                
            }


        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do arquivo: ");

            using (var file = new StreamReader(Console.ReadLine()))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("\n Aperte qualquer tecla para sair");
            Console.ReadKey();


        }

        static void CreateFile()
        {
            Console.Clear();
            Console.WriteLine("Digite o conteúdo do arquivo: ");
            string text = "";

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                text += Console.ReadLine() + Environment.NewLine;
            }

            Console.WriteLine(text);
            
            Thread.Sleep(5000);
            
            SaveFile(text);



        }

        static void SaveFile(string text)
        {
            Console.Clear();
            Console.Write("Informe o caminho que deseja salvar o arquivo: ");
            string path = Console.ReadLine();
            
            

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
                
            }
            
            
        }

        static void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Opção inválida");
            Console.WriteLine("Tente novamente!");
            Thread.Sleep(2000);
            
            
        }
        
    }
}


