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


    [SerializeField] TextMeshProUGUI infoEleve;

    [SerializeField] TextMeshProUGUI infoTitle;

    [SerializeField] TextMeshProUGUI infoDescription;

    [SerializeField] ScrollRect scrollRect;


    // [SerializeField] Image photo;

    [SerializeField] private SpriteRenderer bulleSpriteRenderer;
    [SerializeField] private SpriteRenderer photoSpriteRenderer;
    [SerializeField] private SpriteRenderer petiteBulleSpriteRenderer;
    [SerializeField] private SpriteRenderer titreSpriteRenderer;
    void Awake()
    {
        //if (Application.platform != RuntimePlatform.IPhonePlayer)
        //{
            sceneRoot.localRotation = Quaternion.Euler(90f, 0f, 0f);
            sceneRoot.GetComponent<AlignUp>().enabled = true;
        //}
        // canvas.localRotation = Quaternion.Euler(90f, 0f,0f);
        // canvas.localPosition -= Vector3.down;
    }


    public void SetMonde(Bulle bulle)
    {
        this.bulle = bulle;

        bulleSpriteRenderer.sprite = bulle.SpriteBulle;
        photoSpriteRenderer.sprite = bulle.SpritePhoto;
        petiteBulleSpriteRenderer.sprite = bulle.SpritePetiteBulle;
        titreSpriteRenderer.sprite = bulle.SpriteTitre;


        infoEleve.text = bulle.Eleve;
        infoTitle.text = bulle.Title;
        infoDescription.text = bulle.Description;

        GameManager.Instance.FadePostProcess.color = bulle.BackgroundColor;

        scrollRect.verticalNormalizedPosition = 1f;

        // eleve.text = bulle.Eleve;

        // title.text = bulle.Title;

        // photo.sprite = bulle.Photo;
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

        // GameManager.Instance.FadeIn();
        // GameManager.Instance.ARMaterial.SetFloat("_dimFactor", 1);
        //    GameManager.Instance.ARCameraBackground.enabled = true;

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
        //    GameManager.Instance.ARCameraBackground.enabled = false;
        // GameManager.Instance.ARMaterial.SetFloat("_dimFactor", 0);
        // GameManager.Instance.FadeOut();

        mondeStart.StartFade();
        GameManager.Instance.Lock(this);
    }

}
