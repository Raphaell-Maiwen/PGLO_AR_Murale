using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSE : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(wait());
        //  go.transform.localScale = 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        GameObject go = Instantiate<GameObject>(gameObject, transform);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;

        go.transform.SetParent(null);
        go.transform.localScale = Vector3.one;
        go.transform.SetParent(transform);

        go.transform.LookAt(transform.position - transform.up, GameManager.Instance._arWorldUp);
    }
}
