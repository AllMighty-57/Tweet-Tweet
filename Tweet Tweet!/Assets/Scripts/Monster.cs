using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Sprite _dead;
    public ParticleSystem _particles;
    private bool HasDied = false;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }
    IEnumerator Start()
    { 
        while (HasDied == false)
        { 
            float delay = UnityEngine.Random.Range(5, 30);
            yield return new WaitForSeconds(delay);
            if (HasDied == false)
            { 
                GetComponent<AudioSource>().Play(); 
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (ShouldDie(collision))
        {
            StartCoroutine(PoofAfterDelay());
        }
        
    }

    private bool ShouldDie(Collision2D collision)
    {
        if (HasDied)
            return false;
        if (collision.gameObject.tag == "Bird")
            return true;
        else if (collision.contacts[0].normal.y < -0.5) 
            return true; 
        else
            return false;
    }

    private IEnumerator PoofAfterDelay()
    {
        GetComponent<SpriteRenderer>().sprite = _dead;
        yield return new WaitForSeconds(3); 
        Die();
    }

    void Die()
    {
        _particles.Play(); 
        HasDied = true;
        gameObject.SetActive(false);
    }
}
