class MenuScene : Scene
{
    private UI[] mMenuUIs;

    public MenuScene()
    {
        InitMenus();
    }
    public void InitMenus() 
    {
        mMenuUIs = new UI[(int)EMenu.Max];
    }
    public void CreateMenu(EMenu UIName, int UIPosX, int UIPosY)
    {
        UI mMenuUI = new UI();
        mMenuUIs[(int)UIName] = mMenuUI;
        
        mMenuUI.SetScreenPos(ScreenPosX: UIPosX, ScreenPosY: UIPosY);        
    }
}