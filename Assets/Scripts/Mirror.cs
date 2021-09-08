using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public static List<Mirror> mirrors = new List<Mirror>();

    public enum CorrespondingKey
    {
        KeyOne = 0,
        KeyTwo = 1,
        KeyThree = 2,
        KeyFour =3
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
        
    }
}
