using System.Diagnostics;

class RigidBody2D : Component
{
    // TODO : 추후 const로 변할 가능성 있음
    private float mGravity;
    private float mGroundY;
    private float mVelocityY;
    private readonly Renderer mRenderer;
    public bool IsPhysicsActive { get; set; }

    public RigidBody2D(Renderer renderer)
    { 
        Debug.Assert(renderer != null);
        mRenderer = renderer;
    }

    public void AddVelocityY(float velocityY)
    { 
        mVelocityY -= velocityY;
        IsPhysicsActive = true;
    }

    public void UpdateVelocityY()
    {
        if (IsPhysicsActive == false)
        {
            return;
        }

        mVelocityY += mGravity * Time.DeltaTime;
    }

    public void UpdatePositionY()
    {
        if (IsPhysicsActive == false)
        {
            return;
        }

        float positionY = mRenderer.mVector2D.y;
        positionY += mVelocityY * Time.DeltaTime;

        if (positionY >= mGroundY)
        {
            positionY = mGroundY;
            mVelocityY = 0;
            IsPhysicsActive=false;
        }

        mRenderer.mVector2D.y = positionY;
    }
}