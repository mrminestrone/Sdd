using UnityEngine;
using UnityEngine.UI;

public class UpgradeText : MonoBehaviour
{
    public Text text;
    public int price = 15;
    int Upgrades;
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

    void Update()
    {
        text.text = "Upgrade Costs: " + FormatEveryThirdPower(shortNotation, price, "");
    }
    private void Start() 
    {
        GameEvents.current.onConfirmUpgradePrice += U;
    }
    private void U()
    {
        Upgrades++;
        price = Mathf.RoundToInt(price * Mathf.Pow(1.15f,Upgrades));
    }
}
