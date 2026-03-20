using System;
using System.Collections.Generic;

class RendererManager
{
    private readonly HashSet<Renderer> mRenderers = new();

    public void UnionWithNewRenderers(HashSet<Renderer> newRenderers)
    {
        mRenderers.UnionWith(newRenderers);
    }

    public void ExceptWithDeleteRenderers(HashSet<Renderer> deleteRenderers)
    {
        mRenderers.ExceptWith(deleteRenderers);
    }

    public void Render()
    {
        Console.Clear();
        foreach (Renderer renderer in mRenderers)
        {
            if (renderer.IsDrawing == false)
            {
                continue;
            }
            renderer.Draw();
        }
    }

    // TODO : 추후 사용안할 시 삭제
    public void ClearConsole()
    { 
        string emptySpaceWidth = " ".PadRight(GameManager.ConsoleWidth);
        for (int i = 0; i < GameManager.ConsoleHeight; ++i)
        {
            Console.WriteLine(emptySpaceWidth);
        }
    }
}