using System;
using System.Diagnostics;

class Text2DRenderer : Renderer
{
    private ConsolePoint mScreenPos;
    private string[] mText2D;
    private ConsoleColor mColor;

    public ConsolePoint ScreenPos
    {
        get =>mScreenPos; 
        set =>mScreenPos = value;
    }

    public override void Draw()
    {
        if (IsDrawing == false)
        {
            return;
        }
        
        Debug.Assert(mText2D != null);

        if (mScreenPos.x < 0 || mScreenPos.y < 0)
        {
            return;
        }

        Console.ForegroundColor = mColor;
        for (int i = 0; i < mText2D.Length; i++)
        {
            Console.SetCursorPosition(mScreenPos.x, mScreenPos.y + i);
            Console.Write(mText2D[i]);
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public Text2DRenderer(ConsolePoint screenPos, string[] text2D, ConsoleColor color = ConsoleColor.White,bool isDrawing = true)
    {
        mScreenPos = screenPos;
        IsDrawing = isDrawing;
        mColor = color;

        mText2D = text2D;
    }
}

