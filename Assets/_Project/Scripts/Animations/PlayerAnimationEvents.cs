using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerController _pc;

    private void Awake()
    {
        if (_pc == null) _pc = GetComponentInParent<PlayerController>();
    }

    public void DestroygameObject()
    {
        if (_pc == null) return;

        _pc.DestroyGOPlayer();
    }

    public void FootStepSfx()
    {
        _pc.FootStepSound();
    }

}
