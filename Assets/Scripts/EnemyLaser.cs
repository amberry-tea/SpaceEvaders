using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 angle;
    private float speed;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        speed = 0.1f;
        angle = new Vector3 (0, -1, 0);
    }

    // Update is called once per frame
    void Update () {
        rb.position += (Vector2) (angle * speed);
    }

    void OnTriggerEnter2D (Collider2D other) {
        print(other.gameObject.name);
        if (other.gameObject.name == "Player") {
            //other.gameObject.SetActive (false);
            Destroy (other.gameObject);
        }
    }

    void OnBecameInvisible () {
        Destroy (gameObject);
    }
}
