using System;
using System.Drawing;

class Obstacle: Actor
{   
    const float OBSTAC

    private float mObstacleSpeed;   
    private bool mGroundEnd=false;
    public override void Update()
    {
        if (mGroundEnd)
        {
            base.Release();
            base.Destroy();
        }
        

        Vector2D curruntPos = WorldLocation;

        curruntPos.x -= mObstacleSpeed * Time.DeltaTime;
        WorldLocation = curruntPos;
    }

    public void CheckCollision() 
    {
        //if()
    }

    public Obstacle(Vector2D worldLocation, string[] text2D, ConsoleColor color = ConsoleColor.White) : base(worldLocation, text2D, color)
    {
        mObstacleSpeed = 4.0f;
    }


}

