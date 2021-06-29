using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleMove : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    public float duration;
    private Vector3 startPosition;
    bool forth = false;

    void Start() {
        startPosition = this.transform.position;
        StartCoroutine(LerpPosition(positionToMoveTo, duration));
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration) {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration) {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        forth = !forth;
        if(forth) StartCoroutine(LerpPosition(startPosition, duration));
        else StartCoroutine(LerpPosition(positionToMoveTo, duration));
    }
}