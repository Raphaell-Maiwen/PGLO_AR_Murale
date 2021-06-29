using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDino : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] sprites;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Camera != null)
        {
            Vector3 toCamera = GameManager.Instance.Camera.transform.position - transform.position;
            //transform.LookAt(transform.position - toCamera, Vector3.Cross(toCamera, -Vector3.right));
            transform.LookAt(transform.position - toCamera, GameManager.Instance.Camera.transform.up);

        }
    }
}
