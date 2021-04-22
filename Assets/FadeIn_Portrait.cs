using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn_Portrait : MonoBehaviour
{
    public Texture img;
    public string pictureName;
    public Material mat;
    MeshRenderer mr;

    float a = 0.0f;
    float t = 0.0f;
    public float fadeSpeed = 0.01f;
    public float timeBeforeFadeOut = 5;

    public Vector3 scaleChange;
    
    // Start is called before the first frame update
    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
        mat = mr.material;
        mat.mainTexture = img;

        //Vector3 ratio = new Vector3(-0.01f, -0.01f, -0.01f);
        //scaleChange *= ratio;
        

        if(mat){
            print("wow!");
            //gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            mat.SetColor("_Color", new Color(1,1,1,0));
        } else {
            print("No mat!!!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChange);
        
        t += Time.deltaTime;
        float fSpeed = fadeSpeed * Time.deltaTime;
        
        if (t > timeBeforeFadeOut) { // FADE OUT
            a -= fSpeed;
            if (mat.color.a > 0.0) {
                mat.SetColor("_Color", new Color(1,1,1, a));
            } else {
                gameObject.SetActive(false);
                gameObject.transform.parent.gameObject.SetActive(false);
            } 
    
        } 
        else { // FADE IN
            
            if(mat.color.a < 1.0) {
            a += fSpeed;
            mat.SetColor("_Color", new Color(1,1,1, a));
            }
        }


         
           
    }
}
