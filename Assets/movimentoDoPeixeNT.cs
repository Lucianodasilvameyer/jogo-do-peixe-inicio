using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoDoPeixeNT : MonoBehaviour
{
    Rigidbody2D righ;
    public float speed;

    private movimentoDoPeixeNT playercharacterBase;
    private Vector3 lastMoveDir;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 Position = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        righ.velocity = Position * speed;
    }

    private void Awake()
    {
        righ = GetComponent<Rigidbody2D>();
        playercharacterBase = gameObject.GetComponent<movimentoDoPeixeNT>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMoviment();
        handleDash();
    }
    private void handleMoviment()
    {
        float speed = 50f;
        float moveX = 0f;
        float moveY = 0f;

       if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
       {
            moveY = +10f;    
       }
       if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
       {
            moveY = -10f;
       }
       if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
       {
            moveX = -10f;
       }
       if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
       {
            moveX = +10f;
       }
        bool isIdle = moveX == 0 && moveY == 0;

        if (isIdle)
        {
            //playercharacterBase = PlayIdleAnimation(lastMoveDir);
        }
        else
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            

           
            if (tryMove(moveDir,speed*Time.deltaTime))
            {
                
                //playercharacterBase.PlayWalkingAnimation(moveDir);
               
            }
            else
            {
                //playercharacterBase.PlayIdleAnimation(lastMoveDir);
            }

            Vector3 targetMovePosition = transform.position + moveDir * speed * Time.deltaTime;

            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);

            if (raycastHit.collider == null)
            {
                lastMoveDir = moveDir;
                //playercharacterBase.PlayWalkingAnimation(moveDir);
                transform.position = targetMovePosition;

            }
            else
            {
                Vector3 testMoveDir = new Vector3(moveDir.x, 0f).normalized;
                targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;
                raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);

                if (testMoveDir.x !=0f && raycastHit.collider==null)
                {
                    lastMoveDir = testMoveDir;
                    //playercharacterBase.PlayWalkingAnimation(testMoveDir);
                    transform.position = targetMovePosition;

                }
                else
                {
                    testMoveDir = new Vector3(0f, moveDir.y).normalized;
                    targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;
                    raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);

                    if(testMoveDir.y != 0f && raycastHit.collider == null)
                    {
                        lastMoveDir = testMoveDir;
                        //playercharacterBase.PlayWalkingAnimation(testMoveDir);
                        transform.position = targetMovePosition;
                    }
                    else
                    {
                        //playercharacterBase.PlayIdleAnimation(lastMoveDir);
                    }
                }
            }


        }


    }
    private bool CanMove(Vector3 dir,float distance)
    {
       return Physics2D.Raycast(transform.position, dir, distance).collider==null;
    }
    private bool tryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, distance);

        if (!canMove)
        {
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = CanMove(moveDir, distance);

            if (!canMove)
            {
                moveDir = new Vector3(baseMoveDir.y, 0f).normalized;
                canMove = CanMove(moveDir, distance);
            }
        }
        if (canMove)
        {
            lastMoveDir = moveDir;
            //playercharacterBase.PlayWalkingAnimation(moveDir);
            transform.position += moveDir * distance;
            return true;
        }
        else
        {
            return false;
        }
        
        
            
        
    }

    private void handleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dashDistance = 100f;
            transform.position += lastMoveDir*dashDistance;
        }
    }


}
