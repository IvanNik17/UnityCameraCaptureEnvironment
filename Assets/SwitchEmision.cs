using UnityEngine;
using System.Collections;

public class SwitchEmision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ControlLights.switchStudioLight)
        {
             Color lightCol = Color.yellow * Mathf.LinearToGammaSpace(5);
             transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", lightCol);
             DynamicGI.SetEmissive(transform.GetComponent<Renderer>(), lightCol);
             //DynamicGI.UpdateMaterials(transform.GetComponent<Renderer>());
             //DynamicGI.UpdateEnvironment();
        }
        else
        {
            Color lightCol = Color.yellow * Mathf.LinearToGammaSpace(0);
            transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", lightCol);
            DynamicGI.SetEmissive(transform.GetComponent<Renderer>(), lightCol);
        }
	}
}
