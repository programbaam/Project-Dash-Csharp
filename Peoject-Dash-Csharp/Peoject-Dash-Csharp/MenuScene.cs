using System.Diagnostics;

class MenuScene : Scene //, IInputable
{
    private const int FIRST_MENU_UI_POS_X = 0;
    private const int FIRST_MENU_UI_POS_Y = 0;
    private const int MENU_UI_INTERVAL_Y = 2;

    private Widget[] mMenuUIs;

    public MenuScene()
    {
        InitMenus();
        foreach (GameObject gameObject in mMenuUIs!)
        {
            NewGameObject(gameObject);
        }
    }
    public void InitMenus() 
    {
        ConsolePoint screenPos;
        screenPos.x = FIRST_MENU_UI_POS_X;
        screenPos.y = FIRST_MENU_UI_POS_Y;

        string[] menuUINames = new string[(int)EMenu.Max] { "새게임", "점수화면", "게임종료" }; 

        mMenuUIs = new Widget[(int)EMenu.Max];//뭘 만들지

        Debug.Assert(mMenuUIs.Length == menuUINames.Length);
        
        for (int i = 0; i<mMenuUIs.Length; i++ )
        {            
            Debug.Assert(menuUINames[i] != null);

            mMenuUIs[i] = new Widget(screenPos, menuUINames[i]);
            NewGameObject(mMenuUIs[i]);

            screenPos.y += MENU_UI_INTERVAL_Y;

        }        
    }
    
    //Todo : 메뉴 인풋 구현 
}