using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Leddets : MonoBehaviour
{

    public GameObject root;
    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

[NaughtyAttributes.Button()]
    void DoIt(){
Transform[] ts = root.GetComponentsInChildren<Transform>();
print(ts.Length);
foreach (var t in ts)
{
    if(t.name.Contains("candy")){
        GameObject go = Instantiate<GameObject>(model);

        go.transform.parent = t;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.transform.localRotation = Quaternion.identity;

        go.transform.parent = t.parent;

        DestroyImmediate(t.gameObject);
    }
}
    }
}