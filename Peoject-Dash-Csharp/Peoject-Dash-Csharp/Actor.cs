class Actor : GameObject
{
    private Vector2D mWorldLocation;
    private Text2DRenderer mText2D;

    public bool IsVisible
    {
        get => mText2D.IsDrawing;
        set => mText2D.IsDrawing = value;
    }
    public override void Update()
    {
        
    }

    Actor(Vector2D worldLocation, string[] text2D)
    {
        this.mWorldLocation = worldLocation;

        ConsolePoint screenPos;

        screenPos.x = (int)worldLocation.x;
        screenPos.y = (int)worldLocation.y;

        this.mText2D = new Text2DRenderer(screenPos, text2D);
    }
}

