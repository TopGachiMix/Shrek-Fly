using System.Collections;
using UnityEngine;

public class InstantiatePipe : MonoBehaviour
{
    [SerializeField] private GameObject _pipes;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

       
        IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(2);
                float rand = Random.Range(-1f , 4f);
                Instantiate(_pipes , new Vector3(2 , rand , 0) , Quaternion.identity);
            }
        }
    

}
