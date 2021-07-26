using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Text text;
    public int ClickMoney = 1;
    // Trigger event system to add money to player = to ClickMoney
    void OnMouseDown() 
    {
        GameEvents.current.ClickClicker(ClickMoney);
    }
}
