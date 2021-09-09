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
    [SerializeField] private Boomerang boomerang = null;
    [SerializeField] private GameObject anchor = null;
    [SerializeField] private GameObject arrow = null;

    [SerializeField] private int ShotCountSpread = 3;
    [SerializeField] private int ShotAngleSpread = 45;
    [SerializeField] private float Shotcooldown = 1f;
    [SerializeField] private float Mirrorcooldown = 1f;

    private bool hasShot = false;
    private bool hasMove = false;

    public bool isSpread = false;
    public bool isBoomerang = false;

    private float elapsedTime;
    private float elapsedTime2;

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

        if (myPlayer.GetButtonDown("Shoot") && !hasShot)
        {
            if (isSpread) SpreadShot();
            else if (isBoomerang) BoomerangShot();
            else Shoot();

            hasShot = true;
        }

        if (hasShot)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= Shotcooldown)
            {
                elapsedTime = 0;
                hasShot = false;
            }
        }
        
        if (hasMove)
        {
            elapsedTime2 += Time.deltaTime;
            if(elapsedTime2 >= Mirrorcooldown)
            {
                elapsedTime2 = 0;
                hasMove = false;
            }
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
        else if (myPlayer.GetButtonDown("SwitchMirror5"))
        {
            mirrorMoveValue = 4;
            MoveToMirror();
        }
        else if (myPlayer.GetButtonDown("SwitchMirror6"))
        {
            mirrorMoveValue = 5;
            MoveToMirror();
        }
        else if (myPlayer.GetButtonDown("SwitchMirror7"))
        {
            mirrorMoveValue = 6;
            MoveToMirror();
        }
        else if (myPlayer.GetButtonDown("SwitchMirror8"))
        {
            mirrorMoveValue = 7;
            MoveToMirror();
        }
    }

    private void MoveToMirror()
    {
        for(int i = Mirror.mirrors.Count - 1; i >= 0; i--)
        {
            if (mirrorMoveValue == (int)Mirror.mirrors[i].correspondingKey && !Mirror.mirrors[i].isBroken && !hasMove)
            {
                transform.position = new Vector3(Mirror.mirrors[i].transform.position.x, Mirror.mirrors[i].transform.position.y, 0);
                hasMove = true;
            }
        } 
    }

    private void Shoot()
    {
        Projectile projectileInstance = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);
    }

    private void SpreadShot()
    {
        for (int i = 0; i< ShotCountSpread; i++)
        {
            float zRot = arrow.transform.rotation.eulerAngles.z - ShotAngleSpread + ShotAngleSpread * i;
            Quaternion rotationShoot = Quaternion.Euler(new Vector3(arrow.transform.rotation.eulerAngles.x, arrow.transform.rotation.eulerAngles.y, zRot));

            Projectile projectileInstance = Instantiate(projectile, arrow.transform.position,rotationShoot);
            isSpread = false;
        }
    }

    private void BoomerangShot()
    {
        Boomerang boomerangInstance = Instantiate(boomerang, arrow.transform.position, arrow.transform.rotation);

        isBoomerang = false;
    }
}
