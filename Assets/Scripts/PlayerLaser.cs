using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector3 angle;
    private float speed;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        speed = 0.1f;
        angle = new Vector3 (0, 1, 0);
    }

    // Update is called once per frame
    void Update () {
        rb.position += (Vector2) (angle * speed);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag ("Enemy")) {
            other.GetComponent<EnemyController>().Explode();
            //^-- can also use Destroy.other.gameObject, for deleting entirely.
        }
    }

    void OnBecameInvisible () {
        Destroy (gameObject);
    }
}