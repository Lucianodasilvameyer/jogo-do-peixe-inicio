using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoDoPeixeNT : MonoBehaviour
{
    private movimentoDoPeixeNT playercharacterBase;
    private Vector3 lastMoveDir;

    // Start is called before the first frame update
    private void Awake()
    {
        playercharacterBase = gameObject.GetComponent<movimentoDoPeixeNT>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMoviment(); 
    }
    private void handleMoviment()
    {
        float speed = 50f;
        float moveX = 0f;
        float moveY = 0f;

       if(Input.GetKey(KeyCode.W))
       {
            moveY = +1f;    
       }
       if(Input.GetKey(KeyCode.S))
       {
            moveY = -1f;
       }
       if (Input.GetKey(KeyCode.A))
       {
            moveX = -1f;
       }
       if (Input.GetKey(KeyCode.D))
       {
            moveX = +1f;
       }
        bool isIdle = moveX == 0 && moveY == 0;

        if (isIdle)
        {
            //playercharacterBase = PlayIdleAnimation(lastMoveDir);
        }
        else
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;


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

                }
            }


        }


    }

}
