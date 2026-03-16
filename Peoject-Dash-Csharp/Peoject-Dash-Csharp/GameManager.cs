using System.Collections.Generic;

class GameManager
{
    private readonly SyncSet mRendererSyncSet;
    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;

    public GameManager()
    {
        mRendererSyncSet.newRenderers = new HashSet<Renderer>();
        mRendererSyncSet.deleteRenderers = new HashSet<Renderer>();

        mRendererManager = new RendererManager();
        mInputManager = new InputManager();
    }

    public void GameLoop()
    {
        mInputManager.Input();

        mRendererManager.Render();
        SyncRenderers();
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