using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string SceneName;

    [SerializeField] GameObject exitPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //

    public void Change()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void PlayChange()
    {
        LoadingScreenManager.instance.SwitchtoScene(SceneName);
    }

    public void QuitChange()
    {
       exitPanel.SetActive(true);
    }

    public void onUserClickYesorNOt(int choice)
    {
        if (choice == 1) 
        {
            Application.Quit();
        }
        exitPanel.SetActive(false);
    }
}
