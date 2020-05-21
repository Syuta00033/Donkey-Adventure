using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public static float speed = 6.0f;
    private Rigidbody2D rig;
    private Vector3 dir;

    //Scroll when moving
    private float rightBound = ParallaxScrolling.rightBound;
    private float leftBound = ParallaxScrolling.leftBound;

    //when Level ends
    private float rightBound2 = 8.38f;
    private float leftBound2 = -8.27f;

    //CamShake
    private CamShake shake;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();

        if (Cloud.inCloud)
        {
            Cloud.inCloud = false;
            PlayerControl.speed += 3.0f;
            WeaponScript.inCloud = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float inputY = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");

        Camera cam = Camera.main;
        float height = cam.orthographicSize; ;
        // float halfWidth = height * cam.aspect / 2f;

        if (inputY > 0 && rig.transform.position.y > height - 0.5)
        {
            inputY = 0.0f;
        }
        else if (inputY < 0 && rig.transform.position.y < -height + 0.5)
        {
            inputY = 0.0f;
        }

        if (EnemyCountScript.enemies > 0 || GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            dir = new Vector3(0, inputY, 0);

            if (inputX > 0 && rig.transform.position.x < rightBound)
            {
                dir = new Vector3(inputX, inputY, 0);
            }
            else if (inputX < 0 && rig.transform.position.x > leftBound)
            {
                dir = new Vector3(inputX, inputY, 0);
            }
        }
        else
        {
            dir = new Vector3(0, inputY, 0);
            if (inputX > 0 && rig.transform.position.x < rightBound2)
            {
                dir = new Vector3(inputX, inputY, 0);
            }
            else if (inputX < 0 && rig.transform.position.x > leftBound2)
            {
                dir = new Vector3(inputX, inputY, 0);
            }
        }

    }

    private void FixedUpdate()
    {
        //move player
        rig.MovePosition(transform.position + speed * dir * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnemyShot")
        {
            Destroy(col.gameObject);
            RipScript.ripFish++;
            shake.ShakeCam();
        }
    }
}
