using System;
using System.Runtime.InteropServices;

public class CalculatorWrapper : IDisposable
{
    private readonly IntPtr _calculator;

    #if UNITY_EDITOR
    [DllImport("libcalculator")]
    #else
    [DllImport("__Internal")]
    #endif
    private static extern IntPtr NewCalculator(int a, int b);
    #if UNITY_EDITOR
    [DllImport("libcalculator")]
    #else
    [DllImport("__Internal")]
    #endif
    private static extern void FreeCalculator(IntPtr c);
    #if UNITY_EDITOR
    [DllImport("libcalculator")]
    #else
    [DllImport("__Internal")]
    #endif
    private static extern int CalcSum(IntPtr c);
    #if UNITY_EDITOR
    [DllImport("libcalculator")]
    #else
    [DllImport("__Internal")]
    #endif
    private static extern int CalcSub(IntPtr c);
    #if UNITY_EDITOR
    [DllImport("libcalculator")]
    #else
    [DllImport("__Internal")]
    #endif
    private static extern int CalcFactorial(IntPtr c);

    public CalculatorWrapper(int a, int b)
    {
        _calculator = NewCalculator(a, b);
    }

    ~CalculatorWrapper()
    {
        FreeCalculator(_calculator);
    }

    public void Dispose()
    {
        FreeCalculator(_calculator);
    }

    public int Sum()
    {
        return CalcSum(_calculator);
    }

    public int Sub()
    {
        return CalcSub(_calculator);
    }

    public int Factorial()
    {
        return CalcFactorial(_calculator);
    }
}
