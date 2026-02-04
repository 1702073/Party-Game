using UnityEngine;
using TMPro;

public class TimerToMoney : MonoBehaviour
{
    public float timeElapsed = 0f;
    public int money = 0;
    public TextMeshProUGUI moneyText;

    public Timerexample Timerexample;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 1f)
        {
            money += 1; 
            timeElapsed -= 1f;

            if (moneyText != null)
            {
                moneyText.text = "Money: $" + money;
            }
            Debug.Log("Money earned! Total: " + money);
        }
        
    }
}
