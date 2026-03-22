using System;
using System.IO;
using System.Text;
using System.Diagnostics;

class ScoreScene : Scene, IInputable
{
    private const int FIRST_SCORE_UI_POS_X = 0;
    private const int FIRST_SCORE_UI_POS_Y = 1;
    private const int SCORE_UI_INTERVAL_Y = 1;
    private const int SCORE_UI_INTERVAL_X = 7;
    private const int MAX_RANK = 20;

    private string[] mUserScores;
    private Widget[] mUserScoresUI; 
    private ConsolePoint screenPos;

    public static int sScore; 

    public ScoreScene()
    {
        SaveFile.CheckSaveFile();
        mUserScores = File.ReadAllLines(SaveFile.FilePath, Encoding.UTF8);

        Debug.Assert(mUserScores != null);
        if (mUserScores.Length > 0)
        { 
            SortScores();
        }
        mUserScoresUI = new Widget[mUserScores.Length]; 
        InitUserScores();
    }

    public void InitUserScores()
    {
        screenPos.x = FIRST_SCORE_UI_POS_X;
        screenPos.y = FIRST_SCORE_UI_POS_Y;

        NewGameObject(new Widget(screenPos, "점수화면", false));
        screenPos.y++;

        if (mUserScores.Length == 0)
        {
            screenPos.x = FIRST_SCORE_UI_POS_X;
            screenPos.y += SCORE_UI_INTERVAL_Y;
            NewGameObject(new Widget(screenPos, "아직 점수가 존재하지 않습니다!", false));
        }

        int visibleScoresCnt = Math.Min(mUserScoresUI!.Length, MAX_RANK);

        for (int i = 0; i < visibleScoresCnt; ++i)
        {
            screenPos.x = FIRST_SCORE_UI_POS_X;
            screenPos.y += SCORE_UI_INTERVAL_Y;

            NewGameObject(new Widget(screenPos, $"{i + 1,2}.", false));

            screenPos.x += SCORE_UI_INTERVAL_X;
            mUserScoresUI[i] = new Widget(screenPos, mUserScores[i], false);
            NewGameObject(mUserScoresUI[i]);
        }

        screenPos.x = FIRST_SCORE_UI_POS_X;
        screenPos.y += 2;
        NewGameObject(new Widget(screenPos, "ESC 키를 눌러 메뉴화면으로 돌아갈 수 있습니다.", false));
    }
    public void Input()
    {
        if (InputManager.IsCurrentKeyDown(EVirtualKey.ESC))
        { 
            GameManager.mSyncSet.scene = EScene.Menu;
            GameManager.mSyncSet.isChangeScene = true;
        }
    }

    private void SortScores()
    {
        int[] userScoresIntVer = new int[mUserScores.Length];

        for (int i = 0; i < userScoresIntVer.Length; ++i)
        {
            if (int.TryParse(mUserScores[i], out int userScore) == false)
            {
                userScore = -1;
            }

            Debug.Assert(userScore >= 0);
            userScoresIntVer[i] = userScore;
        }

        Array.Sort(userScoresIntVer, (a, b) => b.CompareTo(a));

        for (int i = 0; i < userScoresIntVer.Length; ++i)
        {
            mUserScores[i] = userScoresIntVer[i].ToString("N0");
        }
    }
}