
using System;

class Player : Actor, IInputable
{
    private RigidBody2D mRigidBody2D;
    private float mJumpPower;
    private bool mIsJumping;
    public void Input()
    {
        if (mIsJumping == false && InputManager.IsCurrentKeyDown(EVirtualKey.SPACE))
        {
            mIsJumping = true;
            mRigidBody2D.AddVelocityY(mJumpPower);
        }
    }

    public override void Update()
    {
        if (mIsJumping)
        {
            if (mRigidBody2D.IsPhysicsActive)
            {
                Vector2D currentLocation = WorldLocation;
                mRigidBody2D.UpdatePositionY(ref currentLocation);

                WorldLocation = currentLocation;
            }

            if (mRigidBody2D.IsPhysicsActive == false)
            {
                mIsJumping = false;
            }
        }
    }

    public Player(Vector2D worldLocation, string[] text2D, float jumpPower,ConsoleColor color = ConsoleColor.White) : base(worldLocation, text2D, color)
    {
        mJumpPower = jumpPower;
        mIsJumping = false;
        mRigidBody2D = new RigidBody2D(gravity: 0.0625f, topY: 3.0f, groundY: 12.0f);
    }

}

