using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerToStop : MonoBehaviour
{
    [SerializeField] private Jail.MoveGuard _guardScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _guardScript.NotBehindWall == true)
        {
            _guardScript.StopMove();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _guardScript.NotBehindWall == true)
        {
            _guardScript.StartMove();
        }
    }
}
