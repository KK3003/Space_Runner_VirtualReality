using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] Transform Playerpos;
    [SerializeField] GameObject player;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent.destination = Playerpos.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Time.timeScale = 0;
            UIManager.instance.gameOverPanel.SetActive(true);
            Debug.Log("Player Died");
        }
    }
}
