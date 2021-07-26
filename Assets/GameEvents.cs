using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake() 
    {
        current = this;
    }

    //Recieve event from click script and send signal for money to go up
    public event Action<int> onClickClicker;
    public void ClickClicker(int ClickMoney)
    {
        if (onClickClicker != null) 
        {
            onClickClicker(ClickMoney);
        }
    }

    public event Action onClickClickUpgrade;
    public void ClickClickUpgrade()
    {
        if (onClickClickUpgrade != null)
        {
            onClickClickUpgrade();
        }
    }
}
