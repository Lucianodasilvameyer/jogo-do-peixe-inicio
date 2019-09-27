using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoPeixe : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    

    



    Rigidbody2D righ;

    private void FixedUpdate()
    {
        Vector3 Position = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        righ.velocity = Position * speed;
    }

    void Start()
    {
        righ = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    


    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.Space))
            {
               
                direction = 1;
                Debug.Log("correu");
            }
            else if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
            {
               
                direction = 2;
                Debug.Log("correu");
            }
            else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space))
            {
                
                direction = 3;
                Debug.Log("correu");
            }
            else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
            {
                
                direction = 4;
                Debug.Log("correu");
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                righ.velocity = Vector2.zero; 
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    righ.velocity = Vector2.left * dashSpeed;
                }
                else if(direction==2)
                {
                    righ.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    righ.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    righ.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
   
}
