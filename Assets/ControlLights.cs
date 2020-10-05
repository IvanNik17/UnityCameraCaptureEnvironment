using UnityEngine;
using System.Collections;

public class ControlLights : MonoBehaviour {

    

    bool switchRoofLight = true;
    public static bool switchStudioLight = true;

    public GameObject[] roofLight;
    float[] roofLightsIntensities;

    public GameObject[] studioLight;
    float[] studioLightsIntensities;

    public float TurnAngle = 18.0f;
    Quaternion qTo;
    public GameObject turntable;

    public GameObject eventCanvas;

    private Quaternion initialAngle;

	void Start () {
        
        roofLightsIntensities = new float[roofLight.Length];
        studioLightsIntensities = new float[studioLight.Length];

        qTo = turntable.transform.rotation;

        initialAngle = turntable.transform.rotation; 
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchLights(switchRoofLight);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchStudioLights(switchStudioLight);

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            eventCanvas.GetComponent<Canvas>().enabled = false;
            ScreenCapture.CaptureScreenshot("Screenshot.png",10);

        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            eventCanvas.GetComponent<Canvas>().enabled = true;
        }

        turntable.transform.rotation = Quaternion.RotateTowards(turntable.transform.rotation, qTo, 18f * Time.deltaTime);
        //Debug.Log(transform.rotation.ToString("0.000000") + " | " + qTo.ToString("0.000000"));
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (turntable.transform.rotation == qTo /*Mathf.Abs(Quaternion.Dot(transform.rotation, qTo)) > 1 - EPS*/)
            {

                qTo = Quaternion.AngleAxis(TurnAngle, Vector3.up) * qTo;
            }
                

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            turntable.transform.rotation = initialAngle;
            qTo = initialAngle;
        }


        changeLightIntensity(Input.GetAxis("Mouse ScrollWheel"));


	}

    void changeLightIntensity(float scrollRot){

        if (scrollRot > 0)
	    {
            foreach (GameObject light in roofLight)
            {
                if (light.GetComponent<Light>().intensity< 1.5f)
                {
                    light.GetComponent<Light>().intensity += 0.1f;
                }
                
            }
	    }
        else if (scrollRot < 0)
	    {
            foreach (GameObject light in roofLight)
            {
                if (light.GetComponent<Light>().intensity > 0)
                {
                    light.GetComponent<Light>().intensity -= 0.1f;
                }

            }
	    }

    }

    


    void switchLights(bool checkState)
    {
        if (checkState)
        {
            switchRoofLight = false;
            int i = 0;
            foreach (GameObject light in roofLight)
            {
                roofLightsIntensities[i] = light.GetComponent<Light>().intensity;
                i++;
                light.GetComponent<Light>().intensity = 0;
            }
        }
        else
        {
            switchRoofLight = true;
            int i = 0;
            foreach (GameObject light in roofLight)
            {
                light.GetComponent<Light>().intensity = roofLightsIntensities[i];
                i++;
            }
        }
    }


    void switchStudioLights(bool checkState)
    {
        if (checkState)
        {
            switchStudioLight = false;
            int i = 0;
            foreach (GameObject light in studioLight)
            {
                studioLightsIntensities[i] = light.GetComponent<Light>().intensity;
                i++;
                light.GetComponent<Light>().intensity = 0;
            }
        }
        else
        {
            switchStudioLight = true;
            int i = 0;
            foreach (GameObject light in studioLight)
            {
                light.GetComponent<Light>().intensity = studioLightsIntensities[i];
                i++;
            }
        }
    }

}
