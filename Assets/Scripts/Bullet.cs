using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField, Range(1, 5)] private int _damage = 1;
    [SerializeField, Range(0.1f, 10f)] private float _lifeTime = 5;

    public UnityEvent Used;

    public void Init(Vector3 velocity)
    {
        transform.up = velocity.normalized;
        _rigidbody.velocity = velocity;
        StartCoroutine(LifetimeCoroutine());
    }

    private void OnCollisionEnter(Collision collision)
    {
        var target = collision.gameObject.GetComponentInParent<IDamagable>();
        if (target != null)
        {
            target.TakeDamage(1);
        }
        Used.Invoke();
    }

    private IEnumerator LifetimeCoroutine()
    {
        for(float t = 0; t < _lifeTime; t += Time.deltaTime)
            yield return null;
        Used.Invoke();
    }
}