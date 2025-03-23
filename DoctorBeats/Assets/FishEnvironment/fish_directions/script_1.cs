using UnityEngine;

public class FishMovement : MonoBehaviour
{
    // Setting the boundaries for the fish to swim within the wanted frame
    [SerializeField] private Vector3 minBounds = new Vector3(-10f, -3f, -10f);
    [SerializeField] private Vector3 maxBounds = new Vector3(10f, 3f, 10f);

    //Initialize variables
    public float swim_speed = 1f;
    public float turn_speed = 0.5f;
    public float change_direction_time = 5f; //Every 5 seconds, change the target

    private Vector3 next_position;
    private float timer = 0f;

    //Set methods
    void Start()
    {
        SetNewTargetPosition();
    }

    void Update()
    {
        // Fish moves towards the next position
        transform.position = Vector3.MoveTowards(transform.position, next_position, swim_speed * Time.deltaTime);
        // Rotate accordingly 
        Vector3 direction = (next_position - transform.position).normalized;
        // If the direction is not a zero vector 
        if (direction != Vector3.zero) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turn_speed * Time.deltaTime);
        }

        // Change direction after time limit or if it's close to the target
        timer += Time.deltaTime;
        if (timer >= change_direction_time || Vector3.Distance(transform.position, next_position) < 0.5f)
        {
            SetNewTargetPosition();
            timer = 0f;
        }
    }

    void SetNewTargetPosition()
    {
        next_position = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z)
        );
    }
}
