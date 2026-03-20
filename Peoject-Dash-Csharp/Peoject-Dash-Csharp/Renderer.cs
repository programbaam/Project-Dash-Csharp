abstract class Renderer : Component
{
    public Vector2D mVector2D;
    public bool IsDrawing { get; set; }
    public abstract void Draw();
}