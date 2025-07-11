using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Valve : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipe;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y), new Vector2(slime1.GetComponent<Transform>().position.x, slime1.GetComponent<Transform>().position.y)) < 5 || Vector2.Distance(new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y), new Vector2(slime2.GetComponent<Transform>().position.x, slime2.GetComponent<Transform>().position.y)) < 5)
        {
        }
        //else
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "SlimeRed")
        {
            Debug.Log("yo");
            pipe.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
        }
    }
}
