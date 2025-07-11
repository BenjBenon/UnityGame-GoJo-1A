using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    //yo
    public GameObject door;
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

            door.GetComponent<Animator>().SetTrigger("Trigger");
/*            if (door.GetComponent<Animator>().GetBool("IsOpened"))
            { door.transform.GetChild(1).localScale = new Vector3(2.267f, 6.1646f, 1.0153f); }
            else { door.transform.GetChild(1).localScale = new Vector3(2.2329f, 0.10711f, 1.0f); }*/
            Debug.Log("yo");
            /*if (door.GetComponent<Animator>().GetBool("IsOpened")){
                door.GetComponent<Animator>().SetTrigger("Trigger");
                door.GetComponent<Animator>().SetBool("IsOpened", false);
            }
            else
            {
                door.GetComponent<Animator>().SetTrigger("Trigger");
                door.GetComponent<Animator>().SetBool("IsOpened",true);
            }*/
        }
    }
}
