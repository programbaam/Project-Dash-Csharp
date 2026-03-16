using System;

[Flags]
enum ERawKeyState : short
{
    None = 0,
    Down = unchecked((short)0x8000), // 현재 눌림
}