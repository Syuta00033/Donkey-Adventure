using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 dir = new Vector2(-1, 0);
    private Rigidbody2D rig;
    public static bool speedUp = false;

    //For Karawane change Y
    private float currentTime = 0.0f;
    private float nextChange = 1.0f;
    private float changeDuration = 0.0f;
    private int yDir = 1;
    private int count = 0;
    public bool isKarawane = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = dir * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speedUp)
        {
            rig.velocity = dir * speed * 2f;
        }
        else
        {
            rig.velocity = dir * speed;
        }

        if (isKarawane)
        {
            currentTime += Time.fixedDeltaTime;
            if (currentTime >= nextChange)   //change height every second
            {
                rig.velocity = new Vector2(-1, yDir) * (speed-1); //change height
                changeDuration += Time.fixedDeltaTime;
                if (changeDuration >= 0.5f)  //change height for 0.5 seconds
                {
                    rig.velocity = dir * speed;    //set back to normal
                    changeDuration = 0.0f;
                    currentTime = 0.0f;
                    count++;
                    yDir = count % 2 == 0 ? 1 : -1;
                }
            }
        }
    }
}
