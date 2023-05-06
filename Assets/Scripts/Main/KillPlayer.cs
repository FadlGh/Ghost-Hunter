using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameEvent _onPlayerDieEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _onPlayerDieEvent.Raise();
        }
    }
}
