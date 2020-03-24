using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class WriteText : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    #if UNITY_EDITOR_OSX
    [DllImport("libsample_cpp_dylib")]
    private static extern int SumInteger(int a, int b);
    [DllImport("libsample_cpp_dylib")]
    private static extern int SubInteger(int a, int b);
    #else
    [DllImport("__Internal")]
    private static extern int SumInteger(int a, int b);
    [DllImport("__Internal")]
    private static extern int SubInteger(int a, int b);
    #endif

    private void Start()
    {
        var t1 = canvas.transform.Find("text1").GetComponent<TextMeshProUGUI>();
        var t2 = canvas.transform.Find("text2").GetComponent<TextMeshProUGUI>();

        const int a = 10;
        const int b = 5;
        t1.text = $"{a} + {b} = {SumInteger(a, b)}";
        t2.text = $"{a} - {b} = {SubInteger(a, b)}";
    }
}
