using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Nade : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBeforeExploding = 2.0f;
    public float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBeforeExploding)
        {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<SpriteRenderer>());
            //GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
            //GetComponent<Rigidbody2D>().totalTorque = 0;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            StartCoroutine(Wait());
            timer = 0.0f;
            enabled = false;
        }
    }

    public IEnumerator Wait() {
        Debug.Log("yo");
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
