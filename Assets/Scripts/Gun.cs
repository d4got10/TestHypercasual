using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField, Range(0.1f, 10f)] private float _bulletSpeed = 5;

    public void Shoot(Vector2 direction)
    {
        var bullet = _bulletPool.GetBullet();
        bullet.transform.position = transform.position;

        var velocity = new Vector3(direction.x, 0, direction.y);
        bullet.Init(velocity * _bulletSpeed);
    }
}
