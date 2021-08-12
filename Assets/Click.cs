using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    public int ClickMoney = 1;
    int UpgradeTimes;
    // Trigger event system to add money to player = to ClickMoney
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.ClickClicker(ClickMoney);
    }
    private void Start() 
    {
        GameEvents.current.onConfirmUpgradePrice += Upgrade;
    }
    private void Upgrade(int[] uarray)
    {
        if (uarray[0] > UpgradeTimes)
        {
            ClickMoney++;
            UpgradeTimes++;
        }    
    }
}
