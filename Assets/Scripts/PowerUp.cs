using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        if(transform.position == player.transform.position)
        {
            //Destroy(gameObject, 0.2f);
        }
    }
}
