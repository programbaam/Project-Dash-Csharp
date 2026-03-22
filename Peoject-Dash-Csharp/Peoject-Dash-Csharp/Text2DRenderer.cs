using System;
using System.Diagnostics;

class Text2DRenderer : Renderer
{
    

    private ConsolePoint mScreenPos;
    private string[] mText2D;
    private string mColor;

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

        for (int i = 0; i < mText2D.Length; i++)
        {
            if (mColor == RendererManager.RESET)
            {
                RendererManager.InsertTextToStringBuilder(iCol: mScreenPos.x, iRow: mScreenPos.y + i, text: mText2D[i]);
            }
            else
            {
                RendererManager.InsertTextToStringBuilder(iCol: mScreenPos.x, iRow: mScreenPos.y + i, text: mText2D[i], color: mColor);
            }
        }

    }

    public Text2DRenderer(ConsolePoint screenPos, string[] text2D, string color = RendererManager.RESET,bool isDrawing = true)
    {
        mScreenPos = screenPos;
        IsDrawing = isDrawing;
        mColor = color;

        mText2D = text2D;
    }
}

