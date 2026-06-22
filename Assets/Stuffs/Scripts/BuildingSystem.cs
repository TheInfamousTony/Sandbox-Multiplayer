using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BuildingSystem : MonoBehaviour
{
    public Transform cam;
    public GameObject normalBlock;
    public GameObject glowBlock;
    public GameObject trampoline;
    public GameObject voidBlock;
    public GameObject paperBlock;
    public GameObject blockPreview;
    public ParticleSystem breakParticle;
    [HideInInspector]
    public GameObject blockParent;
    public GameObject entitySpawnPos;
    [HideInInspector]
    public GameObject entityParent;
    public GameObject ragdoll;
    public GameObject manicRagdoll;
    public GameObject ball;
    public GameObject explosiveBarrel;
    public GameObject milk;
    public GameObject glowStick;
    public GameObject blockIH;
    public GameObject glowBlockIH;

    public PlayerCamera playerCam;

    public PhotonView photonView;

    public Color blue;
    public Color green;
    public Color grey;
    public Color red;
    public Color pink;
    public Color purple;

    [HideInInspector]
    public int colorCode = 1;
    [HideInInspector]
    public int entityCode = 1;
    [HideInInspector]
    public int blockCode = 1;
    [HideInInspector]
    public bool stopBuild = false;
    [HideInInspector]
    public bool stopSpawn = true;
    [HideInInspector]
    public bool stopDo = false;

    Color blockColor;
    Vector3 prevPos;

    string block;
    string entity;

    void Start()
    {
        entityParent = GameObject.FindGameObjectWithTag("EntityParent");
        blockParent = GameObject.FindGameObjectWithTag("BlockParent");
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            blockPreview.SetActive(false);
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(!stopBuild && stopSpawn && !stopDo)
            {
                BuildBlock();
            }
            if(stopBuild && !stopSpawn && !stopDo)
            {
                SpawnEntity(entity);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!stopBuild && stopSpawn && !stopDo)
            {
                StartCoroutine(DestroyBlock());
            }
            if (stopBuild && !stopSpawn && !stopDo)
            {
                DestroyEntity();
            }
        }

        if(PhotonNetwork.IsMasterClient == true && Input.GetKeyDown(KeyCode.P))
        {
            foreach (Transform child in entityParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        colorCode = Mathf.Clamp(colorCode, 1, 6);
        blockCode = Mathf.Clamp(blockCode, 1, 5);
        entityCode = Mathf.Clamp(entityCode, 1, 6);

        if(colorCode == 1)
        {
            blockColor = blue;
        }
        if (colorCode == 2)
        {
            blockColor = green;
        }
        if (colorCode == 3)
        {
            blockColor = grey;
        }
        if (colorCode == 4)
        {
            blockColor = red;
        }
        if (colorCode == 5)
        {
            blockColor = pink;
        }
        if (colorCode == 6)
        {
            blockColor = purple;
        }

        if(blockCode == 1)
        {
            block = "Block";
        }
        if(blockCode == 2)
        {
            block = "GlowBlock";
        }
        if(blockCode == 3)
        {
            block = "Trampoline";
        }
        if(blockCode == 4)
        {
            block = "Void";
        }
        if(blockCode == 5)
        {
            block = "Paper Block";
        }

        if(entityCode == 1)
        {
            entity = "Ragdoll";
        }
        if (entityCode == 2)
        {
            entity = "ManicRagdoll";
        }
        if (entityCode == 3)
        {
            entity = "ExplosiveBarrel";
        }
        if (entityCode == 4)
        {
            entity = "Ball";
        }
        if (entityCode == 5)
        {
            entity = "Milk";
        }
        if (entityCode == 6)
        {
            entity = "GlowStick";
        }


        if (!stopBuild)
            blockPreview.SetActive(true);
        else
            blockPreview.SetActive(false);

        BlockPreview();

        blockIH.transform.gameObject.GetComponent<Renderer>().material.color = blockColor;
        glowBlockIH.transform.gameObject.GetComponent<Renderer>().material.color = blockColor;
    }

    void BuildBlock()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit))
        {
            if (hit.transform.tag == "Blocks" || hit.transform.tag == "Paper")
            {
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hit.point.x + hit.normal.x / 2), Mathf.RoundToInt(hit.point.y + hit.normal.y / 2), Mathf.RoundToInt(hit.point.z + hit.normal.z / 2));
                GameObject blockPrefab = PhotonNetwork.Instantiate(block, spawnPosition, Quaternion.identity);
                blockPrefab.transform.parent = blockParent.transform;
                ChangeColorBlock changeColorBlock = blockPrefab.GetComponent<ChangeColorBlock>();
                if(blockCode == 1)
                    changeColorBlock.ChangeBlockColor(blockColor.r, blockColor.g, blockColor.b, false);
                else if(blockCode == 2)
                    changeColorBlock.ChangeBlockColor(blockColor.r, blockColor.g, blockColor.b, true);


            }
            else if(hit.transform.tag != "Blocks" || hit.transform.tag == "Paper")
            {
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z));
                GameObject blockPrefab = PhotonNetwork.Instantiate(block, spawnPosition, Quaternion.identity);
                blockPrefab.transform.parent = blockParent.transform;
                ChangeColorBlock changeColorBlock = blockPrefab.GetComponent<ChangeColorBlock>();
                if (blockCode == 1)
                    changeColorBlock.ChangeBlockColor(blockColor.r, blockColor.g, blockColor.b, false);
                else if (blockCode == 2)
                    changeColorBlock.ChangeBlockColor(blockColor.r, blockColor.g, blockColor.b, true);
            }
        }
    }

    void SpawnEntity(string entity)
    {
        GameObject Entity = PhotonNetwork.Instantiate(entity, entitySpawnPos.transform.position, Quaternion.Euler(0f, 0f, 0f));
        Entity.transform.parent = entityParent.transform;
    }

    void DestroyEntity()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit))
        {
            if (hit.transform.tag == "Entities")
            {
                DeleteRagdoll deleteRagdoll = hit.transform.GetComponent<DeleteRagdoll>();

                if (deleteRagdoll != null)
                    deleteRagdoll.Delete();
                else
                    PhotonNetwork.Destroy(hit.transform.gameObject);
            }
            else if(hit.transform.tag == "ExplosiveBarrels")
            {
                ExplosiveBarrel explosiveBarrelScript = hit.transform.GetComponent<ExplosiveBarrel>();
                explosiveBarrelScript.ExplosiveBarrelFunction();

            }
        }
    }

    IEnumerator DestroyBlock()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit))
        {
            if (hit.transform.tag == "Blocks" || hit.transform.tag == "Paper")
            {
                Vector3 particlePos = hit.transform.gameObject.transform.position;
                GameObject particle = PhotonNetwork.Instantiate("BreakBlock", particlePos, Quaternion.identity);
                Destroy(hit.transform.gameObject);
                yield return new WaitForSeconds(0.2f);
                PhotonNetwork.Destroy(particle);
            }
        }
    }

    void BlockPreview()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit))
        {
            if (hit.transform.tag == "Blocks" || hit.transform.tag == "Paper")
            {
                prevPos = new Vector3(Mathf.RoundToInt(hit.point.x + hit.normal.x / 2), Mathf.RoundToInt(hit.point.y + hit.normal.y / 2), Mathf.RoundToInt(hit.point.z + hit.normal.z / 2));
            }
            else
            {
                prevPos = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z));
            }
        }
        blockPreview.transform.position = prevPos;
    }
}
