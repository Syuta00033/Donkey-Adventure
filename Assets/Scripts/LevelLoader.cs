using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //PlayAnim
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitiontime);

        //LoadScene
        SceneManager.LoadScene(levelIndex);
    }
}
