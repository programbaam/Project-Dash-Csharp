using System;

class TextRenderer : Renderer
{  
    private ConsolePoint mScrenPos;
    private string mText;

    public TextRenderer(int screnPosX, int screnPosY, string text)
    {
        mScrenPos.x = screnPosX;
        mScrenPos.y = screnPosY;
        mText = text;
    }

    override public void Draw()
    {
        Console.SetCursorPosition(mScrenPos.x, mScrenPos.y);
        Console.Write(mText);
    }
}

