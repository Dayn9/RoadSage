using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Car : MonoBehaviour {

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityForce;

    private Rigidbody2D rb2D;

    private RaycastHit2D[] hits;
    private bool grounded;
    private bool jump = false;

    private float velocity = 0;

    private bool pause = true;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        hits = new RaycastHit2D[2];
    }

    private void Update()
    {
        if(grounded && Input.GetKey(KeyCode.Space) && !pause)
        {
            jump = true;
        }
    }

    public void Jump()
    {
        if (grounded && !pause)
        {
            jump = true;
        }
    }

    public void Begin()
    {
        pause = false;
    }

    public void TogglePause()
    {
        pause = !pause;
    }


    // Update is called once per frame
    void FixedUpdate () {

        if (!pause)
        {
            velocity -= gravityForce * Time.deltaTime;

            int numCollisions = rb2D.Cast(Vector3.down, hits, velocity);
            float distance = Mathf.Abs(velocity);
            for (int i = 0; i < numCollisions; i++)
            {
                //collide with the closest
                if (hits[i].distance < distance)
                {
                    distance = hits[i].distance;
                    grounded = true;
                    velocity = 0;
                    transform.up = hits[i].normal;
                }
            }

            if (jump && grounded)
            {
                velocity += jumpForce * Time.deltaTime;

                jump = false;
                grounded = false;
            }

            transform.position += Vector3.up * velocity;
        }
	}
}
