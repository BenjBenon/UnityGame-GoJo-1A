using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{

    public static LoadingScreenManager instance;
    public GameObject m_LoadingScreenObject;
    public Slider ProgressBar;

    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SwitchtoScene(string SceneName )
    {
        m_LoadingScreenObject.SetActive(true);
        ProgressBar.value = 0;
        StartCoroutine(SwitchToSceneAsync(SceneName));
    }

    IEnumerator SwitchToSceneAsync(string SceneName)
    {
        yield return new WaitForSeconds(1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone) 
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            ProgressBar.value = progress;

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        m_LoadingScreenObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
