
using System;

class Player : Actor, IInputable, ICollidable
{
    const int LIFE_COUNTER = 1;

    private RigidBody2D mRigidBody2D;
    private float mJumpPower;
    private bool mIsJumping;
    private Collider mCollider;
    
    public int LifeCounter { get; set; }
    

    public void Input()
    {
        if (InputManager.IsCurrentKeyDown(EVirtualKey.ESC))
        {
            GameManager.mSyncSet.scene = EScene.Menu;
            GameManager.mSyncSet.isChangeScene = true;
        }

        if (mIsJumping == false && InputManager.IsCurrentKeyDown(EVirtualKey.SPACE))
        {
            mIsJumping = true;
            mRigidBody2D.AddVelocityY(mJumpPower);
        }
    }

    public void OnCollision()
    {
        LifeCounter--;       
        
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
                mCollider.WorldLocation = currentLocation;
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
        mRigidBody2D = new RigidBody2D(gravity: 1f, topY: 5.0f, groundY: 13.0f);
        NewComponemt(mRigidBody2D);

        Rect rect;
        rect.left = 0.0f;
        rect.right = text2D[0].Length;
        rect.top = 0.0f;
        rect.bottom = text2D.Length;

        mCollider = new Collider(worldLocation, rect, ELayerTag.Player);
        NewComponemt(mCollider);


        LifeCounter = LIFE_COUNTER;

    }

}

