using System.Collections.Generic;
struct SyncSet
{
    //Input
    public HashSet<IInputable> newInputs;
    public HashSet<IInputable> deleteInputs;

    //Render
    public HashSet<Renderer> newRenderers;
    public HashSet<Renderer> deleteRenderers;

    //Collision
    public HashSet<(Collider collider, ICollidable owner)> newCollision;
    public HashSet<(Collider collider, ICollidable owner)> deleteCollision;

    //Scene
    public bool isChangeScene;
    public EScene scene;
}