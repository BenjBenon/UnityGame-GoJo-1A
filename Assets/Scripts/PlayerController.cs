using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public playerfeet feet;
    public slimeCollision scriptCollision;
    public GameObject slime;
    public bool moveRight;

    public float babyLaunchX;
    public float babyLaunchZ;
    public Vector3 spawnBaby;
    public float timer = 0.0f;
    private float valueVelocity;
    public int divisionScale = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("nininnininiinininin");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInChildren<Animator>().GetBool("IsDead")) {
            timer += Time.deltaTime;
            if(timer > 3.0f) { Destroy(gameObject); }
            return; 
        }
        //Deplacement

        Vector2 currentVelocity;
        if (feet.isGrounded)
        {
            currentVelocity = new Vector2(0, GetComponentInChildren<Rigidbody2D>().velocity.y);
        }
        else
        {
            currentVelocity = new Vector2(GetComponentInChildren<Rigidbody2D>().velocity.x, GetComponentInChildren<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentVelocity.x = speed * (divisionScale / 3f + 1f);
            moveRight = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentVelocity.x = -speed * (divisionScale / 3f + 1f);
            moveRight = false;
        }




        //Saut
        GetComponentInChildren<Rigidbody2D>().velocity = currentVelocity;
        if (Input.GetKeyDown(KeyCode.Space) && feet.isGrounded)
        {
            GetComponentInChildren<Rigidbody2D>().AddForce(Vector2.up * jumpPower * (divisionScale/2f + 1f));
        }


        //Separation
        DivideSlimes();
        //Reunification
        if (scriptCollision.slimeCollided)
        {
            if (scriptCollision.collidedObject.GetComponent<PlayerController>().divisionScale == this.divisionScale 
                && scriptCollision.collidedObject != null 
                && scriptCollision.collidedObject.GetComponent<Transform>().GetChild(0).GetComponent<Animator>().GetBool("IsDead") == false)
            {
                UnitSlimes(scriptCollision.collidedObject);
            }
        }
    }
    

    
    private void DivideSlimes()
    {
        if (Input.GetKeyDown(KeyCode.E) && divisionScale < 2)
        {
            GameObject newGameObject = Instantiate(slime);

            newGameObject.GetComponentInChildren<playerfeet>().isGrounded = false;
            newGameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().GetChild(0).localScale *= 0.5f;
            newGameObject.GetComponent<Transform>().position = GetComponent<Transform>().position + spawnBaby ;
            GetComponent<Transform>().GetChild(0).GetComponent<Transform>().GetChild(0).localScale *= 0.5f;

            newGameObject.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(babyLaunchX,babyLaunchZ));

            //newGameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower * (divisionScale / 2f + 1f));
            //newGameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpPower * (divisionScale / 2f + 1f));

            divisionScale++;
            newGameObject.GetComponent<PlayerController>().divisionScale = this.divisionScale;
        }
    }

    private void UnitSlimes(GameObject collidedSlime)
    {
        Destroy(collidedSlime);
        GetComponent<Transform>().GetChild(0).GetComponent<Transform>().GetChild(0).localScale *= 2f;
        divisionScale--;
    }
}
