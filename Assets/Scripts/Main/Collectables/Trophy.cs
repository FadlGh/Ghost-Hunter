using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] private GameEvent _onPlayerWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onPlayerWin.Raise();
    }
}
