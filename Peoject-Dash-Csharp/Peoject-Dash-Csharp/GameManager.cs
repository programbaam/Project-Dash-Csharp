using System.Collections.Generic;

class GameManager
{
    private readonly SyncSet mRendererSyncSet;
    private readonly HashSet<Renderer> mNewRenderers;
    private readonly HashSet<Renderer> mDeleteRenderers;

    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;

    public GameManager()
    {
        mNewRenderers = mRendererSyncSet.newRenderers;
        mDeleteRenderers = mRendererSyncSet.deleteRenderers;

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
        mRendererManager.UnionWithNewRenderers(mNewRenderers);
        mRendererManager.ExceptWithDeleteRenderers(mDeleteRenderers);

        mNewRenderers.Clear();
        mDeleteRenderers.Clear();
    }
}