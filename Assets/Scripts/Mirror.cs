using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public static List<Mirror> mirrors = new List<Mirror>();
    public bool isBroken = false;

    [SerializeField] private float repairTime = 10;

    public bool hasSpreadPU = false;
    public bool hasboomerangdPU = false;
    private float elapsedTime = 0;

    public PowerUp myPowerUp;

    public enum CorrespondingKey
    {
        KeyOne = 0,
        KeyTwo = 1,
        KeyThree = 2,
        KeyFour = 3,
        KeyFive = 4,
        KeySix =3,
        KeySeven =3,
        KeyEight =3
    }

    public CorrespondingKey correspondingKey;

    // Start is called before the first frame update
    void Start()
    {
        mirrors.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBroken)
        {           
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= repairTime)
            {
                isBroken = false;
                elapsedTime = 0;
            }
        }
    }

    public void BreakMirror()
    {
        isBroken = true;
    }
}
