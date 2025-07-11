using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeSprinkling = 1.5f;
    public float timeNotSprinkling = 3.0f;
    public bool isSprinkling = true;
    public bool firstChange = true;
    public float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (isSprinkling)
        {
            case true:
                if (firstChange)
                {
                    GetComponent<Transform>().GetChild(0).GetComponent<ParticleSystem>().Play();
                    firstChange = false;
                }
                timer += Time.deltaTime;
                if(timer > timeSprinkling)
                {
                    isSprinkling = false;
                    firstChange = true;
                    timer = 0.0f;
                }
                break;
            case false:
                if (firstChange)
                {
                    GetComponent<Transform>().GetChild(0).GetComponent<ParticleSystem>().Stop();
                    firstChange = false;
                }
                timer += Time.deltaTime;
                if (timer > timeNotSprinkling)
                {
                    isSprinkling = true;
                    firstChange = true;
                    timer = 0.0f;
                }
                break;
        }



        //StartCoroutine(Wait());
    }


/*    public IEnumerator Wait()
    {


        print("");
    *//*isInvinsible = true;*//*

        yield return new WaitForSeconds(2);

*//*        isInvinsible = false;*//*

    }*/
}
