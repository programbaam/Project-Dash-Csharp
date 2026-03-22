using System;
using System.Drawing;

class Obstacle: Actor
{
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
    }

    

    public Obstacle(Vector2D worldLocation, string[] text2D, ConsoleColor color = ConsoleColor.White) : base(worldLocation, text2D, color)
    {
        mObstacleSpeed = OBSTACLE_SPEED;
    }


}

