using UnityEngine;
using UnityEngine.UI;

public class RipScript : MonoBehaviour
{
    Text text;
    public static int ripFish = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ripFish + "/10";
    }
}
