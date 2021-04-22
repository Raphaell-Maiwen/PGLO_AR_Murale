using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightScript : MonoBehaviour
{
    public float growthSpeed = 2f;
    private Light thisLight;
    private bool growing = true;

    // Start is called before the first frame update
    void Awake()
    {
        thisLight = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        thisLight.intensity += growthSpeed * Time.deltaTime;
        if (growing && thisLight.intensity > 2f) {
            growthSpeed *= -1;
            growing = false;
        }
        else if (!growing && thisLight.intensity < 1f) {
            growthSpeed *= -1;
            growing = true;
        }
    }
}
