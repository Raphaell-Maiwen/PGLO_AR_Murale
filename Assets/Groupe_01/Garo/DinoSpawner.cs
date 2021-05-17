using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{

    Transform[] transforms;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        transforms = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnOne());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnOne()
    {
        while (true)
        {
            GameObject go = Instantiate<GameObject>(prefab);

            go.transform.SetParent(transforms[Random.Range(0, transforms.Length)]);
            go.transform.localPosition = Vector3.zero;

            print("now");

            yield return new WaitForSeconds(Random.Range(0.4f, 1.5f));
        }
    }

}
