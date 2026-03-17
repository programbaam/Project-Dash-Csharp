using System.Collections.Generic;
using System.Diagnostics;

abstract class GameObject
{
    private readonly SyncSet mSyncSet;

    private readonly HashSet<Component> mComponents= new();
    private readonly HashSet<Component> mNewComponents= new();
    private readonly HashSet<Component> mDeleteComponents= new();
    

    virtual public void Init()
    {
        foreach (var component in mNewComponents)
        {
            
            if (component is Renderer renderer)
            {
                Debug.Assert(renderer != null);
                mSyncSet.newRenderers.Add(renderer);
            }
            if (component is IInputable inputable)
            {
                Debug.Assert(inputable != null);
                mSyncSet.newInputs.Add(inputable);                
            }
        }
    }
    virtual public void Update()
    { }
    virtual public void Delete() 
    { }
    abstract public void Destroy();
    
        
}