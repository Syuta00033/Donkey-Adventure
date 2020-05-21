using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoneSpawn : MonoBehaviour
{
    float randX;
    Vector2 whereToSpawn;

    public Transform spawn1, spawn2, spawn3, spawn4, spawn5;
    Transform[] spawnObject = new Transform[5];
    public Transform parentObject;

    public float spawnRate = 2f;
    public float nextSpawn = 0.0f;
    public float maxX = 4.6f;
    public float minX = -3.5f;

    private void Start()
    {
        spawnObject[0] = spawn1;
        spawnObject[1] = spawn2;
        spawnObject[2] = spawn3;
        spawnObject[3] = spawn4;
        spawnObject[4] = spawn5;
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(minX, maxX);
            whereToSpawn = new Vector2(randX, transform.position.y);

            int random = Random.Range(0, 4);

                Transform spawnedObject = Instantiate(spawnObject[random], whereToSpawn, Quaternion.Euler(0f, 0f, 0f));
                spawnedObject.SetParent(parentObject);
            }
        }
    }
