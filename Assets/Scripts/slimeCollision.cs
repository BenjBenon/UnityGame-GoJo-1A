using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class slimeCollision : MonoBehaviour
{
    public bool slimeCollided;
    public GameObject collidedObject = null;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Slime" || collision.tag == "SlimeRed")
        {
            slimeCollided = true;
            collidedObject = collision.GameObject().transform.parent.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Slime" || collision.tag == "SlimeRed")
        {
            slimeCollided = false;
        }
        collidedObject = null;
    }


}
