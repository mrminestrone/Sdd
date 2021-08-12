using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public int Upgrades;
    public int price;
    public int whichupgrade;
    public GameObject Upgradez;
    public bool a = false;
    //subscribe to onconfirmupgradeprice
    private void Awake() 
    {
        GameEvents.current.onConfirmUpgradePrice += U;
        GameEvents.current.onConfirmBuyBuilding += J;
        price = 15 * (whichupgrade + 1);
        if (whichupgrade != 0 && a == false)
        {
            Upgradez.SetActive(false);
        }
    }
    //when clicked send that it has been clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.ClickClickUpgrade(price, whichupgrade);
    }
    //add to amount of upgrades then up price
    private void U(int[] uarray)
    {
        Upgrades = uarray[whichupgrade];
        price = Mathf.RoundToInt(price * Mathf.Pow(1.15f,Upgrades));
    }
    void J(int[] barray)
    {
        if(whichupgrade != 0)
        {
            if (barray[whichupgrade-1] != 0)
            {
                Upgradez.SetActive(true);
                a = true;
            }
        }
    }
}
