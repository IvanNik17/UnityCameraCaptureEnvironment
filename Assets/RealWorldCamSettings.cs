using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;


public class RealWorldCamSettings : MonoBehaviour {


    //standard film size
    public Vector2 sensorSize = new Vector2(35.8f,23.9f);
    public float focalLength = 55;

    float[] apertureSteps = new float[] { 4, 4.5f, 5, 5.6f, 6.3f, 7.1f, 8, 9, 10, 11, 13, 14, 16, 18, 20, 22, 25, 29, 32 };
    int[] shutterSpeedSteps = new int[] {4, 8, 15, 30, 40, 50, 60, 80, 100, 125, 160, 200, 250, 320, 400, 500, 640, 800, 1000, 1250, 1600, 2000, 2500, 3200, 4000 };
    int[] isoSteps = new int[] { 100, 125, 160, 200, 250, 320, 400, 500, 640, 800, 1000, 1250, 1600, 2000, 2500, 3200, 4000, 5000, 6400, 8000, 10000, 12800, 16000, 20000, 25600 };

    private DepthOfField DepthComp;
    private MotionBlur MotionComp;
    private ExposureBrightnessChange ExposureComp;
    private NoiseAndGrain NoiseComp;

    float prevAperture = 0;
    float prevShutter = 0;
    float prevIso = 0;

    float expFromAperture = 0;
    float expFromShutterSpeed = 0;
    float expFromIso = 0;
	// Use this for initialization
	void Start () {


        //Component[] components = GetComponents<Component>();
        //foreach (Component c in components)
        //{
        //    Debug.Log(c.GetType());
        //}

        DepthComp = GetComponent<DepthOfField>();
        MotionComp = GetComponent<MotionBlur>();
        ExposureComp = GetComponent<ExposureBrightnessChange>();
        NoiseComp = GetComponent<NoiseAndGrain>();

        GameObject zoomSlider = GameObject.Find("Zoom");
        GameObject focusSlider = GameObject.Find("Focus");
        GameObject apertureSlider = GameObject.Find("Aperture");
        GameObject shutterSlider = GameObject.Find("ShutterSpeed");
        GameObject isoSlider = GameObject.Find("Iso");

        zoomSlider.GetComponent<Slider>().minValue = 25;
        zoomSlider.GetComponent<Slider>().maxValue = 300;

        focusSlider.GetComponent<Slider>().minValue = 0;
        focusSlider.GetComponent<Slider>().maxValue = 20;

        apertureSlider.GetComponent<Slider>().minValue = 0;
        apertureSlider.GetComponent<Slider>().maxValue = apertureSteps.Length;
        apertureSlider.GetComponent<Slider>().value = 3;

        shutterSlider.GetComponent<Slider>().minValue = 0;
        shutterSlider.GetComponent<Slider>().maxValue = shutterSpeedSteps.Length;
        shutterSlider.GetComponent<Slider>().value = 3;

        isoSlider.GetComponent<Slider>().minValue = 0;
        isoSlider.GetComponent<Slider>().maxValue = isoSteps.Length;
        isoSlider.GetComponent<Slider>().value = 3;

        //ExposureComp.brightnessAmount = Mathf.Max(1.5f, ())
    
	}
	
	// Update is called once per frame
	void Update () {
        //Formula to convert focalLength to field of view - In Unity they use Vertical FOV.
        //So we use the filmHeight to calculate Vertical FOV.
        double fovdub = Mathf.Rad2Deg * 2.0f * Mathf.Atan(sensorSize.y / (2.0f * focalLength));
        float fov = (float)fovdub;

        transform.GetComponent<Camera>().fieldOfView = fov;

        float averageExposure = (expFromAperture + expFromShutterSpeed + expFromIso)/3;



        ExposureComp.brightnessAmount = Mathf.Min(1.5f, (Mathf.Max(0.1f, averageExposure)));
	}

    public void AdjustZoom(float newZoom)
    {
        focalLength = newZoom;

        GameObject.Find("ZoomLabel").GetComponent<Text>().text = focalLength.ToString();
    }

    public void AdjustFocus(float newFocus)
    {
        DepthComp.focalLength = newFocus;
        GameObject.Find("FocusLabel").GetComponent<Text>().text = newFocus.ToString();
    }

    public void AdjustAperture(float newAperture) {
        for (int i = 0; i < apertureSteps.Length; i++)
        {
            if (newAperture == i)
            {
                //Debug.Log(apertureSteps[i]);
                GameObject.Find("ApertureLabel").GetComponent<Text>().text ="F" + apertureSteps[i].ToString();
            }
        }

        if (newAperture < prevAperture && DepthComp.aperture >= 0.2f)
        {
            DepthComp.aperture = 0.8f - newAperture*0.03f;       
        }
        else if (newAperture > prevAperture && DepthComp.aperture <= 0.8f)
        {
            DepthComp.aperture = 0.8f - newAperture * 0.03f;
        }

        if (newAperture < prevAperture && ExposureComp.brightnessAmount >= 0.1f)
        {
            expFromAperture = 1.5f - newAperture * 0.074f;
        }
        else if (newAperture > prevAperture && ExposureComp.brightnessAmount <= 1.5f)
        {
            expFromAperture = 1.5f - newAperture * 0.074f;
        }

        prevAperture = newAperture;
        
    }

    public void AdjustShutterSpeed(float newShutter)
    {
        for (int i = 0; i < shutterSpeedSteps.Length; i++)
        {
            if (newShutter == i)
            {
                //Debug.Log(shutterSpeedSteps[i]);
                GameObject.Find("ShutterLabel").GetComponent<Text>().text ="1/" + shutterSpeedSteps[i].ToString();
            }
        }

        if (newShutter < prevShutter && MotionComp.blurAmount >= 0.1f)
        {
            MotionComp.blurAmount = 0.7f - newShutter * 0.024f;
        }
        else if (newShutter > prevShutter && MotionComp.blurAmount <= 0.7f)
        {
            MotionComp.blurAmount = 0.7f - newShutter * 0.024f;
        }


        if (newShutter < prevShutter && ExposureComp.brightnessAmount >= 0.1f)
        {
            expFromShutterSpeed = 1.5f - newShutter * 0.056f;
        }
        else if (newShutter > prevShutter && ExposureComp.brightnessAmount <= 1.5f)
        {
            expFromShutterSpeed = 1.5f - newShutter * 0.056f;
        }

        prevShutter = newShutter;

    }

    public void AdjustISO(float newIso)
    {
        for (int i = 0; i < isoSteps.Length; i++)
        {
            if (newIso == i)
            {
                //Debug.Log(isoSteps[i]);
                GameObject.Find("IsoLabel").GetComponent<Text>().text = isoSteps[i].ToString();
            }
        }

        if (newIso < prevIso && NoiseComp.intensityMultiplier >= 0.0f)
        {
            NoiseComp.intensityMultiplier = 0.0f + newIso * 0.006f;
        }
        else if (newIso > prevIso && NoiseComp.intensityMultiplier <= 0.15f)
        {
            NoiseComp.intensityMultiplier = 0.0f + newIso * 0.006f;
        }

        if (newIso < prevIso && ExposureComp.brightnessAmount >= 0.1f)
        {
            expFromIso = 0.1f + newIso * 0.056f;
        }
        else if (newIso > prevIso && ExposureComp.brightnessAmount <= 1.5f)
        {
            expFromIso = 0.1f + newIso * 0.056f;
        }

        prevIso = newIso;

    }
}
