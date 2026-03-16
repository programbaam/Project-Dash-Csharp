using System.Collections.Generic;
using System.Runtime.InteropServices;

class InputManager
{
    private readonly HashSet<IInputable> mInputs = new();

    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(EVirtualKey vKey);

    public static bool IsCurrentKeyDown(EVirtualKey vKey)
    {
        ERawKeyState currentKeyDownState = (ERawKeyState)GetAsyncKeyState(vKey) & ERawKeyState.Down;
        if (currentKeyDownState != ERawKeyState.None)
        {
            return true;
        }

        return false;
    }

    public void Input()
    {
        foreach (IInputable input in mInputs)
        { 
            input.Input();
        }
    }
}