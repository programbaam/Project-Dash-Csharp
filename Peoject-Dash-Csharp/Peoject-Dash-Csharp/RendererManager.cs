using System.Collections.Generic;

class RendererManager
{
    private readonly HashSet<Renderer> mRenderers = new();

    public void UnionWithNewRenderers(HashSet<Renderer> newRenderers)
    {
        mRenderers.UnionWith(newRenderers);
    }

    public void ExceptWithDeleteRenderers(HashSet<Renderer> deleteRenderers)
    {
        mRenderers.ExceptWith(deleteRenderers);
    }

    public void Render()
    {
        foreach (Renderer renderer in mRenderers)
        {
            renderer.Draw();
        }
    }
}