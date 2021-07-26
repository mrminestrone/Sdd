using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Text text;
    public Text UpgradeText;
    public GameObject clicker;
    public int StarterPrice;
    public int price;
    public int building = 0;
    //This needs to be changed to use the events system
    void UpgradeMo(int mo)
    {
        if (text.GetComponent<SetText>().Money >= UpgradeText.GetComponent<UpgradeText>().cost)
        {
            building+=mo;
            clicker.GetComponent<Click>().ClickMoney += mo;
            text.GetComponent<SetText>().Money -= UpgradeText.GetComponent<UpgradeText>().cost;
            UpgradeText.GetComponent<UpgradeText>().cost = Mathf.RoundToInt(UpgradeText.GetComponent<UpgradeText>().cost * Mathf.Pow(1.15f,building));
        }
    }
    private void OnMouseDown() {
        UpgradeMo(1);
    }
}
