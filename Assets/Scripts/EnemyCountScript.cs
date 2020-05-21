using UnityEngine;
using UnityEngine.UI;

public class EnemyCountScript : MonoBehaviour
{
    Text text;
    public static int enemies = 0;
    public Spawner spawn1, spawn2, spawn3;

    void Start()
    {
        text = GetComponent<Text>();

        spawn1 = GameObject.Find("FishSpawner").GetComponent<Spawner>();
        spawn2 = GameObject.Find("KugelfischSpawner").GetComponent<Spawner>();
        spawn3 = GameObject.Find("KarawanenSpawner").GetComponent<Spawner>();

        if (!spawn1.endless)
        {
            enemies += spawn1.anzahlSpawns;
            enemies += spawn2.anzahlSpawns;
            enemies += spawn3.anzahlSpawns;
        }
    }

    void Update()
    {
        spawn1 = GameObject.Find("FishSpawner").GetComponent<Spawner>();

        if (!spawn1.endless)
            text.text = "Enemies left: " + enemies;
    }
}
