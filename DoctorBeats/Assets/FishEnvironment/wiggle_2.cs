using UnityEngine;

public class FishWiggle1 : MonoBehaviour
{
    public float wiggleSpeed = 0.3f;   // Lower value for slower wiggle
    public float wiggleAmount = 0.1f;  // Small amount for gentle wiggle
    private float initalY;

    private void Start()
    {
        initalY = transform.position.y;
    }

    void Update()
    {
        // Move fish gently up and down with a sine wave
        float wiggle = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount;
        transform.position = new Vector3(transform.position.x, initalY+wiggle, transform.position.z);
    }
}


