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
    private Vector2 AimPoint;

    [SerializeField] private Projectile projectile = null;
    [SerializeField] private GameObject anchor = null;
    [SerializeField] private GameObject arrow = null;

    // Start is called before the first frame update
    void Start()
    {
        initRot = transform.rotation;
        myPlayer = ReInput.players.GetPlayer(myPlayerId);

        transform.position = new Vector3(InitialMirror.transform.position.x, InitialMirror.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        AimPoint = new Vector2(myPlayer.GetAxis("AimHorizontal"), myPlayer.GetAxis("AimVertical"));
        float angle = Mathf.Atan2(AimPoint.y, AimPoint.x) * Mathf.Rad2Deg;
        anchor.GetComponent<Rigidbody2D>().rotation = angle;

        //Vector2 lookDir = (mousePos - GetComponent<Rigidbody2D>().position).normalized;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //GetComponent<Rigidbody2D>().rotation = angle;

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
                transform.position = new Vector3(Mirror.mirrors[i].transform.position.x, Mirror.mirrors[i].transform.position.y, 0);
            }
        } 
    }

    private void Shoot()
    {
        Projectile projectileInstance = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);
    }
}
