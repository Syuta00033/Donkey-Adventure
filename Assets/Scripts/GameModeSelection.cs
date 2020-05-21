using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelection : MonoBehaviour
{


    public void EndlessMode()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void LevelMode()
    {
        SceneManager.LoadScene("Lvl1");
    }

    public void BossExtreme()
    {
        SceneManager.LoadScene("BossExtreme");
    }
}
