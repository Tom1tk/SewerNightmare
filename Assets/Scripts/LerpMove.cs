using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 3.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private float fractionOfJourney;

    private bool movingForward;

    void lerpMoving(Transform start, Transform end)
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(start.position, end.position, fractionOfJourney);


        if (fractionOfJourney >= 1.0f)
        {
            movingForward = !movingForward;
            startTime = Time.time;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        movingForward = true;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(fractionOfJourney);

        if(movingForward == true)
        {
            lerpMoving(startMarker, endMarker);
        }
        else
        {
            lerpMoving(endMarker, startMarker);
        }
        
    }
}
