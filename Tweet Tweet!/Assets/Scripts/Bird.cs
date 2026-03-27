using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 _startPosition;
    private SpriteRenderer _sprite;

    public float velocity = 750;
    public float _maxDragDistance = 5;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>(); 
        _sprite = GetComponent<SpriteRenderer>();
        _startPosition = rb.position;
        rb.isKinematic = true;
    }

    private void OnMouseDown()
    {
       _sprite.color = Color.red;
    }

    private void OnMouseUp()
    {
        var currentPosition = rb.position;
        var direction = _startPosition - currentPosition; 
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * velocity);

        _sprite.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 playArea = mousePosition;

        float distance = Vector2.Distance(playArea, _startPosition); 
        if(distance > _maxDragDistance)
        {
            Vector2 direction = playArea - _startPosition; 
            direction.Normalize();
            playArea = _startPosition + (direction * _maxDragDistance);
        }
        

        rb.position = playArea;
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    } 
    
    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2);
        rb.position = _startPosition;
        rb.isKinematic = true;
        rb.linearVelocity = Vector2.zero;
    }

}
