using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] EnemyBullet _bulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _shootDelay; //seconds
    [SerializeField] float _bulletSpeed;

    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    void Shoot()
    {

        var bullet = Instantiate(_bulletPrefab, _shootPoint.position, transform.rotation).GetComponent<EnemyBullet>();
        bullet.SetSpeed(_bulletSpeed);
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(_shootDelay);
            Shoot();
        }
    }
}
