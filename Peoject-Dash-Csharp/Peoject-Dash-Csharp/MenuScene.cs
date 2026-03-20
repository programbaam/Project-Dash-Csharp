using System;
using System.Diagnostics;

class MenuScene : Scene , IInputable
{
    private const int FIRST_MENU_UI_POS_X = 0;
    private const int FIRST_MENU_UI_POS_Y = 0;
    private const int MENU_UI_INTERVAL_Y = 2;

    private const ConsoleKey CURSOR_UP = ConsoleKey.UpArrow;
    private const ConsoleKey CURSOR_Down = ConsoleKey.DownArrow;

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

        mMenuUIs = new Widget[(int)EMenu.Max];

        Debug.Assert(mMenuUIs.Length == menuUINames.Length);
        
        for (int i = 0; i<(int)EMenu.Max; i++ )
        {            
            Debug.Assert(menuUINames[i] != null);

            mMenuUIs[i] = new Widget(screenPos, menuUINames[i], false);
            NewGameObject(mMenuUIs[i]);

            screenPos.y += MENU_UI_INTERVAL_Y;

        }        
    }

    
    //Todo : 메뉴 인풋 구현 
    public void Input() 
    {
        if (InputManager.IsCurrentKeyDown(EVirtualKey.UP_ARROW))
        {
            CursorUP();
            
        }
        if (InputManager.IsCurrentKeyDown(EVirtualKey.DOWN_ARROW))
        {
            CursorDown();
        }
    }
    private void CursorUP() 
    {

    }

    private void CursorDown() { }

}