using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxesMovement : MonoBehaviour
{   
    [SerializeField] private float _speed;
    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null)
        {
            transform.localEulerAngles += new Vector3(0, 0, _speed * Time.deltaTime);

            transform.RotateAround(transform.parent.position, new Vector3(Random.Range(.4f, .6f),Random.Range(.4f, .6f),Random.Range(.4f, .6f)), _speed * Time.deltaTime );
        }
        else if(transform.parent == null)
        {
            transform.localScale = new Vector3(.5f,.5f,.5f);
            transform.rotation = Quaternion.identity;
        }
    }
}
