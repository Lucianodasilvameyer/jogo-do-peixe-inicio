using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Dash dash;
    float duration;
    [SerializeField] float power;

    Vector3 initialPos;

    [SerializeField] float initialDuration;




    // Start is called before the first frame update
    void Start()
    {
        dash = GameObject.Find("Player").GetComponent<Dash>();
        initialPos = transform.localPosition;
        duration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dash.startDelay)
        {
            duration = initialDuration;
        }
        if (duration >= 0)
        {
            duration -= Time.deltaTime;
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * power;
        }
        else
        {
            transform.localPosition = initialPos;
            duration = 0;
        }

    }
}
