using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private Vector3 dir = new Vector3(0.0f, 0.0f, 1.0f);

    void Update()
    {
        if(!PauseMenu.isPaused && !GameOver.gameOver)
            transform.Rotate(dir* rotationSpeed);
    }
}
