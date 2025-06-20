using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _startX;
    [SerializeField] private float _endX;






    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * _speed * Time.fixedDeltaTime);

        if (transform.position.x <= _endX)
        {
            Vector2 pos = new Vector2(_startX , transform.position.y);
            transform.position = pos;
        }
    }
}
