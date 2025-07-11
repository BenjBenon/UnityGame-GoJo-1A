using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public int life = 5;

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            StartCoroutine(Wait());
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Droplet")
        {
            if(life > 0)
                TakeDamage(life);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Droplet")
        {
            if (life > 0)
                TakeDamage(life);
        }
    }
    public IEnumerator Wait()
    {


        GetComponentInParent<Animator>().SetBool("IsDead", true);
        GetComponent<Transform>().GetChild(3).GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        GetComponent<Transform>().GetChild(3).GetComponent<ParticleSystem>().Stop();
        GetComponent<Transform>().GetChild(4).position += new Vector3(0, 0, -10);
        GetComponent<Transform>().GetChild(4).GetComponent<ParticleSystem>().Play();
        GetComponent<Transform>().GetChild(5).position += new Vector3(0, 0, -10);
        GetComponent<Transform>().GetChild(5).GetComponent<ParticleSystem>().Play();
        GetComponent<Transform>().GetChild(6).position += new Vector3(0, 0, -10);
        GetComponent<Transform>().GetChild(6).GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);

    }
}
