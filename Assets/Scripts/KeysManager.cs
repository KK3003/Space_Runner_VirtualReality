using UnityEngine;
using UnityEngine.SceneManagement;

public class KeysManager : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.instance.pausePanel.activeInHierarchy == false )
            {
                UIManager.instance.pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                UIManager.instance.pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            ChangeScene("Home");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeScene("New");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeScene("New");
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

   