using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    private Rigidbody2D bombRB2D;
    public Rigidbody2D shipRB2D;
    public ParticleSystem explosion_effect;
    void Start()
    {
        shipRB2D = GameObject.Find("Ship Physics").GetComponent<Rigidbody2D>();
        bombRB2D = gameObject.GetComponent<Rigidbody2D>();
        if(gameObject.name == "Bomb_Player(Clone)")
            bombRB2D.velocity = shipRB2D.velocity;
    }
    void Update()
    {
        // Explode bombs and apply explosion force to surrounding objects.
        if(Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(explosion_effect, bombRB2D.position, Quaternion.identity);
            Vector2 explosionPos = gameObject.transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
            foreach (Collider2D hit in colliders)
            {
                Rigidbody2D rb2D = hit.GetComponent<Rigidbody2D>();

                if (rb2D != null)
                    rb2D.AddExplosionForce2D(power, explosionPos, radius, 3.0F);
            }
            Destroy(gameObject);
        }
    }
}
