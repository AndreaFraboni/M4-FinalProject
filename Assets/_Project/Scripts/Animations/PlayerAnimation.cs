using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private string _verticalSpeedParamName = "vSpeed";
    [SerializeField] private string _horizontalSpeedParamName = "hSpeed";

    //[SerializeField] private string _isWalkingParam = "isWalking";
    //[SerializeField] private string _isRunningParam = "isRunning";

    private Animator _anim;
    private PlayerController _pc;

    //private bool isWalking = false;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _pc = GetComponentInParent<PlayerController>();
    }

    private void SetVerticalSpeedParam(float diry)
    {
        _anim.SetFloat(_verticalSpeedParamName, diry);
    }

    private void SetHorizontalSpeedParam(float dirx)
    {
        _anim.SetFloat(_horizontalSpeedParamName, dirx);
    }

    private void SetDirectionalSpeedParams(Vector2 direction)
    {
        SetHorizontalSpeedParam(direction.x);
        SetVerticalSpeedParam(direction.y);
    }
    public void SetBoolParam(string stateParam, bool value)
    {
        _anim.SetBool(stateParam, value);
    }

    public void SetTriggerParam(string stateParam, bool value)
    {
        if (value) _anim.SetTrigger(stateParam);
    }
    private void Update()
    {
        Vector3 dir = _pc.GetDirection();
        bool moving = dir.magnitude > 0.01f;

        if (!_pc.isGrounded)
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isRunning", false);
            return;
        }

        if (moving)
        {
            _anim.SetBool("isRunning", _pc.isRunning);
            _anim.SetBool("isWalking", !_pc.isRunning);

            _anim.SetFloat("hSpeed", dir.x);
            _anim.SetFloat("vSpeed", dir.z);
        }
        else
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isRunning", false);
            _anim.SetFloat("hSpeed", 0f);
            _anim.SetFloat("vSpeed", 0f);
        }
    }
}

