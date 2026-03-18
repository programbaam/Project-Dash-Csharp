using System;

class TextRenderer : Renderer
{  
    private ConsolePoint mScrenPos;
    private string mText;

    public TextRenderer(ConsolePoint screenPos, string text)
    {
        mScrenPos = screenPos;
        mText = text;
    }

    override public void Draw()
    {
        Console.SetCursorPosition(mScrenPos.x, mScrenPos.y);
        Console.Write(mText);
    }
}

