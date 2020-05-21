using UnityEngine;

public class Stone : MonoBehaviour
{
    public float x = -14f;
    public float y = -6.69f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= x || transform.position.y <= y)
            Destroy(gameObject);
    }
}
