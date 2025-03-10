using System;
using UnityEngine;

public class TargetCrashSpear : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear"))
        {
            gameObject.SetActive(false);

        }
    }

}
