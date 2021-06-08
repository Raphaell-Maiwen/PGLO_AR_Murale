using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTutorial : MonoBehaviour
{

    bool hideRequested = false;
    
    public void Hide()
    {
        hideRequested = true;
    }

    void Update(){
        if(hideRequested && Time.realtimeSinceStartup >= 5f){
            gameObject.SetActive(false);
        }
    }
}
