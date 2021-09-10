using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public float scoreP1 = 4f;
    public float scoreP2 = 4f;

    public GameObject gameOverP1;
    public GameObject gameOverP2;

    public static Score instance;

    [SerializeField] private GameObject score0;
    [SerializeField] private GameObject score1;
    [SerializeField] private GameObject score2;
    [SerializeField] private GameObject score3;
    [SerializeField] private GameObject score_1;
    [SerializeField] private GameObject score_2;
    [SerializeField] private GameObject score_3;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip P1winSound;

    void Awake()
     {
        instance = this;
     }

    void Update()
    {

        if(scoreP1 == 0)
        {
            gameOverP2.SetActive(true);
        }
        else if(scoreP2 == 0)
        {
            gameOverP1.SetActive(true);
            audioSource.PlayOneShot(P1winSound);
        }
        else if(scoreP1 == 1)
        {
            score_3.SetActive(true);
            score_2.SetActive(false);
        }
        else if(scoreP1 == 2)
        {
            score_2.SetActive(true);
            score_3.SetActive(false);
            score_1.SetActive(false);
        }
        else if(scoreP1 == 3)
        {
            score_1.SetActive(true);
            score_2.SetActive(false);
            score0.SetActive(false);
        }
        else if(scoreP1 == 4)
        {
            score0.SetActive(true);
            score1.SetActive(false);
            score_1.SetActive(false);
        }
        else if(scoreP1 == 5)
        {
            score1.SetActive(true);
            score0.SetActive(false);
            score2.SetActive(false);
        }
        else if(scoreP1 == 6)
        {
            score2.SetActive(true);
            score1.SetActive(false);
            score3.SetActive(false);
        }
        else if(scoreP1 == 7)
        {
            score3.SetActive(true);
            score2.SetActive(false);
        }
    }
}
