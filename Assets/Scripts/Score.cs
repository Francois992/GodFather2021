using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public float scoreP1 = 100f;
    public float scoreP2 = 100f;
    public float totalScore = 200f;

    public Image scoreBarP1;
    public Image scoreBarP2;

    public static Score instance;

    void Awake()
     {
        instance = this;
     }

    void Update()
    {
        scoreBarP1.fillAmount = scoreP1/totalScore;
        scoreBarP2.fillAmount = scoreP2/totalScore;
    }
}