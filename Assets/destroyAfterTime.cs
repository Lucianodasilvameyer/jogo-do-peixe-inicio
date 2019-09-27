using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject me;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        if (time < 0)
        {
            Destroy(me);
        }
        time -= Time.deltaTime;
    }
}
