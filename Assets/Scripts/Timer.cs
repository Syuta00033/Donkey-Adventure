using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;
    public static string seconds;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (GameOver.gameOver)
        {
            Finish();
        }

        if (finished)
            return;

        float t = Time.time - startTime;
        seconds = t.ToString("f2");   //f2 = just two decimals
        timerText.text = seconds;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}
