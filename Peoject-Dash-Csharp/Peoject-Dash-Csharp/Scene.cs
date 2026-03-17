using System.Collections.Generic;
using System.Diagnostics;

abstract class Scene
{
    private readonly SyncSet mSyncSet;

    private readonly HashSet<GameObject> mGameObjects = new();
    private readonly HashSet<GameObject> mNewGameObjects = new();
    private readonly HashSet<GameObject> mDeleteGameObjects = new();

    virtual public void Init()
    {
        foreach (GameObject gameObject in mNewGameObjects)
        {          

            if (gameObject is IInputable inputable)
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
    virtual public void Destroy()
    { }

}