using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if(instance== null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject infoText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject wonPanel;
}
