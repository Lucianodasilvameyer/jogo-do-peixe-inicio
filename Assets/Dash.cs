using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] float speed, delay, delayPress;
    [SerializeField] GameObject particle;
    [HideInInspector] public bool startDelay;
    Rigidbody2D rb;
    int rightPress, leftPress;
    float timePassed, timePassedPress;
    bool startTimer;


    // Start is called before the first frame update
    void Start()
    {
        rightPress = 0;
        leftPress = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("left"))
        {
            leftPress++;
            startTimer = true;
        }
        else if (Input.GetButtonDown("right"))
        {
            rightPress++;
            startTimer = true;
        }
        if (startTimer)
        {
            timePassedPress += Time.deltaTime;

            if (timePassedPress >= delayPress)
            {
                startTimer = false;
                leftPress = 0;
                rightPress = 0;
                timePassedPress = 0;
            }
        }
        if(rightPress >=2 || leftPress >= 2)
        {
            startDelay = true;
            Instantiate(particle, transform, false);
        }

    }
    private void FixedUpdate()
    {
        if (startDelay)
        {
            timePassed += Time.fixedDeltaTime;

            if (timePassed <= delay)
            {
                if (rightPress >= 2)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    rightPress = 0;
                }
                else if (leftPress >= 2)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    leftPress = 0;
                }
            }
            else
            {
                timePassed = 0;
                startDelay = false;
                rightPress = 0;
                leftPress = 0;
            }

        }
    }
}
