using System.Collections.Generic;
using System.Diagnostics;

abstract class Scene
{
    protected SyncSet mSyncSet;

    private readonly HashSet<GameObject> mGameObjects = new();
    private readonly HashSet<GameObject> mNewGameObjects = new();
    private readonly HashSet<GameObject> mDeleteGameObjects = new();

    protected void NewGameObject(GameObject gameObject)
    {
        mNewGameObjects.Add(gameObject);
    }



    protected void InitGameObject(GameObject gameObject)
    {
        mGameObjects.Add(gameObject);

        if (gameObject is IInputable inputable)
        {
            Debug.Assert(inputable != null);
            mSyncSet.newInputs.Add(inputable);
        }
    }

    
    virtual public void Init()
    {
        foreach (GameObject gameObject in mNewGameObjects)
        {          
           InitGameObject(gameObject);
        }

        foreach(GameObject gameObject in mGameObjects)
        {
            gameObject.Init();
        }
    }   
    virtual public void Update()
    {
        foreach (GameObject gameObject in mGameObjects)
        {
           gameObject.Update();
        }
    }
    protected void ReleaseGameObject(GameObject gameObject) 
    {
        mDeleteGameObjects.Add(gameObject);
        if (gameObject is IInputable inputable)
        {
            Debug.Assert(inputable != null);
            mSyncSet.deleteInputs.Add(inputable);
        }
    }
    virtual public void Release()
    {
        
        foreach (GameObject gameObject in mGameObjects)
        {
            ReleaseGameObject(gameObject);
        }
    }
    virtual public void Destroy()
    {
        foreach (GameObject gameObject in mDeleteGameObjects)
        {
            gameObject.Destroy();
        }
    }

}