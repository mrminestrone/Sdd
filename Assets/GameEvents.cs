using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    int wb;
    int[] BuildingArray = new int[5] {0,0,0,0,0};
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
    //Confirm have amount of money for building
    public event Action<int> onBuyBuilding;
    public void BuyBuilding(int WhichBuilding, int BuildingPrice)
    {
        if (onBuyBuilding != null)
        {
            onBuyBuilding(BuildingPrice);
            wb = WhichBuilding;
        }
    }
    //buy building
    public event Action<int[]> onConfirmBuyBuilding;
    public void ConfirmBuyBuilding()
    {
        if (onConfirmBuyBuilding != null)
        {
            BuildingArray[wb] += 1;
            onConfirmBuyBuilding(BuildingArray);
        }
    }
}
