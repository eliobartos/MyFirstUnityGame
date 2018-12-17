using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 45f;
    public float sideForce = 100f;

    public bool VelXToZero = true;

    private bool goRight = false;
    private bool goLeft = false;
    private bool speedUp = false;
    // Update is called once per frame
    private void Update()
    {
        //Get keyboard input in update better than FixedUpdates
        if (Input.GetKey("d"))
        {
            goRight = true;
        } else
        {
            goRight = false;
        }

        if (Input.GetKey("a"))
        {
            goLeft = true;
        } else
        {
            goLeft = false;
        }

        if (Input.GetKey("w"))
        {
            speedUp = true;
        } else
        {
            speedUp = false;
        }

    }

    // FixedUpdate se koristi kad imamo fiziku (Rigidbody npr.)
    void FixedUpdate()
    {
        // Time.deltaTime je faktor koji pomaže da dodana sila ne ovisi o fps-u
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);

        // Smoothing of velocity when moving left or right
        Vector3 v = rb.velocity;
        v.x = v.x/1.2f;

        if (goRight)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (goLeft)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (speedUp)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        // When we are not holding any keys don't move left or rigth
        if (!goRight && !goLeft && VelXToZero)
        {
            rb.velocity = v;
        }

        if (rb.position.y <= -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
} 
