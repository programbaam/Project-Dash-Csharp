using System.Collections.Generic;

class InputManager
{
    private readonly HashSet<IInputable> mInputs = new();

    public void Input()
    {
        foreach (IInputable input in mInputs)
        { 
            input.Input();
        }
    }
}