//TODO : 커서구현
using static System.Net.Mime.MediaTypeNames;

class Widget : GameObject
{
    private const int LOCAL_CONTENTS_POS_X = 4;       

    protected ConsolePoint mScreenPos;
    protected TextRenderer mContentsRenderer;
    protected TextRenderer mCursorRenderer;

    private bool mIsCursorVisible;

    public bool IsCursorVisible 
    {
        get => mIsCursorVisible;
        set
        {
            mIsCursorVisible = value;
            mCursorRenderer.IsDrawing = mIsCursorVisible;
        }
    }

    public Widget(ConsolePoint consolePoint, string text, bool isVisible)
    {
        
        mCursorRenderer = new TextRenderer(consolePoint, "▶", isVisible);
        NewComponemt(mCursorRenderer);       


        consolePoint.x += LOCAL_CONTENTS_POS_X;
       
        mContentsRenderer = new TextRenderer(consolePoint, text, true);
        NewComponemt(mContentsRenderer);
    }


    
    // TODO: Update 함수 구현 해야함
    public override void Update()
    {        
      
    }

    

    public override void Destroy()
    {
        base.Destroy();
    }

}

