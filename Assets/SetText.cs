using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    public int Money = 0;
    public TextMeshProUGUI text;
    //round number
    string[] shortNotation = new string[12] {"", "k", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc"};
    public string FormatEveryThirdPower(string[] notations, float target, string lowDecimalFormat)
        {
            float value = target;
            int baseValue = 0;
            string notationValue = "";
            string toStringValue;
    
            if (value >= 10000) // I start using the first notation at 10k
            {
                value /= 1000;
                baseValue++;
                while (Mathf.Round((float)value) >= 1000)
                {
                    value /= 1000;
                    baseValue++;
                }
    
                if (baseValue < 2)
                    toStringValue = "N1"; // display 1 decimal while under 1 million
                else
                    toStringValue = "N2"; // display 2 decimals for 1 million and higher
    
                if (baseValue > notations.Length) return null;
                else notationValue = notations[baseValue];
            }
            else toStringValue = lowDecimalFormat; // string formatting at low numbers
            return value.ToString(toStringValue) + notationValue;
        }

    //Subscribe to all events
    private void Start() 
    {
        GameEvents.current.onClickClicker += AddMoney;
        GameEvents.current.onClickClickUpgrade += CheckUpgrade;
        GameEvents.current.onBuyBuilding += CheckBuilding;
        text.text = FormatEveryThirdPower(shortNotation, Money, "") + " <sprite=0>";
    }
    //add the money
    private void AddMoney(int MoneyAdded)
    {
        Money += MoneyAdded;
        text.text = FormatEveryThirdPower(shortNotation, Money, "") + " <sprite=0>";
    }
    //check if enough money for upgrade
    public void CheckUpgrade(int UpgradePrice)
    {
        if (Money >= UpgradePrice)
        {
            Money -= UpgradePrice;
            text.text = FormatEveryThirdPower(shortNotation, Money, "") + " <sprite=0>";
            GameEvents.current.ConfirmUpgradePrice();
        }
    }
    //check if enough money for building
    public void CheckBuilding(int BuildingPrice)
    {
        if (Money >= BuildingPrice)
        {
            Money -= BuildingPrice;
            text.text = FormatEveryThirdPower(shortNotation, Money, "") + " <sprite=0>";
            GameEvents.current.ConfirmBuyBuilding();
        }
    }
}
