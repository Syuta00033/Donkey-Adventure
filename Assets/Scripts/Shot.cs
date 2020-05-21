using UnityEngine;

public class Shot : MonoBehaviour
{
    public Vector2 dir = new Vector2(1, 0);
    public float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);    //Destroy after 10 seconds
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
