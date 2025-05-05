using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Transform _position1, _position2;
    [SerializeField] float _speed;
    bool _moveToPosition2;

    private void Update()
    {
        if (_moveToPosition2)
        {
            transform.position = Vector3.MoveTowards(transform.position, _position2.position, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _position2.position) < 0.01f)
                _moveToPosition2 = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _position1.position, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _position1.position) < 0.01f)
                _moveToPosition2 = true;
        }
    }
}
