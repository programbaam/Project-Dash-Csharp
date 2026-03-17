using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

abstract class GameObject
{
    private readonly SyncSet mSyncSet;

    private readonly HashSet<Component> mComponents= new();
    private readonly HashSet<Component> mNewComponents= new();
    private readonly HashSet<Component> mDeleteComponents= new();

    protected void InitComponent(Component component) 
    {
        mComponents.Add(component);

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
    protected void ReleaseComponent(Component component)
    {
        mComponents.Add(component);

        if (component is Renderer renderer)
        {
            Debug.Assert(renderer != null);
            mSyncSet.deleteRenderers.Add(renderer);
        }
        if (component is IInputable inputable)
        {
            Debug.Assert(inputable != null);
            mSyncSet.deleteInputs.Add(inputable);
        }
    }

    virtual public void Init()
    {
        Debug.Assert(mDeleteComponents.Count == 0);
        foreach (Component component in mNewComponents)
        {
            InitComponent(component);
        }
        mNewComponents.Clear();
    }
    virtual public void Update()
    { }
    virtual public void Release() 
    {
        foreach (Component component in mComponents)
        {
            ReleaseComponent(component);
        }
        mComponents.Clear();
    }
    virtual public void Destroy()
    { }
    
        
}