class Widget : GameObject
{
    protected ConsolePoint mScreenPos;
    protected TextRenderer mTextRenderer;


    public Widget(ConsolePoint consolePoint, string text)
    {
        mScreenPos = consolePoint;

        mTextRenderer = new TextRenderer(consolePoint, text);
        NewComponemt(mTextRenderer);
    }



    // TODO: Update 함수 구현 해야함
    public override void Update()
    {
    }

    // TODO: Destroy 함수 구현 해야함. base.Destroy();

}

