using System.Collections.Generic;

class GameManager
{
    static public SyncSet mSyncSet;
    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;
    private readonly SceneManager mSceneManager;

    public GameManager()
    {
        //SyncSet 멤버변수 초기화
        GameManager.mSyncSet.newInputs = new HashSet<IInputable>();
        GameManager.mSyncSet.deleteInputs = new HashSet<IInputable>();
        GameManager.mSyncSet.newRenderers = new HashSet<Renderer>();
        GameManager.mSyncSet.deleteRenderers = new HashSet<Renderer>();

        mInputManager = new InputManager();
        mRendererManager = new RendererManager();
        mSceneManager = new SceneManager();
    }

    public void GameLoop()
    {
        while (true)

        {
            // Init
            mSceneManager.Init();

            // Input
            mInputManager.Input();

            // Update

            //Sync
            SyncInputs();
            SyncRenderers();

            //Render
            mRendererManager.Render();


            //Destroy

        }
    }

    public void SyncInputs()
    {
        HashSet<IInputable> newInputs = mSyncSet.newInputs;
        HashSet<IInputable> deleteInputs = mSyncSet.deleteInputs;

        mInputManager.UnionWithNewInputs(newInputs);
        mInputManager.ExceptWithDeleteInputs(deleteInputs);

        newInputs.Clear();
        deleteInputs.Clear();
    }

    public void SyncRenderers()
    {
        HashSet<Renderer> newRenderers = mSyncSet.newRenderers;
        HashSet<Renderer> deleteRenderers = mSyncSet.deleteRenderers;
        
        mRendererManager.UnionWithNewRenderers(newRenderers);
        mRendererManager.ExceptWithDeleteRenderers(deleteRenderers);

        newRenderers.Clear();
        deleteRenderers.Clear();
    }
}