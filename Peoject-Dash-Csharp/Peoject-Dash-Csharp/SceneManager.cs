class SceneManager
{
    private SyncSet mSyncSet;

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

    public SceneManager(SyncSet syncSet)
    {
        mSyncSet = syncSet;
        ActiveScene = new MenuScene(mSyncSet);
    }
}
