//TODO : 커서구현
using static System.Net.Mime.MediaTypeNames;

class Widget : GameObject
{
    private const int LOCAL_CONTENTS_POS_X = 4; 

    protected ConsolePoint mScreenPos;
    protected TextRenderer mContentsRenderer;
    protected TextRenderer mCursorRenderer;

    public bool IsVisible {  get; set; }

    public Widget(ConsolePoint consolePoint, string text, bool isVisible)
    {
        IsVisible = isVisible;

        mCursorRenderer = new TextRenderer(consolePoint, "▶", IsVisible);
        NewComponemt(mCursorRenderer);

        consolePoint.x += LOCAL_CONTENTS_POS_X;
       
        mContentsRenderer = new TextRenderer(consolePoint, text, IsVisible=true);
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

