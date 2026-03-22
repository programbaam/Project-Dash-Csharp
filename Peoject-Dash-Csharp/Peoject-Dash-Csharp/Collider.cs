class Collider : Component
{
    private Vector2D mWorldLocation;
    private Rect mRect;

    private Vector2D WorldLocation
    {
        get => mWorldLocation; 
        set => mWorldLocation = value;
    }
    private Rect WorldRect => new Rect(
        mRect.left + mWorldLocation.x,
        mRect.right + mWorldLocation.x,
        mRect.top + mWorldLocation.y,
        mRect.bottom + mWorldLocation.y);
        

    public ELayerTag LayerTag { get; }

    public bool CanCollisionWith(Collider other)
    {
        return CollisionManager.GetLayerTable(LayerTag, other.LayerTag);
    }

    public bool IsOverlap(Collider other)
    {
        if (CanCollisionWith(other) == false)
        {
            return false;
        }

        Rect thisRect = this.WorldRect;
        Rect otherRect = other.WorldRect;

        bool xOverlap = GameMath.IsNearlyLessOrEqual(thisRect.left, otherRect.right) &&
                        GameMath.IsNearlyGreaterOrEqual(thisRect.right, otherRect.right);
        bool yOverlap = GameMath.IsNearlyLessOrEqual(thisRect.top, otherRect.bottom) &&
                        GameMath.IsNearlyGreaterOrEqual(thisRect.bottom, otherRect.top);

        //AABB 체크 함수
        return xOverlap && yOverlap;
    }

}

