using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float stoppingDistance;

    private int currentWaypointIndex = 0;
    private Rigidbody2D rb;
    private bool patrolForward = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 targetPosition = waypoints[currentWaypointIndex].position;

        if (Vector2.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            print("s");
            if (patrolForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    patrolForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    patrolForward = true;
                }
            }
        }
        else
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position);
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            print(Vector2.Distance(transform.position, targetPosition) < stoppingDistance);
        }
    }
}
