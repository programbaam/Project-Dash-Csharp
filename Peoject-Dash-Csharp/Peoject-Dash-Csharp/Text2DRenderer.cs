using System;
using System.Diagnostics;

class Text2DRenderer : Renderer
{
    private ConsolePoint mScreenPos;
    private string[] mText2D;

    public override void Draw()
    {
        if (IsDrawing == false)
        {
            return;
        }

        Debug.Assert(mText2D != null);
        for (int i = 0; i < mText2D.Length; i++)
        {
            Console.SetCursorPosition(mScreenPos.x, mScreenPos.y + i);
            Console.Write(mText2D[i]);
        }
    }

    public Text2DRenderer(ConsolePoint screenPos, string[] text2D, bool isDrawing = true)
    {
        mScreenPos = screenPos;
        IsDrawing = isDrawing;

        mText2D = text2D;
    }
}

