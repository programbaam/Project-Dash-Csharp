using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

class CollisionManager
{
    private List<(Collider collider, ICollidable owner)> mCollisionList = new();

    private static bool[,] sLayerTable =
    {
        //              Player,     Obstacle
        /*Player*/      { false,    true },
        /*Obstacle*/    { true,     false },
    };

    public static bool GetLayerTable(ELayerTag collier1, ELayerTag collier2)
    {
        return sLayerTable[(int)collier1, (int)collier2];
    }

    public void UnionWithNewCollision()
    {
        foreach((Collider collider, ICollidable owner) collision in GameManager.mSyncSet.newCollision)
        {
            if (mCollisionList.Contains(collision))
            {
                continue;
            }

            mCollisionList.Add(collision);
        }
    }

    public void ExceptWithDeleteCollision()
    {
        foreach ((Collider collider, ICollidable owner) collision in GameManager.mSyncSet.newCollision)
        {
            if (mCollisionList.Contains(collision))
            {
                mCollisionList.Remove(collision);
            }
        }
    }

    public void Collision()
    {
        
        for (int i = 0; i < mCollisionList.Count; i++)
        {

            for (int j = i + 1; j < mCollisionList.Count; j++)
            {
                if (mCollisionList[i].collider.IsOverlap(
                        mCollisionList[j].collider))
                {
                    mCollisionList[i].owner.OnCollision();
                }
            }
        }
    }
}

