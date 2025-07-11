using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int sizeNeeded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Slime") { return; }
        if (collision.gameObject.GetComponentInParent<PlayerController>().divisionScale <= sizeNeeded)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            return;
        }
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
