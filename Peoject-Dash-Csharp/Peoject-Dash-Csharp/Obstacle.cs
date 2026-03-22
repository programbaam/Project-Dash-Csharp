using System;
using System.Drawing;

class Obstacle: Actor, ICollidable
{
    private Collider mCollider;

    const float OBSTACLE_SPEED = 4.0f;

    private float mObstacleSpeed;   
    private bool mGroundEnd=false;
    public override void Update()
    {
        if (mGroundEnd)//게임씬???
        {
            base.Release();
            base.Destroy();
            //점수 획득???
        }       

        Vector2D curruntPos = WorldLocation;

        curruntPos.x -= mObstacleSpeed * Time.DeltaTime;

        WorldLocation = curruntPos;
        mCollider.WorldLocation = curruntPos;
    }

    public void OnCollision()
    {

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

