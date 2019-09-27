using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentDoPeixeNT2 : MonoBehaviour
{
    Rigidbody2D righ;
    public float speed;

    


    // Start is called before the first frame update

    private void FixedUpdate()
    {
        Vector3 Position = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        righ.velocity = Position * speed;
    }


    void Start()
    {
        righ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
