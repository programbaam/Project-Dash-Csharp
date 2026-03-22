using System.IO;
using static System.Formats.Asn1.AsnWriter;

class GameScene : Scene
{
    private readonly Widget mScoreWidget;
    private readonly Player mPlayer;
    private readonly Obstacle mObstacle;
    private readonly Actor mGround; 
    private int mScore;

    public override void Update()
    {
        base.Update();

        Time.GameTime += Time.DeltaTime;
        mScore = (int)(Time.GameTime * 10);
        UpdateScore(mScore);
        
        if (mPlayer.LifeCounter == 0)
        {
            
            ScoreScene.sScore = mScore-1;
            SaveScore(mScore -1); //사용자가 보는 마지막 점수와 (0.16) DeltaTime 차이(1점차이)
            
            GameManager.mSyncSet.isChangeScene = true;
            GameManager.mSyncSet.scene = EScene.GameOver;
        }
    }

    public GameScene()
    {
        mScore = 0;
        Time.GameTime =0;

        ConsolePoint consolePoint;
        Vector2D worldLocation;
        

        //Widget 사용시 LOCAL_CONTENTS_POS_X 값만큼 빼줘야 함
        consolePoint.x = 70 - 4;
        consolePoint.y = 1;

        NewGameObject(new Widget(consolePoint, "게임 점수 :", false));

        consolePoint.x = 82 - 4;
        consolePoint.y = 1;

        mScore = 0;
        mScoreWidget = new Widget(consolePoint, $"{mScore,13:N0}", false);
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

        mPlayer = new Player(worldLocation: worldLocation,text2D: playerTexts, jumpPower: 13.0f, color: RendererManager.RED);
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
        mObstacle = new Obstacle(worldLocation: worldLocation, text2D: obstacleTexts, color: RendererManager.BLUE);
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

        mGround = new Actor(worldLocation: worldLocation, text2D: groundTexts, color: RendererManager.GREEN);
        NewGameObject(mGround);

        consolePoint.x = 0 - 4;
        consolePoint.y = 20;

        NewGameObject(new Widget(consolePoint, Divider, false));

        consolePoint.x = 0 - 4;
        consolePoint.y = 22;

        NewGameObject(new Widget(consolePoint, "게임조작 : SPACE BAR 키로 점프", false));

        consolePoint.x = 0 - 4;
        consolePoint.y = 23;

        NewGameObject(new Widget(consolePoint, "게임종료 : ESC 키", false));
    }

    public void UpdateScore(int score)
    {
        mScoreWidget.UpdateText($"{score,13:N0}");
    }

    public void SaveScore(int score)
    {
        SaveFile.CheckSaveFile();

        string userScore = $"{score}\n";
        File.AppendAllText("resource/UserScores.csv", userScore);
    }
}

