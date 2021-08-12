using UnityEngine;
using TMPro;

public class Buildingtext : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject building;
    public int price;
    public int amt;
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
        price = building.GetComponent<Building>().price;
        amt = building.GetComponent<Building>().Buildings;
        text.text = "This Costs: " + FormatEveryThirdPower(shortNotation, price, "") + "\nYou have: "+ FormatEveryThirdPower(shortNotation, amt, "");
    }
}
