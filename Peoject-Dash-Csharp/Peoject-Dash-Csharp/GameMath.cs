using System;

static class GameMath
{
    public const float EPSILON = 0.00001f;
    // 콘솔 화면 임계값
    public const float VIEW_THRESHOLD = 0.5f;


    public static bool IsNearlyLess(float lvalue, float rvalue)
    {
        return lvalue < rvalue - EPSILON;
    }

    public static bool IsNearlyGreater(float lvalue, float rvalue)
    {
        return lvalue > rvalue + EPSILON;
    }

    public static bool IsNearlyEqual(float lvalue, float rvalue)
    {
        return Math.Abs(lvalue - rvalue) < EPSILON;
    }

    public static bool IsNearlyLessOrEqual(float lvalue, float rvalue)
    {
        return lvalue < rvalue + EPSILON;
    }

    public static bool IsNearlyGreaterOrEqual(float lvalue, float rvalue)
    {
        return lvalue > rvalue - EPSILON;
    }

    public static bool IsZero(float value)
    {
        return Math.Abs(value) < EPSILON;
    }

    public static int ToScreenCoord(float value)
    {
        int roundDownValue = (int)value;
        float downDecimalPointvalue = value - roundDownValue;

        if (Math.Abs(downDecimalPointvalue) < VIEW_THRESHOLD)
        {
            return roundDownValue;
        }

        return value > 0 ? roundDownValue + 1 : roundDownValue - 1;
    }
}

