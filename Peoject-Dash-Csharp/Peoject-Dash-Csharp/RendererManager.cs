using System.Collections.Generic;

class RendererManager
{
    private HashSet<Renderer> mRenderers;

    public RendererManager()
    { 
        mRenderers = new HashSet<Renderer>();
    }

    public void Render()
    {
        foreach (Renderer renderer in mRenderers)
        {
            renderer.Draw();
        }
    }
}