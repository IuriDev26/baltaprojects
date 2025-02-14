namespace HtmlEditor;

public class Menu
{
    
    static int WindowWidth = Console.WindowWidth;
    static int WindowHeight = Console.WindowHeight;
    static int LastLeftPosition = 2;
    static int LastTopPosition = 2;
    
    public static void Start()
    {
        
        DrawMenuBox();
        string menuText = @"
        1 - Abrir Arquivo
        2 - Criar Novo Arquivo
        3 - Listar Arquivos
        4 - Editar Arquivo
        5 - Excluir Arquivo
        0 - Sair";
        
        WriteTextInMenuBox("Editor HTML");
        WriteTextInMenuBox("Seja Bem Vindo" + Environment.NewLine);
        WriteTextInMenuBox(menuText.Trim());
        
    }

    static void DrawMenuBox()
    {
        
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.Write("+");
        Console.Write(new string('=', WindowWidth - 2));
        Console.Write("+");

        for (int i = 0; i < Console.WindowHeight - 3; i++)
        {
            Console.Write('|');
            Console.Write(new string(' ', WindowWidth - 2));
            Console.Write("|");
        }

        Console.Write("+");
        Console.Write(new string('=', WindowWidth - 2));
        Console.Write("+");
        
        
    }

    static void WriteTextInMenuBox(string text)
    {
        
        string[] lines = text.Trim().Split('\n');
        
        for ( int i = 0; i < lines.Length; i++ )
        {
            Console.SetCursorPosition(LastLeftPosition, LastTopPosition++);
            Console.Write(lines[i]);
        }
        
        Console.SetCursorPosition(WindowWidth + 1, WindowHeight - 2);
        
    }
    
    
}