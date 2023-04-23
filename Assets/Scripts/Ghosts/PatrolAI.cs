using TMPro;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float stoppingDistance;

    private int currentWaypointIndex = 0;
    private Rigidbody2D rb;
    private bool patrolForward = true;
    private bool isFacingRight = true;
    private Vector2 direction;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = waypoints[0].position;
        direction = (targetPosition - (Vector2)transform.position).normalized;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            targetPosition = waypoints[currentWaypointIndex].position;
            direction = (targetPosition - (Vector2)transform.position).normalized;

            if (patrolForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    patrolForward = false;
                    Flip();
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    patrolForward = true;
                    Flip();
                }
            }
        }
        else
        { 
            rb.velocity = speed * Time.fixedDeltaTime * direction;
            print(rb.velocity.x);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
