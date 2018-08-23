using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject explosion;
    public GameObject explosionTwo;
    private Animator camAnim;

    private void Update()
    {   
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the boss some damage + spawn particle effects + screen shake
        if (other.CompareTag("Boss")) {
            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
            camAnim.SetTrigger("shake");
            other.GetComponent<Boss>().health -= damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(explosionTwo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
