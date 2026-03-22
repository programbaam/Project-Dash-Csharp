
using System;

class GameScene : Scene
{
    private readonly Widget mScoreWidget;
    private readonly Player mPlayer;
    private readonly Obstacle mObstacle;
    private readonly Actor mGround;
    public override void Update()
    {
        base.Update();
    }

    public GameScene()
    {
        ConsolePoint consolePoint;
        Vector2D worldLocation;

        //Widget 사용시 LOCAL_CONTENTS_POS_X 값만큼 빼줘야 함
        consolePoint.x = 74 - 4;
        consolePoint.y = 1;

        NewGameObject(new Widget(consolePoint, "게임 점수 :", false));

        consolePoint.x = 86 - 4;
        consolePoint.y = 1;

        //TODO 실시간 변화하는 위젯 만들어야 함
        mScoreWidget = new Widget(consolePoint, $"{Time.DeltaTime,13:N0}", false);
        NewGameObject(mScoreWidget);

        consolePoint.x = 0 - 4;
        consolePoint.y = 3;

        string Divider = "".PadRight(GameManager.ConsoleWidth, '-'); //Console.Width

        NewGameObject(new Widget(consolePoint, Divider, false));

        //Player
        string[] playerTexts =
        {
            " * ",
            "***",
            "* *"
        };

        worldLocation.x = 5.0f;
        worldLocation.y = 13.0f;

        mPlayer = new Player(worldLocation: worldLocation,text2D: playerTexts, jumpPower: 10, color: ConsoleColor.Magenta);
        NewGameObject(mPlayer);

        //Obstacle
        string[] obstacleTexts =
        {
            "****",
            " ** ",
            " ** ",
            " ** ",
        };

        worldLocation.x = 50.0f;
        worldLocation.y = 12.0f;
        mObstacle = new Obstacle(worldLocation: worldLocation, text2D: obstacleTexts, color: ConsoleColor.Blue);
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

        consolePoint.x = 0 - 4;
        consolePoint.y = 20;

        NewGameObject(new Widget(consolePoint, Divider, false));

        consolePoint.x = 0 - 4;
        consolePoint.y = 21;

        NewGameObject(new Widget(consolePoint, "게임종료 : ESC 키", false));
    }
}

