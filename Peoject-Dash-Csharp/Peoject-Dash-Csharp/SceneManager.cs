using System.Diagnostics;

class SceneManager
{
    private Scene ActiveScene;

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

    public void Destroy()
    {
        ActiveScene.Destroy();
    }

    public SceneManager()
    { 

        ActiveScene = new MenuScene();
        InitScene();
    }
}
