using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMirror : MonoBehaviour
{
    public Mirror InitialMirror;

    public int myPlayerId;
    private Player myPlayer;

    public int mirrorMoveValue = 0;

    [SerializeField] private Projectile projectile;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = ReInput.players.GetPlayer(myPlayerId);
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.GetButtonDown("Shoot"))
        {
            Shoot();
        }

        if (myPlayer.GetButtonDown("SwitchMirror1"))
        {
            mirrorMoveValue = 0;
            MoveToMirror();
        }
        else if (myPlayer.GetButtonDown("SwitchMirror2"))
        {
            mirrorMoveValue = 1;
            MoveToMirror();
        }
        else if (myPlayer.GetButtonDown("SwitchMirror3"))
        {
            mirrorMoveValue = 2;
            MoveToMirror();
        }
        else if (myPlayer.GetButtonDown("SwitchMirror4"))
        {
            mirrorMoveValue = 3;
            MoveToMirror();
        }
    }

    private void MoveToMirror()
    {
        for(int i = Mirror.mirrors.Count - 1; i >= 0; i--)
        {
            if (mirrorMoveValue == (int)Mirror.mirrors[i].correspondingKey)
            {
                transform.position = Mirror.mirrors[i].transform.position;
            }
        } 
    }

    private void Shoot()
    {
        Vector2 direction = Input.mousePosition - transform.position;
        Projectile projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileInstance.MoveVector = direction;
    }
}
