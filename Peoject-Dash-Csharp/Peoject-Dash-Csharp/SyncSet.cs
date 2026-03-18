using System.Collections.Generic;
struct SyncSet
{
    //Input
    public HashSet<IInputable> newInputs;
    public HashSet<IInputable> deleteInputs;

    //Render
    public HashSet<Renderer> newRenderers;
    public HashSet<Renderer> deleteRenderers;
}