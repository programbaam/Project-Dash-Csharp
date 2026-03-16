using System.Collections.Generic;

class RendererManager
{
    private HashSet<Renderer> mRenderers;

    public RendererManager(HashSet<Renderer> renderers)
    { 
        mRenderers = renderers;
    }

    public void Render()
    {
        foreach (Renderer renderer in mRenderers)
        {
            renderer.Draw();
        }
    }
}