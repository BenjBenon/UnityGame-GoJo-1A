using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSlime : MonoBehaviour
{
    public GameObject slime;
    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.GetComponent<PlayerController>() == null)
        {
            return;
        }
        if (slime.GetComponent<PlayerController>().moveRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            slime.GetComponent<PlayerController>().babyLaunchX = 500;
            slime.GetComponent<PlayerController>().babyLaunchZ = 700;
            slime.GetComponent<PlayerController>().spawnBaby = Vector3.up + Vector3.right;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            slime.GetComponent<PlayerController>().babyLaunchX = -500;
            slime.GetComponent<PlayerController>().babyLaunchZ = 700;
            slime.GetComponent<PlayerController>().spawnBaby = Vector3.up + Vector3.left;
        }
    }
}
