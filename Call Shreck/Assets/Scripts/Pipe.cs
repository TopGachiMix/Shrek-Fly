using UnityEngine;

public class Pipe : MonoBehaviour
{
   [SerializeField] private float _speed;


    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * _speed * Time.fixedDeltaTime);   
    }

    private void Update()
    {
        Destroy(gameObject , 8f);
    }


}
