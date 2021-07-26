using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public int Money = 0;
    private Text text;
    //add the money
    private void AddMoney(int MoneyAdded)
    {
        Money += MoneyAdded;
        text.text = Money.ToString("G7");
    }
    //Subscribe to onClickClicker event
    private void Start() 
    {
        GameEvents.current.onClickClicker += AddMoney;
    }
}
