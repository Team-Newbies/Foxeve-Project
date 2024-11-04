using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class FallPlataform : MonoBehaviour
{

    public float fallTime;

    private BoxCollider2D boxColl;
    private TargetJoint2D target;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke ("Falling", fallTime);
        }

    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
    void Falling ()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }
}
