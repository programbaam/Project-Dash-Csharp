using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

abstract class GameObject
{
    private readonly HashSet<Component> mComponents = new();
    private readonly HashSet<Component> mNewComponents = new();
    private readonly HashSet<Component> mDeleteComponents = new();

    protected void NewComponemt(Component component)
    {
        Debug.Assert(component != null);
        mNewComponents.Add(component);
    }
    protected void InitComponent(Component component)
    {
        Debug.Assert(component != null);
        mComponents.Add(component);

        if (component is Renderer renderer)
        {            
            GameManager.mSyncSet.newRenderers.Add(renderer);

        }
        if (component is IInputable inputable)
        {            
            GameManager.mSyncSet.newInputs.Add(inputable);
        }
    }

    virtual public void Init()
    {
        Debug.Assert(mDeleteComponents.Count == 0);
        foreach (Component component in mNewComponents)
        {
            Debug.Assert(component != null);
            InitComponent(component);
        }
        mNewComponents.Clear();
    }
    abstract public void Update();

    protected void ReleaseComponent(Component component)
    {
        Debug.Assert(component != null);
        mDeleteComponents.Add(component);

        if (component is Renderer renderer)
        {
            GameManager.mSyncSet.deleteRenderers.Add(renderer);
        }
        if (component is IInputable inputable)
        {
            GameManager.mSyncSet.deleteInputs.Add(inputable);
        }
    }
    virtual public void Release()
    {
        foreach (Component component in mNewComponents)
        {
            Debug.Assert(component != null);
            ReleaseComponent(component);
        }
        mNewComponents.Clear();

        foreach (Component component in mComponents)
        {
            Debug.Assert(component != null);
            ReleaseComponent(component);
        }
        mComponents.Clear();
    }
    virtual public void Destroy()
    {
        foreach (Component component in mDeleteComponents)
        {
            Debug.Assert(component != null);
            component.Destroy();
        }
        mDeleteComponents.Clear();
    }
}
    
        
