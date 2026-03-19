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
        ClearConsole();
        foreach (Renderer renderer in mRenderers)
        {
            renderer.Draw();
        }
    }

    public void ClearConsole()
    { 
        string emptySpaceWidth = " ".PadRight(GameManager.ConsoleWidth);
        for (int i = 0; i < GameManager.ConsoleHeight; ++i)
        {
            Console.WriteLine(emptySpaceWidth);
        }
    }
}