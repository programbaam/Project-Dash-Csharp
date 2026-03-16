using System.Collections.Generic;
using System.Diagnostics;

class GameManager
{
    private readonly RendererSyncSet mRendererSyncSet;
    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;

    public GameManager()
    {
        mRendererSyncSet = new RendererSyncSet();
        mRendererManager = new RendererManager();
        mInputManager = new InputManager();
    }

    public void GameLoop()
    {
        mRendererManager.Render();
        mInputManager.Input();
    }

    public void SyncRenderers()
    {
        HashSet<Renderer> newRenderers = mRendererSyncSet.newRenderers;
        HashSet<Renderer> deleteRenderers = mRendererSyncSet.deleteRenderers;
        
        mRendererManager.UnionWithNewRenderers(newRenderers);
        mRendererManager.ExceptWithDeleteRenderers(deleteRenderers);
    }
}