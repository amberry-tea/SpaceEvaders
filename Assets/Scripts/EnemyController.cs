using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyLaser;
    public GameObject enemyDebris;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 120 == 0){
            ShootLaser();
        }
    }

    void ShootLaser(){
        Instantiate(enemyLaser, new Vector3 (rb.position.x, rb.position.y, 0), Quaternion.identity);
    }

    public void Explode(){
        GameObject debrisRight = Instantiate(enemyDebris, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);
        debrisRight.GetComponent<Debris>().speed = 3f;
        debrisRight.GetComponent<Debris>().angle = new Vector2(Random.Range(.2f, .8f), Random.Range(-.2f, -.8f));
        //rb = GetComponent<Rigidbody2D> ();
        //speed = 0.0f;
        //angle = new Vector3 (0, 1, 0);
        Destroy(this.gameObject);
    }
}
