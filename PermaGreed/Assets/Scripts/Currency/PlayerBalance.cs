using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Money System UI

public class PlayerBalance : MonoBehaviour
{
    public TextMeshProUGUI countMoney; //[UI] This links to the Canvas Currency

    public int balance;

    // Start is called before the first frame update
    void Start()
    {
        balance = 0; //KEEP IN MIND, when changing scenes, this needs to be modified.
        TextCurrency();
    }

    public void AddCount()
    {
        balance += 10;
        TextCurrency();
    }

    void TextCurrency()
    {
        countMoney.text = balance.ToString(); //Only Accepts Strings...
    }


}
