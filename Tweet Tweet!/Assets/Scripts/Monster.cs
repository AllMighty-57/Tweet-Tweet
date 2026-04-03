using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Sprite _dead;
    public ParticleSystem _particles;
    private bool HasDied = false;
    public AudioClip[] ambientNoises;
    public AudioClip[] deadNoises;

    private void OnMouseDown()
    { 
        var clip = ambientNoises[Random.Range(0, ambientNoises.Length)];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    IEnumerator Start()
    { 
        while (HasDied == false)
        {  
            var clip = ambientNoises[Random.Range(0, ambientNoises.Length)];
            float delay = Random.Range(5, 30);
            yield return new WaitForSeconds(delay);
            if (HasDied == false)
            {
                GetComponent<AudioSource>().PlayOneShot(clip);
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
        var clip = deadNoises[Random.Range(0, deadNoises.Length)];
        GetComponent<AudioSource>().PlayOneShot(clip);
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
