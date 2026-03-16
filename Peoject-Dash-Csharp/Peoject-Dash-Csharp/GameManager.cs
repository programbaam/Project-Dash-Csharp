using System.Collections.Generic;

class GameManager
{
    private readonly SyncSet mRendererSyncSet;
    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;

    public GameManager()
    {
        //SyncSet 멤버변수 초기화
        mRendererSyncSet.newInputs = new HashSet<IInputable>();
        mRendererSyncSet.deleteInputs = new HashSet<IInputable>();
        mRendererSyncSet.newRenderers = new HashSet<Renderer>();
        mRendererSyncSet.deleteRenderers = new HashSet<Renderer>();

        mInputManager = new InputManager();
        mRendererManager = new RendererManager();
    }

    public void GameLoop()
    {
        mInputManager.Input();

        mRendererManager.Render();

        //Sync
        SyncInputs();
        SyncRenderers();
    }

    public void SyncInputs()
    {
        HashSet<IInputable> newInputs = mRendererSyncSet.newInputs;
        HashSet<IInputable> deleteInputs = mRendererSyncSet.deleteInputs;

        mInputManager.UnionWithNewInputs(newInputs);
        mInputManager.ExceptWithDeleteInputs(deleteInputs);

        newInputs.Clear();
        deleteInputs.Clear();
    }

    public void SyncRenderers()
    {
        HashSet<Renderer> newRenderers = mRendererSyncSet.newRenderers;
        HashSet<Renderer> deleteRenderers = mRendererSyncSet.deleteRenderers;
        
        mRendererManager.UnionWithNewRenderers(newRenderers);
        mRendererManager.ExceptWithDeleteRenderers(deleteRenderers);

        newRenderers.Clear();
        deleteRenderers.Clear();
    }
}