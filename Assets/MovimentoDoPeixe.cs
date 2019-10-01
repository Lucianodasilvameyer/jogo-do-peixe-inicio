using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoPeixe : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
   
    
    private int direction;

    public bool recarregar=false;

   

    public int Timer=1;

    

    private float TempoDashInicial;

    [SerializeField]
    private float TempoDashMax;

    



    Rigidbody2D righ;

    private void FixedUpdate()//usado quando se usa calculos de fisica? 
    {
        Vector3 Position = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        righ.velocity = Position * speed;



        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && recarregar==false)
        {
            Dash(x, y);

            if (Input.GetKeyDown(KeyCode.Space) && recarregar == false && recarregar2 ==false)
            {
                Dash(x, y);

                Debug.Log("correu");
                recarregar = true;
                
            }

           
        }

        if(Time.time>=TempoDashInicial+TempoDashMax && recarregar == true)
        {

            recarregar2 = true;

            if (Time.time >= TempoDashInicial + TempoDashMax && Timer)
            {
                recarregar = false;
                

                TempoDashInicial = Time.time;
            }
        }
        

    }

    void Start()
    {
        righ = GetComponent<Rigidbody2D>();
        
    }




    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        

    }    
    public void Dash(float x, float y)
    {
        Vector2 direction = new Vector2(x, y);
        righ.AddForce(direction * dashSpeed, ForceMode2D.Impulse);//força e modo respectivamente? no caso o direction vira um vetor ao ser adicionado força a ele 
    }
   
}
