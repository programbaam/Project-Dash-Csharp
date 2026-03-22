using System;
using System.Text;

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
            RendererManager.InsertTextToStringBuilder(iCol: mScrenPos.x, iRow: mScrenPos.y ,text: mText);
        }
    }

    public void UpdateText(string text)
    {
        mText = text;
    }
}

