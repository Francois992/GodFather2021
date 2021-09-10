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

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mirrorShoot;

    private bool isMoving = false;
    private bool hasMoving = false;

    private Mirror currentMirror = null;

    private float alphaFade;
    private float timerFade;
    public float fadeSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        initRot = transform.rotation;
        myPlayer = ReInput.players.GetPlayer(myPlayerId);

        transform.position = new Vector3(InitialMirror.transform.position.x, InitialMirror.transform.position.y, 0);
        currentMirror = InitialMirror;
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

        if (myPlayer.GetButtonDown("Shoot") && !hasShot && !isMoving && !hasMoving)
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

        if(!isMoving && !hasMoving)
        {
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

        if (currentMirror.hasboomerangdPU)
        {
            isBoomerang = true;
        }
        else
        {
            isBoomerang = false;
        }

        if (currentMirror.hasSpreadPU)
        {
            isSpread = true;
        }
        else
        {
            isSpread = false;
        }

        if (isMoving)
        {
            timerFade += Time.deltaTime;
            alphaFade = Mathf.Lerp(1, 0, timerFade * fadeSpeed);
            Color fadeColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            fadeColor.a = alphaFade;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = fadeColor;
            if (transform.GetChild(0).GetComponent<SpriteRenderer>().color.a <= 0.02)
            {
                hasMoving = true;
                transform.position = new Vector3(currentMirror.transform.position.x, currentMirror.transform.position.y, 0);
                fadeColor.a = 0;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = fadeColor;
                isMoving = false;
                timerFade = 0;
            }
        }
        else if (hasMoving)
        {
            timerFade += Time.deltaTime;
            alphaFade = Mathf.Lerp(0, 1, timerFade * fadeSpeed);
            Color fadeColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            fadeColor.a = alphaFade;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = fadeColor;
            if (transform.GetChild(0).GetComponent<SpriteRenderer>().color.a >= 0.95)
            {
                hasMoving = false;
                fadeColor.a = 1;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = fadeColor;
                hasMove = true;
                timerFade = 0;
            }
        }

        if (myPlayer.GetAxis("AimHorizontal") > 0) transform.GetChild(0).transform.localScale = new Vector3(1, transform.GetChild(0).transform.localScale.y, transform.GetChild(0).transform.localScale.z);
        else if (myPlayer.GetAxis("AimHorizontal") < 0)
        {
            transform.GetChild(0).transform.localScale = new Vector3(-1, transform.GetChild(0).transform.localScale.y, transform.GetChild(0).transform.localScale.z);
        }
    }

    private void MoveToMirror()
    {
        for(int i = Mirror.mirrors.Count - 1; i >= 0; i--)
        {
            if (mirrorMoveValue == (int)Mirror.mirrors[i].correspondingKey && !Mirror.mirrors[i].isBroken && !hasMove && currentMirror != Mirror.mirrors[i])
            {
                isMoving = true;
                currentMirror = Mirror.mirrors[i];

                
            }
        }
    }

    private void Shoot()
    {
        Projectile projectileInstance = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);
        audioSource.PlayOneShot(mirrorShoot);
    }

    private void SpreadShot()
    {
        for (int i = 0; i< ShotCountSpread; i++)
        {
            float zRot = arrow.transform.rotation.eulerAngles.z - ShotAngleSpread + ShotAngleSpread * i;
            Quaternion rotationShoot = Quaternion.Euler(new Vector3(arrow.transform.rotation.eulerAngles.x, arrow.transform.rotation.eulerAngles.y, zRot));
            currentMirror.hasSpreadPU = false;
            Destroy(currentMirror.myPowerUp.gameObject);
            Projectile projectileInstance = Instantiate(projectile, arrow.transform.position,rotationShoot);
            isSpread = false;
        }
    }

    private void BoomerangShot()
    {
        Boomerang boomerangInstance = Instantiate(boomerang, arrow.transform.position, arrow.transform.rotation);
        Destroy(currentMirror.myPowerUp.gameObject);
        currentMirror.hasboomerangdPU = false;
        isBoomerang = false;
    }
}
