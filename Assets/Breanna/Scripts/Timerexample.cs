using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timerexample : MonoBehaviour
{
    public TMP_Text Disvar;

    public float val;

    bool str;

    public int money = 0;
    public TextMeshProUGUI moneyText;

    void Start()
    {
        val = 0;
        str = false;
    }
    void Update()
    {
        if (str)
        {
            val += Time.deltaTime;
        }
        Disvar.text = val.ToString();
    }
    public void start()
    {
        str = true;
    }
    public void stop()
    {
        str = false;      
    }
    public void Reset()
    {
        AddMoney();

        str = false;
        val = 0;
    }

    public void AddMoney()
    {
        money += (int)val;

        moneyText.text = money.ToString();
    }

}
