using UnityEngine;

public class Spawner : MonoBehaviour
{
    float randY;
    Vector2 whereToSpawn;

    public Transform spawnObject;
    public Transform parentObject;

    public float spawnRate = 2f;
    private float halfSpawnRate;
    public float nextSpawn = 0.0f;
    public float maxY = 4.6f;
    public float minY = -3.5f;
    public float angle = 0.0f;
    public static bool speedUpSpawns = false;
    float temp;

    //Endless or Levels
    public bool endless = false;
    public int anzahlSpawns = 10;

    private void Start()
    {
        halfSpawnRate = spawnRate / 2;
        temp = spawnRate;
    }

    void Update()
    {
        //speedUp Spawns when Donkey is on rightBound
        if (speedUpSpawns)
        {
            spawnRate = halfSpawnRate;
        }
        else if(!speedUpSpawns)
        {
            spawnRate = temp;
        }

        if (endless)
        {
            Spawn();
        } else if(anzahlSpawns > 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(minY, maxY);
            whereToSpawn = new Vector2(transform.position.x, randY);
            Transform spawnedObject = Instantiate(spawnObject, whereToSpawn, Quaternion.Euler(0.0f, angle, 0f));
            spawnedObject.SetParent(parentObject);
            anzahlSpawns--;
            if (spawnObject.tag == "Enemy")
            {
                EnemyCountScript.enemies--;
            }
        }
    }
}
