using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public Transform parentObject;

    public float FireCooldown = 0.3f;
    public static bool inCloud = false;
    private float currentTime = 0.0f;
   
    void Start()
    {
        currentTime = FireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButton("Jump") && currentTime >= FireCooldown && AmmoText.ammo > 0 && inCloud == false && !PauseMenu.isPaused && !GameOver.gameOver)
        {
            SoundManager.PlaySound("shoot");
            AmmoText.ammo--;
            Transform shot = Instantiate(shotPrefab);
            shot.position = transform.position;
            shot.SetParent(parentObject);

            currentTime = 0.0f;
        }

        //Cheat :)
        if (Input.GetKeyDown("f"))
        {
            AmmoText.ammo += 20 - AmmoText.ammo;
            RipScript.ripFish = 0;
        }
    }
}
