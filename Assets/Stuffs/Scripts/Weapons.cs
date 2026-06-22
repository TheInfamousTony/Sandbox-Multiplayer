using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapons : MonoBehaviour
{
    [HideInInspector]
    public int itemCode;
    [HideInInspector]
    public bool shootable;
    [HideInInspector]
    public bool allowShoot;

    public GameObject rocket;
    public GameObject grenade;
    public GameObject bubble;
    public GameObject decal;

    public float rocketForce;
    public float grenadeForce;
    public float bubbleForce;
    public float timeBetweenShots;
    public float stickRange;
    public float stickKnockbackForce;
    public Vector3 decalRotOffset;

    public PhotonView photonView;

    public Camera cam;
    public Transform shootPointRocket;
    public Transform shootPointGrenade;
    public Transform shootPointBubble;
    public RecoilAnim rocketRecoil;
    public RecoilAnim grenadeRecoil;
    public RecoilAnim stickRecoil;
    public AudioSource rocketLauncherSound;
    public AudioSource grenadeLauncherSound;
    public AudioSource stickSound;
    public AudioSource bubbleGunSound;
    public AudioSource draw1;
    public AudioSource draw2;
    public AudioSource draw3;

    GameObject projectile;
    Transform shootPoint;
    bool shootableTime;
    bool useGun;
    bool draw;

    void Start()
    {
        shootableTime = true;
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        itemCode = Mathf.Clamp(itemCode, 1, 5);

        if (itemCode == 1)
        {
            projectile = rocket;
            shootPoint = shootPointRocket;
            useGun = true;
            draw = false;
        }
        
        if (itemCode == 2)
        {
            projectile = grenade;
            shootPoint = shootPointGrenade;
            useGun = true;
            draw = false;
        }

        if(itemCode == 4)
        {
            projectile = bubble;
            shootPoint = shootPointBubble;
            useGun = true;
            draw = false;
        }

        if(itemCode == 3)
        {
            useGun = false;
            draw = false;
        }

        if(itemCode == 5)
        {
            useGun = false;
            draw = true;
        }

        if (Input.GetMouseButton(0) && shootable && allowShoot && shootableTime && useGun && !draw)
        {
            StartCoroutine(Shoot(projectile, shootPoint));
        }

        if (Input.GetMouseButton(0) && shootable && allowShoot && shootableTime && !useGun && !draw)
        {
            StartCoroutine(Melee());
        }

        if (Input.GetMouseButton(0) && shootable && allowShoot && shootableTime && !useGun && draw)
        {
            Draw();
        }
    }

    IEnumerator Shoot(GameObject projectile, Transform shootPoint)
    {
        shootableTime = false;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 direction = targetPoint - shootPoint.position;

        GameObject Projectile = PhotonNetwork.Instantiate(projectile.name, shootPoint.position, Quaternion.identity);
        Projectile.transform.forward = direction.normalized * -1;

        if(itemCode == 1)
        {
            Projectile.GetComponent<Rigidbody>().AddForce(direction.normalized * rocketForce, ForceMode.Impulse);
            StartCoroutine(rocketRecoil.Recoil());
            rocketLauncherSound.Play();
        }
        else if( itemCode == 2)
        {
            Projectile.GetComponent<Rigidbody>().AddForce(direction.normalized * grenadeForce, ForceMode.Impulse);
            Projectile.GetComponent<Rigidbody>().AddForce(cam.transform.up * grenadeForce / 5, ForceMode.Impulse);
            StartCoroutine(grenadeRecoil.Recoil());
            grenadeLauncherSound.Play();
        }
        else if (itemCode == 4)
        {
            Projectile.GetComponent<Rigidbody>().AddForce(direction.normalized * bubbleForce, ForceMode.Impulse);
            bubbleGunSound.Play();
        }

        yield return new WaitForSeconds(timeBetweenShots);
        shootableTime = true;
    }

    IEnumerator Melee()
    {
        shootableTime = false;

        StartCoroutine(stickRecoil.Recoil());
        stickSound.Play();
        yield return new WaitForSeconds(0.11f);
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, stickRange))
        {
            Rigidbody objRb = hit.transform.GetComponent<Rigidbody>();
            if(objRb != null)
            {
                objRb.AddForce(cam.transform.forward * stickKnockbackForce, ForceMode.Impulse);
            }
        }
        
        yield return new WaitForSeconds(timeBetweenShots);
        shootableTime = true;
    }

    void Draw()
    {
        RaycastHit hit;
        int randNum;
        randNum = Random.Range(1, 4);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, stickRange))
        {
            if(hit.transform.tag == "Paper")
            {
                Quaternion direction = Quaternion.Euler(hit.normal);
                if (randNum == 1)
                    draw1.Play();
                else if (randNum == 2)
                    draw2.Play();
                else
                    draw3.Play();
                GameObject Decal = PhotonNetwork.Instantiate(decal.name, hit.point, direction);
                Decal.transform.parent = hit.transform;
                
            }
        }
    }
}
