using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleAnchor : MonoBehaviour
{
    [SerializeField] Bulle bulle;
    [SerializeField] GameObject m_BasePrefab;

    public Bulle Bulle
    {
        get
        {
            return bulle;
        }
    }

    public void SetMonde(Bulle bulle)
    {
        this.bulle = bulle;
    }

    public void Spawn()
    {
        if(GameManager.Instance.CurrentBulle){
            Destroy(GameManager.Instance.CurrentBulle.gameObject);
        }
        
        ArSceneInstantiator arSceneInstantiator = m_BasePrefab.GetComponent<ArSceneInstantiator>();
        Debug.Log("Bulle is ");
        Debug.Log(bulle);
        arSceneInstantiator.SetMonde(bulle);


        GameObject go = Instantiate<GameObject>(m_BasePrefab, transform);
        go.transform.SetParent(null);
        go.transform.localScale = Vector3.one;
        go.transform.SetParent(transform);

        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;

        go.transform.GetChild(0).position = transform.position;

        Vector3 imageForward = Vector3.ProjectOnPlane(-transform.up, GameManager.Instance._arWorldUp).normalized;

        go.transform.GetChild(0).LookAt(go.transform.GetChild(0).position + imageForward, GameManager.Instance._arWorldUp);
    }
}
