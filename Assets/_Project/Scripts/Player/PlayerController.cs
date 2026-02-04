using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private Image _bar_lifeBarFillable;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private TextMeshProUGUI _currentCoinstext;

    [Header("Player movement parameters")]
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _smooth = 10f;
    [SerializeField] private float _jumpForce = 5f;

    [Header("Audio Manager")]
    [SerializeField] private AudioManager _audioManager;

    [SerializeField] private PlayerAnimation _playerAnimation;

    [Header("OnCoinPickup Event")]
    [SerializeField] private UnityEvent<int> _onCoinPickup;

    private CapsuleCollider _capsuleCollider;

    private Rigidbody _rb;
    private Mover _mover;
    private Rotator _rotator;

    private float horizontal, vertical = 0f;
    private Vector3 currentDirection = Vector3.zero;

    private Camera _cam;
    private Ray _ray;

    public bool isAlive = true;
    public bool isGrounded = false;
    public bool isJump = false;
    public bool isRunning = false;

    public int _currentCoins = 0;

    // Getter
    public Vector3 GetDirection() => currentDirection;

    private void Awake()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();
        if (_mover == null) _mover = GetComponent<Mover>();
        if (_rotator == null) _rotator = GetComponent<Rotator>();
        if (_audioManager == null) _audioManager = FindAnyObjectByType<AudioManager>();
        if (_playerAnimation == null) _playerAnimation = GetComponentInParent<PlayerAnimation>();

        _capsuleCollider = GetComponent<CapsuleCollider>();
        if (_capsuleCollider == null) Debug.LogError("Non trovo il COLLIDER !!!!!");

        _cam = Camera.main;
    }

    void Update()
    {
        CheckInput();
        CheckRun();
        CheckJump();

    }

    private void FixedUpdate()
    {
        Move();
        Rotation();

        if (isJump) Jump();
    }

    private void CheckInput()
    {
        if (!isAlive) return;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 targetDirection = Vector3.zero;
        targetDirection = _cam.transform.forward * vertical + _cam.transform.right * horizontal;
        targetDirection.y = 0f;

        if (targetDirection.magnitude > 0.01f) targetDirection.Normalize();

        currentDirection = Vector3.Lerp(currentDirection, targetDirection, _smooth * Time.deltaTime);
    }

    private void CheckRun()
    {
        if (!isAlive) return;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    private void CheckJump()
    {
        if (!isAlive) return;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJump = true;
            _playerAnimation.SetBoolParam("isWalking", false);
            _playerAnimation.SetBoolParam("isRunning", false);
        }
    }

    private void Move()
    {
        if (!isAlive) return;

        if (_mover != null)
        {
            if (isRunning)
            {
                _mover.SetSpeed(_speed * 2);
                _mover.SetAndNormalizeInput(currentDirection);
            }
            else
            {
                _mover.SetSpeed(_speed);
                _mover.SetAndNormalizeInput(currentDirection);
            }
        }
    }

    private void Rotation()
    {
        if (!isAlive) return;

        // se non stai davvero muovendo, non ruotare
        if (currentDirection.sqrMagnitude < 0.0004f) return;

        if (_rotator != null) _rotator.SetRotation(currentDirection);
    }

    private void Jump()
    {
        if (!isAlive) return;
        isJump = false;
        if (isRunning) isRunning = false;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void GetCoins(int coinValue)
    {
        _audioManager.PlaySFX("PickupCoin");
        _currentCoins++;
        _onCoinPickup.Invoke(_currentCoins);
    }

    public void PlayerHitByObject()
    {
        _audioManager.PlaySFX("GetDamage");
    }

    public void DestroyGOPlayer()
    {
        Destroy(gameObject);
    }





    public void OnChangeLife(int hp, int maxhp)
    {
        _audioManager.PlaySFX("GetDamage");
        _lifeText.text = hp + "/" + maxhp;
        _bar_lifeBarFillable.fillAmount = (float)hp / maxhp;
    }

    public void OnDefeated()
    {
        isAlive = false;

        _audioManager.PlaySFX("DeathSound");

        if (_capsuleCollider != null) _capsuleCollider.enabled = false;

        if (_rb != null)
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.isKinematic = true;
        }

        _playerAnimation.SetBoolParam("isDying", true);
    }

}
