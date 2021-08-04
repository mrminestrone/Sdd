using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerClickHandler
{
    //make it do shit like add money or something
    public int Buildings;
    public int whichbuild;
    public int price;
    private void Awake() 
    {
        GameEvents.current.onConfirmBuyBuilding += B;
        price = Mathf.RoundToInt(Mathf.Pow(10f,whichbuild));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.BuyBuilding((whichbuild-1), price);
    }
    private void B(int[] barray)
    {
        Buildings = barray[whichbuild-1];
        price = Mathf.RoundToInt(price * Mathf.Pow(1.15f,Buildings));
    }
}
