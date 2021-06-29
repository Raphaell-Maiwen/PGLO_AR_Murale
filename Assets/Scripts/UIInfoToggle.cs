using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoToggle : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Image image;

    [SerializeField] Sprite open;
    [SerializeField] Sprite close;

    // Start is called before the first frame update
    public void Toggle()
    {
        if (!target.activeSelf)
        {
            image.sprite = close;
        }
        else
        {
            image.sprite = open;
        }

        target.SetActive(!target.activeSelf);
    }
}
