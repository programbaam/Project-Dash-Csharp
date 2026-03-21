using System.Diagnostics;

class RigidBody2D : Component
{
    // TODO : 추후 const로 변할 가능성 있음
    private float mGravity;
    private float mTopY;
    private float mGroundY;
    private float mVelocityY;
    public bool IsPhysicsActive { get; set; }

    public RigidBody2D(float gravity, float topY, float groundY)
    { 
        mGravity = gravity;
        mTopY = topY;
        mGroundY = groundY;
        mVelocityY = 0;
        IsPhysicsActive = false;
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

    public void UpdatePositionY(ref Vector2D pos)
    {
        if (IsPhysicsActive == false)
        {
            return;
        }

        UpdateVelocityY();
        pos.y += mVelocityY * Time.DeltaTime;
         
        if (pos.y <= mTopY)
        {
            pos.y = mTopY;
        }

        if (pos.y >= mGroundY)
        {
            pos.y = mGroundY;
            mVelocityY = 0;
            IsPhysicsActive=false;
        }
    }
}