using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeSpiking = 1.5f;
    public float timeNotSpiking = 3.0f;
    public bool isSpiking = true;
    public bool firstChange = true;
    public float timer = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (isSpiking)
        {
            case true:
                if (firstChange)
                {
                    GetComponent<Animator>().SetBool("oh",true);
                    firstChange = false;
                }
                timer += Time.deltaTime;
                if (timer > timeSpiking)
                {
                    isSpiking = false;
                    firstChange = true;
                    timer = 0.0f;
                }
                break;
            case false:
                if (firstChange)
                {
                    GetComponent<Animator>().SetBool("oh", false);
                    firstChange = false;
                }
                timer += Time.deltaTime;
                if (timer > timeNotSpiking)
                {
                    isSpiking = true;
                    firstChange = true;
                    timer = 0.0f;
                }
                break;
        }



    }


}
