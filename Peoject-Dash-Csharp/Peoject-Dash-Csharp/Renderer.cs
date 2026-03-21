abstract class Renderer : Component
{
    public Vector2D mVector2D;

    private bool mIsDrawing;
    public bool IsDrawing
    {        
        get => mIsDrawing;
        set => mIsDrawing = value;
    }
    public abstract void Draw();
}