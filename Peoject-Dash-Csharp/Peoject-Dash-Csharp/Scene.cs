using System.Collections.Generic;
using System.Diagnostics;

abstract class Scene
{

    private readonly HashSet<GameObject> mGameObjects = new();
    private readonly HashSet<GameObject> mNewGameObjects = new();
    private readonly HashSet<GameObject> mDeleteGameObjects = new();

    protected void NewGameObject(GameObject gameObject)
    {
        Debug.Assert(gameObject != null);
        mNewGameObjects.Add(gameObject);
    }
    

    protected void InitGameObject(GameObject gameObject)
    {
        Debug.Assert(gameObject != null);
        mGameObjects.Add(gameObject);

        if (gameObject is IInputable inputable)
        {            
            GameManager.mSyncSet.newInputs.Add(inputable);
        }
    }

    
    virtual public void Init()
    {
        foreach (GameObject gameObject in mNewGameObjects)
        {
           Debug.Assert(gameObject != null);
           InitGameObject(gameObject);
        }
        mNewGameObjects.Clear();

        foreach (GameObject gameObject in mGameObjects)
        {
            Debug.Assert(gameObject != null);
            gameObject.Init();
        }
    }   
    virtual public void Update()
    {
        foreach (GameObject gameObject in mGameObjects)
        {
           Debug.Assert(gameObject != null);
           gameObject.Update();
        }
    }
    protected void ReleaseGameObject(GameObject gameObject) 
    {
        Debug.Assert(gameObject != null);
        mDeleteGameObjects.Add(gameObject);
        gameObject.Release();

        if (gameObject is IInputable inputable)
        {
            GameManager.mSyncSet.deleteInputs.Add(inputable);
        }
    }
    virtual public void Release()
    {
        
        foreach (GameObject gameObject in mGameObjects)
        {   
            Debug.Assert(gameObject != null);
            ReleaseGameObject(gameObject);
        }
    }
    virtual public void Destroy()
    {
        foreach (GameObject gameObject in mDeleteGameObjects)
        {
            Debug.Assert(gameObject != null);
            gameObject.Destroy();
        }
        mDeleteGameObjects.Clear();
    }

}