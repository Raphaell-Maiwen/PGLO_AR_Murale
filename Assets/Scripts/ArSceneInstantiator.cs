using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArSceneInstantiator : MonoBehaviour
{
    [SerializeField] Bulle bulle;

    public Bulle Bulle
    {
        get
        {
            return bulle;
        }
    }

    [SerializeField] MondeStart mondeStart;

    [SerializeField] Transform canvas;

    [SerializeField] Transform sceneRoot;

    [SerializeField] TextMeshProUGUI eleve;

    [SerializeField] TextMeshProUGUI title;

    [SerializeField] Image photo;

    void Awake()
    {
        sceneRoot.localRotation = Quaternion.Euler(90f, 0f, 0f);
        // canvas.localRotation = Quaternion.Euler(90f, 0f,0f);
        // canvas.localPosition -= Vector3.down;
    }


    public void SetMonde(Bulle bulle)
    {
        this.bulle = bulle;

        eleve.text = bulle.Eleve;

        title.text = bulle.Title;

        photo.sprite = bulle.Photo;
    }

    void OnEnable()
    {
        mondeStart.faded += OnFaded;
    }

    void OnDisable()
    {
        mondeStart.faded -= OnFaded;
    }

    void OnFaded()
    {

        Debug.Log("On faded");
        GameObject s = Instantiate<GameObject>(this.bulle.Prefab);

        s.transform.SetParent(sceneRoot);
        s.transform.localPosition = Vector3.zero;
        s.transform.localRotation = Quaternion.identity;

        StartCoroutine(UnlockInN(6f));

        // s.transform.SetParent(null);


        // sceneRoot.transform.Rotate(Vector3.right, -90f, Space.Self);
    }

    IEnumerator UnlockInN(float n)
    {
        yield return new WaitForSeconds(n);
        GameManager.Instance.Unlock(this);
    }

    void Start()
    {
        mondeStart.StartFade();
        GameManager.Instance.Lock(this);
    }

}
