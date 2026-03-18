class MenuScene : Scene
{
    private Widget[] mMenuUIs;

    public MenuScene(SyncSet syncSet)
    {
        mSyncSet = syncSet;

        InitMenus();
        foreach (GameObject gameObject in mMenuUIs)
        {
            NewGameObject(gameObject);
        }
    }
    public void InitMenus() 
    {
        ConsolePoint screenPos;
        screenPos.x = 0;
        screenPos.y = 0;


        mMenuUIs = new Widget[3];//뭘 만들지        
        mMenuUIs[0] = new Widget(mSyncSet, screenPos, "게임 타이틀");

        screenPos.x = 2;
        screenPos.y = 2;
        mMenuUIs[1] = new Widget(mSyncSet, screenPos, "메뉴1");

        screenPos.x = 4;
        screenPos.y = 4;
        mMenuUIs[2] = new Widget(mSyncSet, screenPos, "메뉴2");
    }
    
}