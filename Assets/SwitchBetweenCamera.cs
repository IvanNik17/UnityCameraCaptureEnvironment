using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SwitchBetweenCamera : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject eyesCamera;
    public GameObject cameraCamera;

    public static int switchCams = 0;

	// Use this for initialization
	void Start () {
        menuCanvas.SetActive(false);
        cameraCamera.GetComponent<Camera>().enabled = false;
        eyesCamera.GetComponent<Camera>().enabled = true;
        GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (switchCams == 1)
            {
                menuCanvas.SetActive(false);
                cameraCamera.GetComponent<Camera>().enabled = false;
                eyesCamera.GetComponent<Camera>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                GetComponent<FirstPersonController>().enabled = true;
               // GetComponent<FirstPersonController>().GetComponent<MouseLook>().lockCursor = true;
               // GetComponent<FirstPersonController>().InitCamera("EyeCam");
                switchCams = 0;
            }
            else if (switchCams == 0)
            {
                menuCanvas.SetActive(true);
                cameraCamera.GetComponent<Camera>().enabled = true;
                eyesCamera.GetComponent<Camera>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
               // GetComponent<FirstPersonController>().InitCamera("CameraCam");
               // GetComponent<FirstPersonController>().GetComponent<MouseLook>().lockCursor = false;
                GetComponent<FirstPersonController>().enabled = false;

                
                switchCams = 1;

            }
        }

        cameraCamera.transform.rotation = eyesCamera.transform.rotation;
        cameraCamera.transform.position = eyesCamera.transform.position;
	}
}
