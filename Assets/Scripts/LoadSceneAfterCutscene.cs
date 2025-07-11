using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeOfCutscene;
    public string sceneName;
    // Update is called once per frame
    void Update()
    {
        timeOfCutscene -= Time.deltaTime;
        if (timeOfCutscene <= 0 )
            SceneManager.LoadScene( sceneName );
    }
}
