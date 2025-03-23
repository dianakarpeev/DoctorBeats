using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]  // Corrected Attribute
    private Vector3 minBounds = new Vector3(-10f, -1f, -10f);
    [SerializeField]  // Corrected Attribute
    private Vector3 maxBounds = new Vector3(10f, 3f, 10f);
    public float swimSpeed = 5f;
    public float wiggleSpeed = 0.5f;
    public float wiggleAmount = 0.1f;
    public float turnSpeed = 0.5f;  
    public float changeDirectionInterval = 10f; 

    private float timer = 0f;
    private Vector3 targetPosition;
    private Vector3 direction;
    private float wiggle;

    private float verticalMovementSpeed = 0.2f;
    private float verticalMovementRange = 1f;  

    void Start()
    {
        SetNewTargetPosition();
    }

    void Update()
    {
        float verticalMovement = Mathf.Sin(Time.time * verticalMovementSpeed) * verticalMovementRange;
        wiggle = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition + new Vector3(0, wiggle + verticalMovement, 0), Time.deltaTime * swimSpeed);

        timer += Time.deltaTime;

        if (timer >= changeDirectionInterval || Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            SetNewTargetPosition();
            timer = 0f; 
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
    }

    void SetNewTargetPosition()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        targetPosition = new Vector3(randomX, randomY, randomZ);
        direction = (targetPosition - transform.position).normalized;
    }
}
