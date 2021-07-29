using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public int Upgrades;
    int price;
    private void Awake() 
    {
        GameEvents.current.onConfirmUpgradePrice += U;
        price = 15;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.ClickClickUpgrade(price);
    }
    private void U()
    {
        Upgrades++;
        price = Mathf.RoundToInt(price * Mathf.Pow(1.15f,Upgrades));
    }
}
