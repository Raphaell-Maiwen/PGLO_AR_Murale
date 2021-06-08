using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.Camera)
        {
            Ray ray = GameManager.Instance.Camera.ScreenPointToRay(new Vector3(GameManager.Instance.Camera.pixelWidth / 2, GameManager.Instance.Camera.pixelHeight / 2, 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f, layerMask))
            {
                BulleAnchor bulleAnchor = hit.collider.gameObject.GetComponent<BulleAnchor>();

                Debug.Log("FOUND ONE!!!!!!!!");
                Debug.Log(bulleAnchor.Bulle.name);

                if (bulleAnchor && !GameManager.Instance.IsLocked && GameManager.Instance.CurrentBulle?.Bulle != bulleAnchor.Bulle)
                {
                    bulleAnchor.Spawn();
                }
            }
        }
    }
}
