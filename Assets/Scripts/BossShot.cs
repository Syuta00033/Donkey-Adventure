using UnityEngine;

public class BossShot : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }
}