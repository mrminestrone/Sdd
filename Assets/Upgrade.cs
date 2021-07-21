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
    private void Start() 
    {
        price = StarterPrice;
    }
    void UpgradeMo(int mo)
    {
        if (text.GetComponent<SetText>().money >= price)
        {
            building+=mo;
            clicker.GetComponent<Click>().ClickMoney += mo;
            text.GetComponent<SetText>().money -= 5;
            price += Mathf.RoundToInt(Mathf.Pow(1.15f,building));
            UpgradeText.GetComponent<UpgradeText>().cost = price;
        }
    }
    private void OnMouseDown() {
        UpgradeMo(1);
    }
}
