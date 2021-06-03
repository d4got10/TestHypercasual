using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody _hipsRigidbody;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Disable();
    }

    public void Enable()
    {
        _animator.enabled = false;
        _hipsRigidbody.constraints = RigidbodyConstraints.None;
    }

    public void Disable()
    {
        _animator.enabled = true;
        _hipsRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
