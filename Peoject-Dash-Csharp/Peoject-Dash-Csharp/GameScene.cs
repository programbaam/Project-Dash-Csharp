
using System;

class GameScene : Scene
{
    private readonly Player mPlayer;
    private readonly Actor mObstacle;
    private readonly Actor mGround;
    public override void Update()
    {
        base.Update();
    }

    public GameScene()
    {
        string[] playerTexts =
        {
            " * ",
            "***",
            "* *"
        };

        Vector2D worldLocation;
        worldLocation.x = 5.0f;
        worldLocation.y = 12.0f;

        mPlayer = new Player(worldLocation: worldLocation,text2D: playerTexts, jumpPower: 10, color: ConsoleColor.Magenta);
        NewGameObject(mPlayer);

        string[] obstacleTexts =
        {
            "****",
            " ** ",
            " ** ",
            " ** ",
        };

        worldLocation.x = 50.0f;
        worldLocation.y = 12.0f;
        mObstacle = new Actor(worldLocation: worldLocation, text2D: obstacleTexts, color: ConsoleColor.Blue);
        NewGameObject(mObstacle);


        worldLocation.x = 0.0f;
        worldLocation.y = 16.0f;

        string groundPad = "".PadRight(GameManager.ConsoleWidth, '*'); //Console.Width

        string[] groundTexts =
        {
            groundPad,
            groundPad,
            groundPad,
            groundPad,
        };

        mGround = new Actor(worldLocation: worldLocation, text2D: groundTexts, color: ConsoleColor.Green);
        NewGameObject(mGround);
    }
}

