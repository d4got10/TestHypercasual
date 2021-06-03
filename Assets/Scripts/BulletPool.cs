using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    private Queue<Bullet> _bullets;

    private void Awake()
    {
        _bullets = new Queue<Bullet>();
    }

    public Bullet GetBullet()
    {
        if(_bullets.Count > 0)
        {
            return GetBulletFromQueue();
        }
        else
        {
            return CreateNewBullet();
        }
    }

    private Bullet GetBulletFromQueue()
    {
        var bullet = _bullets.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.transform.parent = null;
        return bullet;
    }

    private Bullet CreateNewBullet()
    {
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity, null);
        bullet.Used.AddListener(() => OnBulletUsed(bullet));
        return bullet;
    }

    private void OnBulletUsed(Bullet bullet)
    {
        _bullets.Enqueue(bullet);
        bullet.transform.parent = transform;
        bullet.gameObject.SetActive(false);
    }
}
