using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSpinner : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, Time.deltaTime * speed);
    }
}
