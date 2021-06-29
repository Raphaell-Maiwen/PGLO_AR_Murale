using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTop : MonoBehaviour
{

    [SerializeField] ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        scrollRect.verticalNormalizedPosition = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
