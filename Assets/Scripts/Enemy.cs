using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject nade;
    public float timeBeforeThrowing = 5.0f;
    public float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBeforeThrowing)
        {
            GameObject newGameObject = Instantiate(nade);
            newGameObject.GetComponent<Transform>().position = GetComponent<Transform>().position + transform.right;
            newGameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
            newGameObject.GetComponent<Rigidbody2D>().AddTorque(20);
            timer = 0.0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(-5);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*150);
    }
}
