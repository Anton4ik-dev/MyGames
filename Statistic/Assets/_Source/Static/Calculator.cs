using SO;
using UnityEngine;

public static class Calculator
{
    private const string PATH = "DataSO";
    public static float CountGravityRule(float m1, float m2, float r)
    {
        return (LoadG() * m1 * m2) / Mathf.Pow(r, 2);
    }
    public static float CountHeightOfFalling(float t)
    {
        return (Loadg() * Mathf.Pow(t, 2)) / 2;
    }
    public static float CountSecondNewton(float F, float m)
    {
        return F / m;
    }
    public static float CountSpeed(float s, float t)
    {
        return s / t;
    }
    public static float CountImpulse(float m, float v)
    {
        return m * v;
    }
    private static float Loadg()
    {
        return Resources.Load<DataSO>(PATH).g;
    }
    private static float LoadG()
    {
        return Resources.Load<DataSO>(PATH).G;
    }
}