using System.Collections.Generic;

class GameManager
{
    private readonly SyncSet mSyncSet;
    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;
    private readonly SceneManager mSceneManager;

    public GameManager()
    {
        //SyncSet 멤버변수 초기화
        mSyncSet.newInputs = new HashSet<IInputable>();
        mSyncSet.deleteInputs = new HashSet<IInputable>();
        mSyncSet.newRenderers = new HashSet<Renderer>();
        mSyncSet.deleteRenderers = new HashSet<Renderer>();

        mInputManager = new InputManager();
        mRendererManager = new RendererManager();
        mSceneManager = new SceneManager(mSyncSet);
    }

    public void GameLoop()
    {
        while (true)

        {
            mSceneManager.Init();

            mInputManager.Input();

            mRendererManager.Render();

            //Sync
            SyncInputs();
            SyncRenderers();
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