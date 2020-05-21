using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOver.gameOver)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        ResetValues();
        isPaused = false;
        Time.timeScale = 1f;
        RipScript.ripFish = 0;
        SceneManager.LoadScene("Main Menu");
    }

    public void ResetValues()
    {
        RipScript.ripFish = 0;
        AmmoText.ammo = 20;
        ScoreText.score = 0;
        WeaponScript.inCloud = false;
        Boss.healed = false;
        BossMovement.normalShoot = false;
        BossMovement.rapidShoot = false;
        EnemyCountScript.enemies = 0;

        if (Cloud.inCloud)
        {
            Cloud.inCloud = false;
            PlayerControl.speed += 3.0f;
        }
    }
}
