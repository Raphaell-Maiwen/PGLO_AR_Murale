﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOffset : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
         GetComponent<Animator>().SetFloat("offset", Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
