using UnityEngine;
using UnityEngine.UI;

public class buildings : MonoBehaviour
{
    public Text text;
    public GameObject building;
    public int amount;
    public int pog;
    public int pogs;
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

    private void Awake() 
    {
        GameEvents.current.onConfirmBuyBuilding += B;
        pog = building.GetComponent<Building>().whichbuild;
        InvokeRepeating("AddMoney", 0f, 10f);
    }

    void B(int[] amogus)
    {
        pogs = building.GetComponent<Building>().Buildings;
        if (amogus[pog] < pogs)
        {
            amount++;
        }
    }

    void AddMoney()
    {
        pogs = building.GetComponent<Building>().Buildings;
        GameEvents.current.ClickClicker(Mathf.RoundToInt(Mathf.Pow(5f, pog + 1)*pogs));
        Debug.Log(Mathf.RoundToInt(Mathf.Pow(5f, pog + 1)*pogs));
    }
    void Update()
    {
        text.text = "You Have " + FormatEveryThirdPower(shortNotation, amount, "") + " Buildings";
    }
}
