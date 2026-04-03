using UnityEngine;

public class Crate : MonoBehaviour
{
    public AudioClip[] _clips;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude  > 5 )
        {
            var clip = _clips[Random.Range(0, _clips.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Too Slow " + collision.relativeVelocity.magnitude);
        }
    }
}
