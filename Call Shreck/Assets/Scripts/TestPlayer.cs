using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector2 _move;
    private Rigidbody2D _rigidBody2D;


    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _move.x = Input.GetAxis("Horizontal");
        _rigidBody2D.MovePosition(_rigidBody2D.position + _move * _speed * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Test")
        {
            Debug.Log("Game Over");
        }
    }





}
