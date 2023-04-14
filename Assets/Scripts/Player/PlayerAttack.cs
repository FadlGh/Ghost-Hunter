using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _enemyLayer)
        {
            Destroy(collision.gameObject);
        }
    }
}
