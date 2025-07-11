using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public string PlayerTag;
    public bool isReached = false;

    private void Update()
    {
        GameObject[] slimes = GameObject.FindGameObjectsWithTag(PlayerTag);
        if (slimes.Length == 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == PlayerTag)
        {
            Debug.Log("yo");
            GameObject[] slimes = GameObject.FindGameObjectsWithTag(PlayerTag);
            foreach(GameObject s in slimes) { 
            Destroy(s.GetComponentInParent<PlayerController>());    
            }
            isReached = true;
            int counter = 0;
            GameObject[] flags = GameObject.FindGameObjectsWithTag("Flag");
            for(int i = 0; i < flags.Length; i++)
            {
                if (flags[i].GetComponent<Flag>().isReached == true)
                {
                    counter++;
                }
            }
            if(counter == flags.Length) {
                SceneManager.LoadScene("Level-Select");
            }
        }
    }
}
