using System;

class TextRenderer : Renderer
{  
    private ConsolePoint mScrenPos;
    private string mText;
   

    public TextRenderer(ConsolePoint screenPos, string text, bool isDrawing)
    {
        mScrenPos = screenPos;
        mText = text;
        IsDrawing = isDrawing;
        
    }

    override public void Draw()
    {
        if (IsDrawing)
        {
            Console.SetCursorPosition(mScrenPos.x, mScrenPos.y);
            Console.Write(mText);
        }
    }
}

