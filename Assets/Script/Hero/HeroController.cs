using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;
    private bool _entityWasTouchingGround;

    [Header("Health")]
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth = 3;
    public Slider slider;

    [Header("Jump Buffer")]
    [SerializeField] private float _jumpBufferDuration = 0.2f;
    private float _jumpBufferTimer = 0f;
    public bool haveJumpNv1 = false;

    [Header("Coyote Time")]
    [SerializeField] private float _coyoteTimeDuration = 0.2f;
    [SerializeField] private float _coyoteTimeCountdown = -1f;

    [Header("Attack")]
    [SerializeField] float timeBetweenAttack;
    private float attackTime;
    public bool CanMove;
    public int damage;
    [SerializeField] Transform checkEnemy;
    public LayerMask whatIsEnemy;
    public float range;

    [Header("Debug")]
    [SerializeField] private bool _guiDebug = false;

    public static HeroController instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnGUI()
    {
        if (!_guiDebug) return;

        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label(gameObject.name);
        GUILayout.Label($"Jump Buffer Timer = {_jumpBufferTimer}");
        GUILayout.Label($"CoyoteTime Countdown = {_coyoteTimeCountdown}");
        GUILayout.EndVertical();
    }

    private void Start()
    {
        _CancelJumpBuffer();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    private void Update()
    {
        slider.value = currentHealth;
        _UpdateJumpBuffer();

        _entity.SetMoveDirX(GetInputMoveX());

        _entity.UpdateAnimationState();

        if (_EntityHasExitGround())
        {
            _ResetCoyoteTime();
        }
        else
        {
            _UpdateCoyoteTime();
        }

        if (_entity.IsTouchingGround)
        {
            _entity.jumpUse = 0;
        }

        if (_GetInputDownJump())
        {
            if (_IsCoyoteTimeActive() || _entity.jumpUse < _entity.maxJumpUse && !_entity.IsJumpImpulsing)
            {
                _entity.jumpUse += 1;
                _entity.JumpStart();
            }
            else
            {
                _ResetJumpBuffer();
            }
        }
        if (IsJumpBufferActive())
        {
            if (_IsCoyoteTimeActive() || _entity.jumpUse < _entity.maxJumpUse && !_entity.IsJumpImpulsing)
            {
                _entity.jumpUse ++;
                _entity.JumpStart();
            }
        }

        if (_entity.IsJumpImpulsing)
        {
            if (!_GetInputJump() && _entity.IsJumpMinDurationReached)
            {
                _entity.StopJumpImpulsion();
            }
        }

        if (_GetInputDash())
        {
            _entity._ActivateDash();
        }

        if (_GetInputDashBas())
        {
            _entity._ActivateDashBas();
        }

        if (currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
            currentHealth = maxHealth;
        }

        Attack();

        _entity._Dash();
        _entity._DashBas();

        _entityWasTouchingGround = _entity.IsTouchingGround;
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && CanMove && _entity.IsTouchingGround)
        {
            if (Time.time >= attackTime)
            {
                _entity._rigidbody.velocity = Vector3.zero;
                _entity.animator.SetTrigger("attack");
                _entity._horizontalSpeed = 0;
                StartCoroutine(Delay());
                IEnumerator Delay()
                {
                    CanMove = false;
                    yield return new WaitForSeconds(1f);
                    _entity.animator.SetTrigger("endAttack");
                    CanMove = true;
                }

                attackTime = Time.time + timeBetweenAttack;
            }
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(checkEnemy.position, 0.5f, whatIsEnemy);
        Vector3 spawnButin = new Vector3(gameObject.transform.position.x + 10, gameObject.transform.position.y, gameObject.transform.position.z);
        Quaternion spawnButinRot = Quaternion.identity;
        foreach (var enemy_ in enemy)
        {
            enemy_.GetComponent<Enemy>().TakeDamage(damage, spawnButin, spawnButinRot);
        }
    }

    

    private bool _GetInputDownJump()
    {
        if (CanMove) {
            return Input.GetKeyDown(KeyCode.Space);
        } else {
            return false;
        }
    }
    private bool _GetInputJump()
    {
        if (CanMove) {
            return Input.GetKey(KeyCode.Space);
        } else {
            return false;
        }
    }

    private bool _GetInputDash()
    {
        if (CanMove) {
            return Input.GetKeyDown(KeyCode.E);
        } else {
            return false;
        }
    }

    private bool _GetInputDashBas()
    {
        if (CanMove)
        {
            return Input.GetKeyDown(KeyCode.C);
        }
        else
        {
            return false;
        }
    }

    private float GetInputMoveX()
    {
        float inputMoveX = 0f;
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q)) && CanMove)
        {
            inputMoveX = -1f;
            checkEnemy.position = new Vector2(_entity.transform.position.x - range, _entity.transform.position.y);
        }
        if (Input.GetKey(KeyCode.D) && CanMove)
        {
            inputMoveX = 1f;
            checkEnemy.position = new Vector2(_entity.transform.position.x + range, _entity.transform.position.y);

        }
        return inputMoveX;
    }

    private void _ResetJumpBuffer()
    {
        _jumpBufferTimer = 0f;
    }

    private bool IsJumpBufferActive()
    {
        return _jumpBufferTimer < _jumpBufferDuration;
    }

    private void _UpdateJumpBuffer()
    {
        if (!IsJumpBufferActive()) return;
        _jumpBufferTimer += Time.deltaTime;
    }

    private void _CancelJumpBuffer()
    {
        _jumpBufferTimer = _jumpBufferDuration;
    }

    private void _UpdateCoyoteTime()
    {
        if (!_IsCoyoteTimeActive()) return;
        _coyoteTimeCountdown -= Time.deltaTime;
    }

    private bool _IsCoyoteTimeActive()
    {
        return _coyoteTimeCountdown > 0f;
    }

    private void _ResetCoyoteTime()
    {
        _coyoteTimeCountdown = _coyoteTimeDuration;
    }

    private bool _EntityHasExitGround()
    {
        return _entityWasTouchingGround && !_entity.IsTouchingGround;
    }

}