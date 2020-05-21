using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 7)
            {
                PauseMenu reset = GameObject.Find("Canvas").GetComponent<PauseMenu>();
                reset.ResetValues();
                StartCoroutine(LoadLevel(5));
            }
            else
            {
                //zur sicherheit, aber klappt trotzdem nicht ganz
                if (Cloud.inCloud)
                {
                    Cloud.inCloud = false;
                    PlayerControl.speed += 3.0f;
                    WeaponScript.inCloud = false;
                }
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        //PlayAnim
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitiontime);

        //LoadScene
        SceneManager.LoadScene(levelIndex);
    }
}
