using System;
using System.Drawing;

class Obstacle: Actor, ICollidable
{
    private Collider mCollider;

    const float OBSTACLE_SPEED = 4.0f;
    const float ADD_OBSTACLE_SPEED = 2.0f;

    private float mObstacleSpeed;
    //장애물 가속도
    private float mAddObstacleSpeed;

    private bool mGroundEnd;
  
    

    public override void Update()
    {
        mGroundEnd = false;
        if (mGroundEnd)
        {
            base.Release();
            base.Destroy();
            
        }

        AddObstacleSpeed(mObstacleSpeed);

        Vector2D curruntPos = WorldLocation;

        curruntPos.x -= mObstacleSpeed * Time.DeltaTime;

        WorldLocation = curruntPos;
        mCollider.WorldLocation = curruntPos;
    }

    public float AddObstacleSpeed(float currentSpeed)
    {
        mAddObstacleSpeed = ADD_OBSTACLE_SPEED;
        mObstacleSpeed = currentSpeed + mAddObstacleSpeed;
        return mObstacleSpeed;
    }

    public void OnCollision()
    {
        base.Release();
        base.Destroy();
    }



    public Obstacle(Vector2D worldLocation, string[] text2D, ConsoleColor color = ConsoleColor.White) : base(worldLocation, text2D, color)
    {
        mObstacleSpeed = OBSTACLE_SPEED;

        Rect rect;
        rect.left = 0.0f;
        rect.right = text2D[0].Length;
        rect.top = 0.0f;
        rect.bottom = text2D.Length;

        mCollider = new Collider(worldLocation, rect, ELayerTag.Obstacle);
        NewComponemt(mCollider);
    }


}

