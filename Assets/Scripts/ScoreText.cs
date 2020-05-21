using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text text;
    public static int score = 0;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Score: " + score;
    }
}
