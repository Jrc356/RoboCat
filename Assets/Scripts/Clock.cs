using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private int timeRemainingS;
    public int totalTimeS = 60;
    public Text timeText;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        timeRemainingS = totalTimeS;
        timeText.text = "Time Remaining: " + timeRemainingS.ToString();
        StartCoroutine("DecreaseTime");
    }

    void Update() {
        timeText.text = "Time Remaining: " + timeRemainingS.ToString();
    }
    
    public IEnumerator DecreaseTime() {
        while (timeRemainingS > 0) {
            yield return new WaitForSeconds(1.0f);
            timeRemainingS--;
        }

        GameOver();
    }

    public void GameOver() {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }
}
