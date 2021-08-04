using UnityEngine.EventSystems;
using UnityEngine;

public class BuildingButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Upgrade;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Upgrade.activeSelf) {Upgrade.SetActive(false);}
        else {Upgrade.SetActive(true);}
    }
}