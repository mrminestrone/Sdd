using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Text text;
    public int ClickMoney = 1;
    void OnMouseDown() {
        text.GetComponent<SetText>().money += ClickMoney;
    }
}
