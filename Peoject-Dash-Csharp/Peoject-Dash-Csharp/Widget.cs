//TODO : 커서구현
class Widget : GameObject
{
    protected ConsolePoint mScreenPos;
    protected TextRenderer mContentsRenderer;
    protected TextRenderer mCursorRenderer;

    public bool IsCursorVisible {  get; set; }

    
    public Widget(ConsolePoint consolePoint, string text, bool isCursorVisibe = false)
    {
        IsCursorVisible = isCursorVisibe;

        mScreenPos = consolePoint;

        mCursorRenderer = new TextRenderer(consolePoint, "▶");
        NewComponemt(mCursorRenderer);

        mContentsRenderer = new TextRenderer(consolePoint, text);
        NewComponemt(mContentsRenderer);
    }



    // TODO: Update 함수 구현 해야함
    public override void Update()
    {
    }

    // TODO: Destroy 함수 구현 해야함. base.Destroy();
    public override void Destroy()
    {
        base.Destroy();
    }

}

