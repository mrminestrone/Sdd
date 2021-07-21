using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public int money = 0;
    public Text text;
    void Update()
    {
        text.text = money.ToString("G2");
    }
}
