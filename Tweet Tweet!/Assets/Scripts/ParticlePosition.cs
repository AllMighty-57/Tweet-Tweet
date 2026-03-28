using UnityEngine;
using System.Collections;

public class ParticlePosition : MonoBehaviour
{
    public GameObject monster;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = monster.GetComponent<Rigidbody2D>();   
    }

    private void Update()
    { 
        Vector2 currentMonster = rb.transform.position;
        Vector2 currentParticle = transform.position;

        if (currentParticle != currentMonster)
        {
            transform.position = currentMonster; 
        }
    }
}
