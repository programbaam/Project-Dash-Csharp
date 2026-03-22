using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class GameManager
{
    static public SyncSet mSyncSet;
    private readonly RendererManager mRendererManager;
    private readonly InputManager mInputManager;
    private readonly SceneManager mSceneManager;
    private readonly CollisionManager mCollisionManager;

    private Stopwatch mStopwatch;
    private long mLastTick;

    //Console Size
    public static int ConsoleWidth { get =>100; } //Console.WindowWidth : 120
    public static int ConsoleHeight { get => 30; } //Console.WindowHeight : 30

    public GameManager()
    {
        //SyncSet 멤버변수 초기화
        GameManager.mSyncSet.newInputs = new HashSet<IInputable>();
        GameManager.mSyncSet.deleteInputs = new HashSet<IInputable>();
        GameManager.mSyncSet.newRenderers = new HashSet<Renderer>();
        GameManager.mSyncSet.deleteRenderers = new HashSet<Renderer>();
        GameManager.mSyncSet.newCollision = new HashSet<(Collider collider, ICollidable? owner)>();
        GameManager.mSyncSet.deleteCollision = new HashSet<(Collider collider, ICollidable? owner)>();

        mInputManager = new InputManager();
        mRendererManager = new RendererManager();
        mSceneManager = new SceneManager();
        mCollisionManager = new CollisionManager();

        mStopwatch = new Stopwatch();
        mLastTick = 0;
    }

    public void GameLoop()
    {
        //Game Setting
        Console.OutputEncoding = Encoding.UTF8;
        Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
        Console.CursorVisible = false;
        
        mStopwatch.Start();

        while (true)
        {
            //Ticks를 초단위로 변환
            long currentTick = mStopwatch.ElapsedTicks;
            //Stopwatch.Frequency : 1초를 틱단위(long)로 표현한 수
            Time.DeltaTime = (float)(currentTick - mLastTick) / Stopwatch.Frequency;
            if (Time.DeltaTime < 0.16) //대략 60프레임
            { 
                continue;
            }
            mLastTick = currentTick;

            // Init
            mSceneManager.Init();

            // Input
            mInputManager.Input();                      

            // Update
            mSceneManager.Update();

            // Collision
            mCollisionManager.Collision();

            if (GameManager.mSyncSet.isChangeScene)
            {
                Console.Clear();
                mSceneManager.ChangeScene(GameManager.mSyncSet.scene);
                SyncInputs();
                SyncRenderers();
                SyncCollision();
                GameManager.mSyncSet.isChangeScene = false;
                continue;
            }
            

            //Sync
            SyncInputs();
            SyncRenderers();
            SyncCollision();

            //Render
            mRendererManager.Render();


            //Destroy           
            mSceneManager.Destroy();
           
        }
    }

    public void SyncInputs()
    {
        HashSet<IInputable> newInputs = mSyncSet.newInputs;
        HashSet<IInputable> deleteInputs = mSyncSet.deleteInputs;

        mInputManager.UnionWithNewInputs(newInputs);
        mInputManager.ExceptWithDeleteInputs(deleteInputs);

        newInputs.Clear();
        deleteInputs.Clear();
    }

    public void SyncRenderers()
    {
        HashSet<Renderer> newRenderers = mSyncSet.newRenderers;
        HashSet<Renderer> deleteRenderers = mSyncSet.deleteRenderers;
        
        mRendererManager.UnionWithNewRenderers(newRenderers);
        mRendererManager.ExceptWithDeleteRenderers(deleteRenderers);

        newRenderers.Clear();
        deleteRenderers.Clear();
    }

    public void SyncCollision()
    {
        mCollisionManager.UnionWithNewCollision();
        mCollisionManager.ExceptWithDeleteCollision();

        mSyncSet.newCollision.Clear();
        mSyncSet.deleteCollision.Clear();
    }
}