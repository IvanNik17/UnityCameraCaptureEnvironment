using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class EnvironmentMenuOptions : MonoBehaviour {

    public GameObject menuEnvironment;

    public GameObject greenScreen;
    public GameObject greenScreenSheet;
    bool showEnvMenu = false;

    public Dropdown materialsDrop;
    public Material[] objectMaterials;

    Material initialMaterial;

    // Use this for initialization
    void Start () {
        menuEnvironment.SetActive(false);

        materialsDrop.options.Clear();

        initialMaterial = getScannedItemMaterial();

        materialsDrop.options.Add(new Dropdown.OptionData() { text = "Default" });
        foreach (Material matCurr in objectMaterials)
        {
            materialsDrop.options.Add(new Dropdown.OptionData() { text = matCurr.name });
        }

        materialsDrop.value = 1;
        materialsDrop.value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showEnvMenu = !showEnvMenu;
        }

        if (showEnvMenu)
        {
            menuEnvironment.SetActive(true);
            GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            menuEnvironment.SetActive(false);

            if (SwitchBetweenCamera.switchCams != 1)
            {
                GetComponent<FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }

        if (greenScreen.activeInHierarchy && showEnvMenu)
        {
            GameObject.Find("ScreenSlider").GetComponent<Slider>().interactable = true;
        }
        else if (!greenScreen.activeInHierarchy && showEnvMenu)
        {
            GameObject.Find("ScreenSlider").GetComponent<Slider>().interactable = true;
        }
    }

    public void ShowHideGreenScreen()
    {
        print("HEREEE");
        if (greenScreen.activeInHierarchy)
        {
            greenScreen.SetActive(false);
        }
        else
        {
            greenScreen.SetActive(true);
        }
        
    }


    public void ChangeGreenScreenColor(float colorValue)
    {
        switch ((int)colorValue)
        {
            case 0:
                greenScreenSheet.transform.GetComponent<Renderer>().material.color = Color.white; break;
            case 1:
                greenScreenSheet.transform.GetComponent<Renderer>().material.color = Color.green; break;
            case 2:
                greenScreenSheet.transform.GetComponent<Renderer>().material.color = Color.blue; break;
            case 3:
                greenScreenSheet.transform.GetComponent<Renderer>().material.color = Color.red; break;
            case 4:
                greenScreenSheet.transform.GetComponent<Renderer>().material.color = Color.yellow; break;
            case 5:
                greenScreenSheet.transform.GetComponent<Renderer>().material.color = Color.black; break;
            default:
                break;
        }
    }


    public void changeObjectMaterial()
    {
        print(materialsDrop.value);
        GameObject scannedObject = GameObject.FindGameObjectWithTag("ScanedItem");

        if (materialsDrop.value != 0)
        {

            scannedObject.transform.GetComponent<Renderer>().material = objectMaterials[materialsDrop.value-1];
        }
        else
        {
            scannedObject.transform.GetComponent<Renderer>().material = initialMaterial;
        }
        
    }

    Material getScannedItemMaterial()
    {
        GameObject scannedObject = GameObject.FindGameObjectWithTag("ScanedItem");
        Material scannedMat = scannedObject.transform.GetComponent<Renderer>().material;
        return scannedMat;
    }

    }
