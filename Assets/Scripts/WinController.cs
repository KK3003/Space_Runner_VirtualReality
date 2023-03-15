using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            UIManager.instance.wonPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("player survived");
        }
    }
}
