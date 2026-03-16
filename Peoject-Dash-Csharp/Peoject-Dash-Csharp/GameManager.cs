using System.Collections.Generic;

class GameManager
{
    private readonly RendererSyncSet mRendererSyncSet;
    private RendererManager mRendererManager;

    public GameManager(RendererManager rendererManager)
    {
        mRendererManager = rendererManager;
    }

    public void GameLoop()
    {
        mRendererManager.Render();
    }

    public void SyncRenderers()
    {
        HashSet<Renderer> newRenderers = mRendererSyncSet.newRenderers;
        HashSet<Renderer> deleteRenderers = mRendererSyncSet.deleteRenderers;
        
        mRendererManager.UnionWithNewRenderers(newRenderers);
        mRendererManager.ExceptWithDeleteRenderers(deleteRenderers);
    }
}