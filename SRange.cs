using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRange : MonoBehaviour
{
    private SEnemyController parent;

    private void Start()
    {
        parent = GetComponentInParent<SEnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Player")
        {
            parent.Target = collison.transform;
        }
    }
}
