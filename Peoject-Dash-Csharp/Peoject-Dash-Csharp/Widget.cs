//TODO : 커서구현
using static System.Net.Mime.MediaTypeNames;

class Widget : GameObject
{
    private const int LOCAL_CONTENTS_POS_X = 4; 

    protected ConsolePoint mScreenPos;
    protected TextRenderer mContentsRenderer;
    protected TextRenderer mCursorRenderer;

    public bool IsCursorVisible {  get; set; }

    public Widget(ConsolePoint consolePoint, string text, bool isCursorVisible = false)
    {
        IsCursorVisible = isCursorVisible;

        mCursorRenderer = new TextRenderer(consolePoint, "▶");
        NewComponemt(mCursorRenderer);

        consolePoint.x += LOCAL_CONTENTS_POS_X;

        mContentsRenderer = new TextRenderer(consolePoint, text);
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

