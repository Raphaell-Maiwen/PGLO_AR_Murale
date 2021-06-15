using UnityEngine;
using System.Collections;


public class NewPeopleMove : MonoBehaviour {

    public Transform[] points;
    Vector3 currentPoint;
    private int destPoint = 0;

    void Start() {
        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        currentPoint = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update() {
        if (Vector3.Distance(this.transform.position, currentPoint) < 0.5f)
            GotoNextPoint();
    }
}