using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoToggle : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Text text;

    // Start is called before the first frame update
    public void Toggle()
    {
        if (!target.activeSelf)
        {
            text.text = "x";
        }
        else
        {
            text.text = "i";
        }

        target.SetActive(!target.activeSelf);
    }
}
