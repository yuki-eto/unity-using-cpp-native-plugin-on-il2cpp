using TMPro;
using UnityEngine;

public class WriteText : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        var t0 = canvas.transform.Find("text0").GetComponent<TextMeshProUGUI>();
        var t1 = canvas.transform.Find("text1").GetComponent<TextMeshProUGUI>();
        var t2 = canvas.transform.Find("text2").GetComponent<TextMeshProUGUI>();
        var t3 = canvas.transform.Find("text3").GetComponent<TextMeshProUGUI>();

        const int a = 10;
        const int b = 5;
        using (var c = new CalculatorWrapper(a, b))
        {
            t0.text = $"a = {a}, b = {b}";
            t1.text = $"{a} + {b} = {c.Sum()}";
            t2.text = $"{a} - {b} = {c.Sub()}";
            t3.text = $"{a}! = {c.Factorial()}";
        }
    }
}
