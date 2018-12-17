using UnityEngine;
using UnityEngine.UI;
public class Speed : MonoBehaviour
{
    public Rigidbody rb;
    public Text speedText;

    private float speedInKMH;
    // Update is called once per frame
    void Update()
    {
        speedInKMH = rb.velocity.z * 3.6f;

        speedText.text = speedInKMH.ToString("F0") + " km/h";
    }
}
