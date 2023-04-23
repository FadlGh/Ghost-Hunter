using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _playerRb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("s");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _playerRb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
            print("ss");
        }
    }
}
