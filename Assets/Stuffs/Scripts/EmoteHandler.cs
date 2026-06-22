using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EmoteHandler : MonoBehaviour
{
    public UIManager uiManager;
    public PlayerCamera playerCam;
    public GameObject itemHolding;
    public Animator anim;
    public PhotonView photonView;

    public AudioSource emoteSoundSource;

    [Header("Greet")]
    public AudioClip greet1;
    public AudioClip greet2;
    public AudioClip greet3;
    public AudioClip greet4;
    public AudioClip greet5;
    public AudioClip greet6;
    public AudioClip greet7;
    public AudioClip greet8;
    public AudioClip greet9;
    public AudioClip greet10;
    public AudioClip greet11;

    [Header("Laugh")]
    public AudioClip Laugh1;
    public AudioClip Laugh2;
    public AudioClip Laugh3;
    public AudioClip Laugh4;
    public AudioClip Laugh5;
    public AudioClip Laugh6;
    public AudioClip Laugh7;
    public AudioClip Laugh8;
    public AudioClip Laugh9;
    public AudioClip Laugh10;

    [Header("Warn")]
    public AudioClip Warn1;
    public AudioClip Warn2;
    public AudioClip Warn3;
    public AudioClip Warn4;
    public AudioClip Warn5;
    public AudioClip Warn6;
    public AudioClip Warn7;

    [Header("Scream")]
    public AudioClip Scream1;
    public AudioClip Scream2;
    public AudioClip Scream3;
    public AudioClip Scream4;
    public AudioClip Scream5;
    public AudioClip Scream6;
    public AudioClip Scream7;
    public AudioClip Scream8;

    [Header("Help")]
    public AudioClip Help1;
    public AudioClip Help2;
    public AudioClip Help3;
    public AudioClip Help4;
    public AudioClip Help5;
    public AudioClip Help6;
    public AudioClip Help7;

    [Header("Yes")]
    public AudioClip Yes1;
    public AudioClip Yes2;
    public AudioClip Yes3;
    public AudioClip Yes4;
    public AudioClip Yes5;
    public AudioClip Yes6;
    public AudioClip Yes7;
    public AudioClip Yes8;

    [Header("No")]
    public AudioClip No1;
    public AudioClip No2;
    public AudioClip No3;
    public AudioClip No4;
    public AudioClip No5;
    public AudioClip No6;
    public AudioClip No7;
    public AudioClip No8;

    [HideInInspector]
    public int emoteCode;

    bool emoteDone;
    AudioClip emoteAudio;
    int randAudio;

    void Start()
    {
        emoteDone = true;
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (uiManager.emoteOn)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && emoteDone)
            {
                StartCoroutine(Greeting());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && emoteDone)
            {
                StartCoroutine(Laughing());
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && emoteDone)
            {
                StartCoroutine(Warning());
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && emoteDone)
            {
                StartCoroutine(Screaming());
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && emoteDone)
            {
                StartCoroutine(Help());
            }
            if (Input.GetKeyDown(KeyCode.Alpha6) && emoteDone)
            {
                StartCoroutine(No());
            }
            if (Input.GetKeyDown(KeyCode.Alpha7) && emoteDone)
            {
                StartCoroutine(Yes());
            }
            if (Input.GetKeyDown(KeyCode.Alpha8) && emoteDone)
            {
                StartCoroutine(Questionable());
            }
        }
    }

    IEnumerator Greeting()
    {
        randAudio = Random.Range(1, 12);

        if (randAudio == 1)
            emoteAudio = greet1;
        else if (randAudio == 2)
            emoteAudio = greet2;
        else if (randAudio == 3)
            emoteAudio = greet3;
        else if (randAudio == 4)
            emoteAudio = greet4;
        else if (randAudio == 5)
            emoteAudio = greet5;
        else if (randAudio == 6)
            emoteAudio = greet6;
        else if (randAudio == 7)
            emoteAudio = greet7;
        else if (randAudio == 8)
            emoteAudio = greet8;
        else if (randAudio == 9)
            emoteAudio = greet9;
        else if (randAudio == 10)
            emoteAudio = greet10;
        else
            emoteAudio = greet11;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Greeting", true);

        yield return new WaitForSeconds(3.05f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Greeting", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator Laughing()
    {
        randAudio = Random.Range(1, 11);

        if (randAudio == 1)
            emoteAudio = Laugh1;
        else if (randAudio == 2)
            emoteAudio = Laugh2;
        else if (randAudio == 3)
            emoteAudio = Laugh3;
        else if (randAudio == 4)
            emoteAudio = Laugh4;
        else if (randAudio == 5)
            emoteAudio = Laugh5;
        else if (randAudio == 6)
            emoteAudio = Laugh6;
        else if (randAudio == 7)
            emoteAudio = Laugh7;
        else if (randAudio == 8)
            emoteAudio = Laugh8;
        else if (randAudio == 9)
            emoteAudio = Laugh9;
        else
            emoteAudio = Laugh10;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Laughing", true);

        yield return new WaitForSeconds(6.1f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Laughing", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator Warning()
    {
        randAudio = Random.Range(1, 8);

        if (randAudio == 1)
            emoteAudio = Warn1;
        else if (randAudio == 2)
            emoteAudio = Warn2;
        else if (randAudio == 3)
            emoteAudio = Warn3;
        else if (randAudio == 4)
            emoteAudio = Warn4;
        else if (randAudio == 5)
            emoteAudio = Warn5;
        else if (randAudio == 6)
            emoteAudio = Warn6;
        else
            emoteAudio = Warn7;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Warning", true);

        yield return new WaitForSeconds(10.27f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Warning", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator Screaming()
    {
        randAudio = Random.Range(1, 9);

        if (randAudio == 1)
            emoteAudio = Scream1;
        else if (randAudio == 2)
            emoteAudio = Scream2;
        else if (randAudio == 3)
            emoteAudio = Scream3;
        else if (randAudio == 4)
            emoteAudio = Scream4;
        else if (randAudio == 5)
            emoteAudio = Scream5;
        else if (randAudio == 6)
            emoteAudio = Scream6;
        else if (randAudio == 7)
            emoteAudio = Scream7;
        else
            emoteAudio = Scream8;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Screaming", true);

        yield return new WaitForSeconds(4.09f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Screaming", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator Help()
    {
        randAudio = Random.Range(1, 8);

        if (randAudio == 1)
            emoteAudio = Help1;
        else if (randAudio == 2)
            emoteAudio = Help2;
        else if (randAudio == 3)
            emoteAudio = Help3;
        else if (randAudio == 4)
            emoteAudio = Help4;
        else if (randAudio == 5)
            emoteAudio = Help5;
        else if (randAudio == 6)
            emoteAudio = Help6;
        else 
            emoteAudio = Help7;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Help", true);

        yield return new WaitForSeconds(5.02f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Help", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator Questionable()
    {
        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Questionable", true);

        yield return new WaitForSeconds(1.23f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Questionable", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator Yes()
    {
        randAudio = Random.Range(1, 9);

        if (randAudio == 1)
            emoteAudio = Yes1;
        else if (randAudio == 2)
            emoteAudio = Yes2;
        else if (randAudio == 3)
            emoteAudio = Yes3;
        else if (randAudio == 4)
            emoteAudio = Yes4;
        else if (randAudio == 5)
            emoteAudio = Yes5;
        else if (randAudio == 6)
            emoteAudio = Yes6;
        else if (randAudio == 7)
            emoteAudio = Yes7;
        else
            emoteAudio = Yes8;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("Yes", true);

        yield return new WaitForSeconds(1.19f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("Yes", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }

    IEnumerator No()
    {
        randAudio = Random.Range(1, 8);

        if (randAudio == 1)
            emoteAudio = No1;
        else if (randAudio == 2)
            emoteAudio = No2;
        else if (randAudio == 3)
            emoteAudio = No3;
        else if (randAudio == 4)
            emoteAudio = No4;
        else if (randAudio == 5)
            emoteAudio = No5;
        else if (randAudio == 6)
            emoteAudio = No6;
        else
            emoteAudio = No7;

        emoteSoundSource.clip = emoteAudio;
        emoteSoundSource.Play();

        uiManager.weapons.allowShoot = false;
        uiManager.playerMovement.stopMove = true;
        uiManager.buildingSystem.stopDo = true;
        emoteDone = false;
        playerCam.emoting = true;
        itemHolding.SetActive(false);
        anim.SetBool("No", true);

        yield return new WaitForSeconds(1.24f);

        uiManager.weapons.allowShoot = true;
        uiManager.playerMovement.stopMove = false;
        uiManager.buildingSystem.stopDo = false;
        emoteDone = true;
        playerCam.emoting = false;
        itemHolding.SetActive(true);
        anim.SetBool("No", false);

        uiManager.emoteOn = false;
        uiManager.emoteMenu.SetActive(false);
    }
}
