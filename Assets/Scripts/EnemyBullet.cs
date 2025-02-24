using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : DamagerObject
{
    float _speed = 0;

    void Update()
    {
        var movementSpeed = Time.deltaTime * _speed;
        transform.Translate(0, movementSpeed, 0);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
