using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject escapeMenu;
    public GameObject settingsMenu;
    public GameObject emoteMenu;
    public PlayerMovement playerMovement;
    public BuildingSystem buildingSystem;
    public Weapons weapons;

    public GameObject blueBlock;
    public GameObject greenBlock;
    public GameObject greyBlock;
    public GameObject redBlock;
    public GameObject pinkBlock;
    public GameObject purpleBlock;
    public GameObject glowBlueBlock;
    public GameObject glowGreenBlock;
    public GameObject glowGreyBlock;
    public GameObject glowRedBlock;
    public GameObject glowPinkBlock;
    public GameObject glowPurpleBlock;
    public GameObject ragdoll;
    public GameObject manicRagdoll;
    public GameObject explosiveBarrel;
    public GameObject rocketLauncher;
    public GameObject grenadeLauncher;
    public GameObject ball;
    public GameObject milk;
    public GameObject stick;
    public GameObject glowStick;
    public GameObject bubbleGun;
    public GameObject trampoline;
    public GameObject voidBlock;
    public GameObject paperBlock;
    public GameObject brush;
    public GameObject selector;
    public GameObject blockTab;
    public GameObject entityTab;
    public GameObject itemTab;
    public GameObject tooltip;

    public GameObject blockIH;
    public GameObject glowBlockIH;
    public GameObject ragdollIH;
    public GameObject manicRagdollIH;
    public GameObject explosiveBarrelIH;
    public GameObject rocketLauncherIH;
    public GameObject grenadeLauncherIH;
    public GameObject stickIH;
    public GameObject ballIH;
    public GameObject milkIH;
    public GameObject glowStickIH;
    public GameObject bubbleGunIH;
    public GameObject trampolineIH;
    public GameObject voidBlockIH;
    public GameObject paperBlockIH;
    public GameObject brushIH;

    public Text sensitivityCount;
    public Dropdown resolutionDropdown;

    public PhotonView photonView;

    bool menuOn;
    bool eMenuOn;
    bool settingOn;
    [HideInInspector]
    public bool emoteOn;
    bool menuUnopenable = false;
    bool emotable;

    Resolution[] resolutions;

    void Start()
    {
        Blue();

        emotable = true;
        playerMovement.sensitivity = 400f;

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && !menuUnopenable)
        {
            menuOn = !menuOn;
            menu.SetActive(menuOn);

            playerMovement.stopLook = menuOn;

            weapons.allowShoot = !menuOn;
            playerMovement.stopMove = menuOn;
            buildingSystem.stopDo = menuOn;
            emotable = !menuOn;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            eMenuOn = !eMenuOn;
            menuUnopenable = eMenuOn;
            escapeMenu.SetActive(eMenuOn);

            playerMovement.stopLook = eMenuOn;

            weapons.allowShoot = !eMenuOn;
            playerMovement.stopMove = eMenuOn;
            buildingSystem.stopDo = eMenuOn;
            emotable = !eMenuOn;
        }

        if(menuOn && Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.stopLook = true;

            weapons.allowShoot = false;
            playerMovement.stopMove = true;
            buildingSystem.stopDo = true;
            emotable = false;
        }

        if(settingOn && Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.stopLook = false;

            playerMovement.stopMove = false;
            buildingSystem.stopDo = false;
            weapons.allowShoot = true;

            settingsMenu.SetActive(false);
            settingOn = false;
            emotable = true;
        }

        if(!menuOn)
        {
            tooltip.SetActive(false);
        }

        if(emotable && !menuOn && !eMenuOn && !settingOn && Input.GetKeyDown(KeyCode.G))
        {
            emoteOn = !emoteOn;
            emoteMenu.SetActive(emoteOn);
        }
    }

    public void BlocksTab()
    {
        entityTab.SetActive(false);
        blockTab.SetActive(true);
        itemTab.SetActive(false);
    }

    public void EntitiesTab()
    {
        entityTab.SetActive(true);
        blockTab.SetActive(false);
        itemTab.SetActive(false);
    }

    public void ItemsTab()
    {
        entityTab.SetActive(false);
        blockTab.SetActive(false);
        itemTab.SetActive(true);
    }

    public void Blue()
    {
        selector.transform.position = blueBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 1;
        buildingSystem.colorCode = 1;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(true);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void Green()
    {
        selector.transform.position = greenBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 1;
        buildingSystem.colorCode = 2;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(true);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void Grey()
    {
        selector.transform.position = greyBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 1;
        buildingSystem.colorCode = 3;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(true);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void Red()
    {
        selector.transform.position = redBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 1;
        buildingSystem.colorCode = 4;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(true);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void Pink()
    {
        selector.transform.position = pinkBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 1;
        buildingSystem.colorCode = 5;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(true);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void Purple()
    {
        selector.transform.position = purpleBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 1;
        buildingSystem.colorCode = 6;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(true);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void BlueGlow()
    {
        selector.transform.position = glowBlueBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 2;
        buildingSystem.colorCode = 1;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(true);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void GreenGlow()
    {
        selector.transform.position = glowGreenBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 2;
        buildingSystem.colorCode = 2;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(true);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void GreyGlow()
    {
        selector.transform.position = glowGreyBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 2;
        buildingSystem.colorCode = 3;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(true);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void RedGlow()
    {
        selector.transform.position = glowRedBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 2;
        buildingSystem.colorCode = 4;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(true);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void PinkGlow()
    {
        selector.transform.position = glowPinkBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 2;
        buildingSystem.colorCode = 5;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(true);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }
    public void PurpleGlow()
    {
        selector.transform.position = glowPurpleBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 2;
        buildingSystem.colorCode = 6;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(true);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void Trampoline()
    {
        selector.transform.position = trampoline.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 3;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(true);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void VoidBlock()
    {
        selector.transform.position = voidBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 4;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(true);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void PaperBlock()
    {
        selector.transform.position = paperBlock.transform.position;
        selector.transform.SetParent(blockTab.transform);
        buildingSystem.blockCode = 5;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = false;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(true);
        brushIH.SetActive(false);
    }

    public void Ragdoll()
    {
        selector.transform.position = ragdoll.transform.position;
        selector.transform.SetParent(entityTab.transform);
        buildingSystem.entityCode = 1;
        buildingSystem.stopSpawn = false;
        buildingSystem.stopBuild = true;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(true);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void Manic()
    {
        selector.transform.position = manicRagdoll.transform.position;
        selector.transform.SetParent(entityTab.transform);
        buildingSystem.entityCode = 2;
        buildingSystem.stopSpawn = false;
        buildingSystem.stopBuild = true;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(true);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void ExplosiveBarrel()
    {
        selector.transform.position = explosiveBarrel.transform.position;
        selector.transform.SetParent(entityTab.transform);
        buildingSystem.entityCode = 3;
        buildingSystem.stopSpawn = false;
        buildingSystem.stopBuild = true;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(true);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void Ball()
    {
        selector.transform.position = ball.transform.position;
        selector.transform.SetParent(entityTab.transform);
        buildingSystem.entityCode = 4;
        buildingSystem.stopSpawn = false;
        buildingSystem.stopBuild = true;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(true);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void Milk()
    {
        selector.transform.position = milk.transform.position;
        selector.transform.SetParent(entityTab.transform);
        buildingSystem.entityCode = 5;
        buildingSystem.stopSpawn = false;
        buildingSystem.stopBuild = true;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(true);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void GlowStick()
    {
        selector.transform.position = glowStick.transform.position;
        selector.transform.SetParent(entityTab.transform);
        buildingSystem.entityCode = 6;
        buildingSystem.stopSpawn = false;
        buildingSystem.stopBuild = true;
        weapons.shootable = false;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(true);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void RocketLauncher()
    {
        selector.transform.position = rocketLauncher.transform.position;
        selector.transform.SetParent(itemTab.transform);
        weapons.itemCode = 1;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = true;
        weapons.shootable = true;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(true);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void GrenadeLauncher()
    {
        selector.transform.position = grenadeLauncher.transform.position;
        selector.transform.SetParent(itemTab.transform);
        weapons.itemCode = 2;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = true;
        weapons.shootable = true;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(true);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void Stick()
    {
        selector.transform.position = stick.transform.position;
        selector.transform.SetParent(itemTab.transform);
        weapons.itemCode = 3;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = true;
        weapons.shootable = true;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(true);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void BubbleGun()
    {
        selector.transform.position = bubbleGun.transform.position;
        selector.transform.SetParent(itemTab.transform);
        weapons.itemCode = 4;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = true;
        weapons.shootable = true;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(true);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(false);
    }

    public void Brush()
    {
        selector.transform.position = brush.transform.position;
        selector.transform.SetParent(itemTab.transform);
        weapons.itemCode = 5;
        buildingSystem.stopSpawn = true;
        buildingSystem.stopBuild = true;
        weapons.shootable = true;

        blockIH.SetActive(false);
        glowBlockIH.SetActive(false);
        ragdollIH.SetActive(false);
        manicRagdollIH.SetActive(false);
        explosiveBarrelIH.SetActive(false);
        rocketLauncherIH.SetActive(false);
        grenadeLauncherIH.SetActive(false);
        stickIH.SetActive(false);
        ballIH.SetActive(false);
        milkIH.SetActive(false);
        glowStickIH.SetActive(false);
        bubbleGunIH.SetActive(false);
        trampolineIH.SetActive(false);
        voidBlockIH.SetActive(false);
        paperBlockIH.SetActive(false);
        brushIH.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenSetting()
    {
        menu.SetActive(false);
        escapeMenu.SetActive(false);
        settingsMenu.SetActive(true);
        settingOn = true;
    }

    public void SetVolume(float volume)
    {
        string volumeStr = volume.ToString();
        sensitivityCount.text = volumeStr;

        playerMovement.sensitivity = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
