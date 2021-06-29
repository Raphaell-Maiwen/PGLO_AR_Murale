using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    [SerializeField] float raycastDistance = 0.3f;

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
            if (Physics.Raycast(ray, out hit, raycastDistance, layerMask))
            {
                BulleAnchor bulleAnchor = hit.collider.gameObject.GetComponent<BulleAnchor>();
                
                if (bulleAnchor && !GameManager.Instance.IsLocked && GameManager.Instance.CurrentBulle?.Bulle != bulleAnchor.Bulle)
                {
                    bulleAnchor.Spawn();
                }
            }
        }
    }
}
