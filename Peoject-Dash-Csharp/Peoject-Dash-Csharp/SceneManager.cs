using System;
using System.Collections;
using System.Diagnostics;

class SceneManager
{
    private Scene ActiveScene;
    private EScene mCurrentScene;

    public SceneManager()
    { 
        ActiveScene = new MenuScene();
        mCurrentScene = EScene.Menu;
        InitScene();
    }
    public void Init()
    {
        ActiveScene.Init();
    }

    public void InitScene() 
    {
        Debug.Assert(ActiveScene != null);
       
        if (ActiveScene is IInputable inputable)
        {
            GameManager.mSyncSet.newInputs.Add(inputable);
        }
    }

    public void Update()
    {
        ActiveScene.Update();
    }

    public void Delete()
    {
        if (ActiveScene is IInputable inputable)
        {
            GameManager.mSyncSet.deleteInputs.Add(inputable);
        }
    }
    public void Destroy()
    {
        ActiveScene.Destroy();
    }
    
    public void ChangeScene(EScene sceneName)
    {
        mCurrentScene = sceneName;             

        switch (mCurrentScene)
        {
            case EScene.Menu:
                {
                    Delete();
                    ActiveScene.Release();
                    ActiveScene.Destroy();
                    ActiveScene = new MenuScene();
                    InitScene();
                    break;
                }
            case EScene.Game:
                {
                    Delete();
                    ActiveScene.Release();
                    ActiveScene.Destroy();
                    ActiveScene =new GameScene();
                    InitScene();
                    break;
                }
            case EScene.Score:
                {
                    Delete();
                    ActiveScene.Release();
                    ActiveScene.Destroy();
                    ActiveScene = new ScoreScene();
                    InitScene();
                    break;
                }
            case EScene.GameOver:
                {
                    
                    Delete();
                    ActiveScene.Release();
                    ActiveScene.Destroy();
                    ActiveScene = new GameOverScene();
                    InitScene();
                    break;
                }
            default:
                {
                    Debug.Assert(false, "없는 씬");
                    break;
                }
        }
    }






}
