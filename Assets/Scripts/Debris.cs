using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 angle;
    public float speed;
    public int rotationAngle;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        rb.AddForce((angle * speed), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
        //rb.position += (Vector2) (angle * speed);
        //rb.rotation += rotationAngle;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag ("Player")) {
            //other.gameObject.SetActive (false);
            //Destroy (other.gameObject);
        }
    }

    void OnBecameInvisible () {
        Destroy (gameObject);
    }
}
