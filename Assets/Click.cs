using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    public int ClickMoney = 1;
    // Trigger event system to add money to player = to ClickMoney
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.current.ClickClicker(ClickMoney);
    }
    private void Start() 
    {
        GameEvents.current.onConfirmUpgradePrice += Upgrade;
    }
    private void Upgrade()
    {
        ClickMoney++;
    }
}
