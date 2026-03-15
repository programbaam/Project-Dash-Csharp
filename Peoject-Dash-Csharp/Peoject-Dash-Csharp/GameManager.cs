class GameManager
{
    private RendererManager mRendererManager;

    public GameManager(RendererManager rendererManager)
    {
        mRendererManager = rendererManager;
    }

    public void GameLoop()
    {
        mRendererManager.Render();
    }
}