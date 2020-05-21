using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public static bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        //GameOver 
        if(RipScript.ripFish >= 10)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            gameOver = true;
        }
    }

    public void Restart()
    {
        PauseMenu reset = gameObject.GetComponent<PauseMenu>();
        reset.ResetValues();
        gameOver = false;

        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        PauseMenu reset = gameObject.GetComponent<PauseMenu>();
        reset.ResetValues();
        gameOver = false;

        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
}
