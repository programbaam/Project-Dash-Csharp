class SceneManager
{
    private Scene ActiveScene;

    public void Init()
    {
        ActiveScene.Init();
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
    }
}
