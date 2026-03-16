using System.Collections.Generic;

struct RendererSyncSet
{
    public HashSet<Renderer> newRenderers;
    public HashSet<Renderer> deleteRenderers;
}