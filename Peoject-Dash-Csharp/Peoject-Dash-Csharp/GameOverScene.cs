using System.Diagnostics;

class GameOverScene : Scene, IInputable
{
    private const int FIRST_MENU_UI_POS_X = 0;
    private const int FIRST_MENU_UI_POS_Y = 0;
    private const int GAME_OVER_UI_INTERVAL_Y = 2;

    private Widget[] mGameOverUIs;
   

    private int mScore;
    private string mScoreText;
    string[] gameOverUINames = new string[(int)EGameOverUI.Max];

    public GameOverScene()
    {
        mScore = ScoreScene.sScore;
        mScoreText = mScore.ToString();
        InitGameoverScene();
    }
    private void InitGameoverScene()
    {

        ConsolePoint consolePoint;

        consolePoint.x = FIRST_MENU_UI_POS_X;
        consolePoint.y = FIRST_MENU_UI_POS_Y;

        gameOverUINames[(int)EGameOverUI.GameOver] = "게임오버";
        gameOverUINames[(int)EGameOverUI.Score] = mScoreText;
        gameOverUINames[(int)EGameOverUI.Message] = "게임종료 : ESC 키";

        mGameOverUIs = new Widget[(int)EGameOverUI.Max];

        Debug.Assert(mGameOverUIs.Length == gameOverUINames.Length);

        for (int i = 0; i < (int)EGameOverUI.Max; i++)
        {
            Debug.Assert(gameOverUINames[i] != null);

            mGameOverUIs[i] = new Widget(consolePoint, gameOverUINames[i], false);
            NewGameObject(mGameOverUIs[i]);

            consolePoint.y += GAME_OVER_UI_INTERVAL_Y;
        }
    }

    public void Input() 
    {
        if (InputManager.IsCurrentKeyDown(EVirtualKey.ESC))
        {
            GameManager.mSyncSet.scene = EScene.Menu;
            GameManager.mSyncSet.isChangeScene = true;
        }
    }

    public void Update()
    {
        base.Update();
    }





}

    
    

