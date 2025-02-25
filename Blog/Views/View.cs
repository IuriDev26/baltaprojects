using System.Text;

namespace Blog.Views;

public abstract class View
{
    public string WriteHeaderText(string message)
    {
        var text = new StringBuilder();

        text.AppendLine(new string('-', Console.WindowWidth));
        text.AppendLine($"\n{message}\n");
        text.AppendLine(new string('-', Console.WindowWidth));
        
        return text.ToString();
    }
}