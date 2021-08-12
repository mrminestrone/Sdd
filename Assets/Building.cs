using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerClickHandler
{
    public int Buildings;
    public int whichbuild;
    public int price;
    private void Awake() 
    {
        GameEvents.current.onConfirmBuyBuilding += B;
        price = Mathf.RoundToInt(Mathf.Pow(10f,whichbuild+1));
        InvokeRepeating("AddMoney", 0, 10f);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.BuyBuilding((whichbuild), price);
    }
    private void B(int[] barray)
    {
        Buildings = barray[whichbuild];
        price = Mathf.RoundToInt(price * Mathf.Pow(1.15f,Buildings));
    }
    void AddMoney()
    {
        GameEvents.current.ClickClicker(Mathf.RoundToInt(Mathf.Pow(5f, whichbuild + 1)*Buildings));
    }
}
