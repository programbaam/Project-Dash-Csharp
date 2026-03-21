using System;
using System.IO;
using System.Text;
using System.Diagnostics;

class ScoreScene : Scene
{
    private const int FIRST_SCORE_UI_POS_X = 0;
    private const int FIRST_SCORE_UI_POS_Y = 1;
    private const int SCORE_UI_INTERVAL_Y = 1;
    private const int SCORE_UI_INTERVAL_X = 7;

    private string[] mUserScores;
    private Widget[] mUserScoresUI;
    private ConsolePoint screenPos;

    public ScoreScene()
    {
        mUserScores = File.ReadAllLines("resource/UserScores.csv", Encoding.UTF8);
        Debug.Assert(mUserScores != null);
        SortScores();
        mUserScoresUI = new Widget[mUserScores.Length];
        InitUserScores();
    }

    public void InitUserScores()
    {
        screenPos.x = FIRST_SCORE_UI_POS_X;
        screenPos.y = FIRST_SCORE_UI_POS_Y;

        Widget MenuTpye = new Widget(screenPos, "점수화면", false);
        NewGameObject(MenuTpye);
        screenPos.y++;

        for (int i = 0; i < mUserScoresUI!.Length; ++i)
        {
            screenPos.x = FIRST_SCORE_UI_POS_X;
            screenPos.y += SCORE_UI_INTERVAL_Y;

            Widget rank = new Widget(screenPos, $"{i + 1,3}.", false);
            NewGameObject(rank);

            screenPos.x += SCORE_UI_INTERVAL_X;
            mUserScoresUI[i] = new Widget(screenPos, mUserScores[i], false);
            NewGameObject(mUserScoresUI[i]);
        }
    }

    //TODO SaveUserScore 구현해야함
    public void SaveUserScore()
    {
        mUserScores = new string[mUserScores.Length];
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