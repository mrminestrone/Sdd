using UnityEngine;
using UnityEngine.UI;

public class UpgradeText : MonoBehaviour
{
    public Text text;
    public int cost;
        void Update()
    {
        text.text = "Upgrade Costs: " + cost.ToString("G2");
    }
}
