using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform playerPosition;
    public static float rightBound = -1.5f;
    public static float leftBound = -8.27f;

    public float speed = 2f;
    private Vector2 direction;

    //Portal
    public GameObject portal;
    public GameObject timerStop;
    private Spawner spawner, ammospawner, cloudspawner;

    private void Start()
    {
        spawner = GameObject.Find("FishSpawner").GetComponent<Spawner>();
        ammospawner = GameObject.Find("AmmoSpawner").GetComponent<Spawner>();
        cloudspawner = GameObject.Find("CloudSpawner").GetComponent<Spawner>();
    }

    void Update()
    {
        //Hier kann man noch ein bisschen fine tunen
        float inputX = Input.GetAxis("Horizontal");
        if (EnemyCountScript.enemies > 0 || GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            if (inputX > 0 && playerPosition.transform.position.x > rightBound)
            {
                direction = new Vector2((-1.0f - inputX), 0.0f);
                SimpleMovement.speedUp = true;
                Spawner.speedUpSpawns = true;
            }
            else
            {
                direction = new Vector2(-1.0f, 0.0f);
                SimpleMovement.speedUp = false;
                Spawner.speedUpSpawns = false;
            }
        } else
        {
            //Grad nicht sicher, ob mans braucht
            SimpleMovement.speedUp = false;
            Spawner.speedUpSpawns = false;

            if (!spawner.endless)
            {
                //LEVEL ENDS

                //damit keine weiteren clouds/ammo spawnen nach ende
                ammospawner.endless = false;
                cloudspawner.endless = false;

                direction = new Vector2(0.0f, 0.0f);
                portal.SetActive(true);
                timerStop.GetComponent<Timer>().Finish();
            }
        }

        Vector2 movement = direction * speed * Time.deltaTime; // * playerInput;
        transform.Translate(movement);

    }
}
