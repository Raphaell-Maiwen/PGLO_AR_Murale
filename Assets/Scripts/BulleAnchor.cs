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
        if (GameManager.Instance.CurrentBulle)
        {
            Destroy(GameManager.Instance.CurrentBulle.gameObject);
        }

        ArSceneInstantiator arSceneInstantiator = m_BasePrefab.GetComponent<ArSceneInstantiator>();
        Debug.Log("[BulleAnchor] Bulle is ");
        Debug.Log(bulle);
        arSceneInstantiator.SetMonde(bulle);


        GameObject go = Instantiate<GameObject>(m_BasePrefab, transform);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;


        go.transform.SetParent(null);
        go.transform.localScale = Vector3.one;
        go.transform.SetParent(transform);

        // go.transform.localPosition = Vector3.zero;
        // go.transform.localRotation = Quaternion.identity;

        // go.transform.GetChild(0).position = transform.position;

        // // go.transform.GetChild(0).localRotation = new Vector3(-90f, 0f, 0f)

        // //   Vector3 recorded = transform.up;

        // //         if(recorded == GameManager.Instance._arWorldUp){
        // //             recorded = GameManager.Instance.Camera.transform.position - transform.position;
        // //         }

        // //         Vector3 imageForward = Vector3.ProjectOnPlane(recorded, GameManager.Instance._arWorldUp).normalized;



        // // Vector3 imageForward = Vector3.ProjectOnPlane(-transform.up, GameManager.Instance._arWorldUp).normalized;

        // go.transform.GetChild(0).LookAt(go.transform.GetChild(0).position - transform.up, GameManager.Instance._arWorldUp);
    }
}
