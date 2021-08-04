using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public int Upgrades;
    int price;
    public int whichupgrade;
    //subscribe to onconfirmupgradeprice
    private void Awake() 
    {
        GameEvents.current.onConfirmUpgradePrice += U;
        price = 15;
    }
    //when clicked send that it has been clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.ClickClickUpgrade(price);
    }
    //add to amount of upgrades then up price
    private void U()
    {
        Upgrades++;
        price = Mathf.RoundToInt(price * Mathf.Pow(1.15f,Upgrades));
    }
}
