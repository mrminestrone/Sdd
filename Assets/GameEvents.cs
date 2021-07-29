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
    //check price of upgrade
    public event Action<int> onClickClickUpgrade;
    public void ClickClickUpgrade(int UpgradePrice)
    {
        if (onClickClickUpgrade != null)
        {
            onClickClickUpgrade(UpgradePrice);
        }
    }
    //do upgrade
    public event Action onConfirmUpgradePrice;
    public void ConfirmUpgradePrice()
    {
        if (onConfirmUpgradePrice != null)
        {
            onConfirmUpgradePrice();
        }
    }
}
