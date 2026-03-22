using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RendererManager
{
    // 색상
    public const string RESET = "\u001b[0m";
    public const string RED = "\u001b[91m";
    public const string GREEN = "\u001b[92m";
    public const string YELLOW = "\u001b[93m";
    public const string BLUE = "\u001b[94m";
    public const string MAGENTA = "\u001b[95m";
    public const string CYAN = "\u001b[96m";
    public const string WHITE = "\u001b[97m";

    private readonly HashSet<Renderer> mRenderers = new();
    private string mClearScreenString;
    private static StringBuilder[] sStringBuilders;
    private static List<(int index, string color)>[] sColorPoints;
    private static ColorPointComparer sColorPointComparer;

    
    private void SetClearScreenString()
    {
        string spacePad = "".PadRight(GameManager.ConsoleWidth);

        mClearScreenString = spacePad;
    }

    public static void InsertTextToStringBuilder(int iCol, int iRow, string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        sStringBuilders[iRow].Remove(startIndex: iCol, length: text.Length);
        sStringBuilders[iRow].Insert(index: iCol, value: text);
    }

    public static void InsertTextToStringBuilder(int iCol, int iRow, string text, string color)
    {

        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        sColorPoints[iRow].Add((index: iCol, color: color));
        sStringBuilders[iRow].Remove(startIndex: iCol, length: text.Length);
        sStringBuilders[iRow].Insert(index: iCol, value: text);
        sColorPoints[iRow].Add((index: iCol + text.Length, color: RESET));
    }

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
        Clear();
        
        foreach (Renderer renderer in mRenderers)
        {

            renderer.Draw();

        }

        SortColorPoints();

        InsertColorPoints();

        ConsolePoint screenPos;
        screenPos.x = 0;
        screenPos.y = 0;

        for (int i = 0; i < sStringBuilders.Length; i++)
        {
            Console.SetCursorPosition(screenPos.x, screenPos.y + i);
            Console.Write(sStringBuilders[i]);
        }
    }

    // TODO : 추후 사용안할 시 삭제
    public void Clear()
    {
        for (int i = 0; i < sStringBuilders.Length; i++)
        {
            sStringBuilders[i].Clear();
            sStringBuilders[i].Append(mClearScreenString);
        }

        for (int i = 0; i < sColorPoints.Length; i++)
        {
            sColorPoints[i].Clear();
        }

    }

    public void SortColorPoints()
    {
        for (int i = 0; i < sColorPoints.Length; i++)
        {
            sColorPoints[i].Sort(sColorPointComparer);
        }
    }

    public void InsertColorPoints()
    {
        for (int i = 0; i < sColorPoints.Length; i++)
        {
            foreach ((int index, string color) colorPoint in sColorPoints[i])
            {
                sStringBuilders[i].Insert(index: colorPoint.index, value: colorPoint.color);
            }
        }
    }

    public RendererManager()
    {
        SetClearScreenString();
        sStringBuilders = new StringBuilder[GameManager.ConsoleHeight];

        for (int i = 0; i < sStringBuilders.Length; i++)
        {
            sStringBuilders[i] = new StringBuilder();
            sStringBuilders[i].Capacity = 256;
        }


        sColorPoints = new List<(int index, string color)>[GameManager.ConsoleHeight];
        for (int i = 0; i < sColorPoints.Length; i++)
        {
            sColorPoints[i] = new List<(int index, string color)>();
            sColorPoints[i].Capacity = 32;
        }
        
        
        sColorPointComparer = new ColorPointComparer();
    }
}