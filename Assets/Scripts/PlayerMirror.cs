using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMirror : MonoBehaviour
{
    public Mirror InitialMirror;

    private Quaternion initRot;

    public int myPlayerId;
    private Player myPlayer;

    public int mirrorMoveValue = 0;

    public Camera cam;

    [SerializeField] private Projectile projectile = null;

    // Start is called before the first frame update
    void Start()
    {
        initRot = transform.rotation;
        myPlayer = ReInput.players.GetPlayer(myPlayerId);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - GetComponent<Rigidbody2D>().position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = angle;

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
        Projectile projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
    }
}
