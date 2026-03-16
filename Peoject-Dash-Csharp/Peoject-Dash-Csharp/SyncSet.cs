using System.Collections.Generic;

struct SyncSet
{
    public HashSet<Renderer> newRenderers;
    public HashSet<Renderer> deleteRenderers;
}