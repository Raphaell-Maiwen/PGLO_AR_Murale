using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSpeed : MonoBehaviour
{
    
    Animator anim;
    AnimatorControllerParameter start;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.speed = Random.Range(0.6f, 1);
        start = anim.parameters[0];
        start.defaultFloat = Random.Range(0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
