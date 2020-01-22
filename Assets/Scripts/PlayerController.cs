using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject playerLaser;

    //private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private Vector3 mouseLast;
    private Vector3 playerStartPos;
    private Vector3 mouseStartPos;
    private Vector3 move;
    private bool dragging;

    public Vector3 force;
    public Vector3 gameObjectSreenPoint;
    public Vector3 mousePreviousLocation;
    public Vector3 mouseCurLocation;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.anyKeyDown) {
            rb.isKinematic = true;
            mouseStartPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
            playerStartPos = rb.position;
        }

        if (Input.anyKey) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
            move = mousePos - mouseStartPos;
            rb.position = playerStartPos + move;
            //rb.velocity = 0;
        }

        if (Input.GetKeyUp ("d")) {
            rb.isKinematic = false;
            //move = 0;
        }

        if (Time.frameCount % 60 == 0) {
            ShootLaser ();
        }
    }

    void OnMouseDrag()
     {
         mouseCurLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectSreenPoint.z);
         force = mouseCurLocation - mousePreviousLocation;
         mousePreviousLocation = mouseCurLocation;
     }

    private void ShootLaser () {
        Instantiate (playerLaser, new Vector3 (rb.position.x, rb.position.y, 0), Quaternion.identity);
    }

    public void explode () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Debris")) {
            rb.AddForce ((force), ForceMode2D.Impulse);
            print(force);
        }
    }
}

/*
        //Code to implement touch screen utilization.
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            rb.position = touch.position;
        }*/