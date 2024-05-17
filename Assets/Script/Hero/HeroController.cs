using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;
    private bool _entityWasTouchingGround;

    [Header("Health")]
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth;


    [Header("Jump Buffer")]
    [SerializeField] private float _jumpBufferDuration = 0.2f;
    private float _jumpBufferTimer = 0f;

    [Header("Coyote Time")]
    [SerializeField] private float _coyoteTimeDuration = 0.2f;
    [SerializeField] private float _coyoteTimeCountdown = -1f;

    [Header("Attack")]
    [SerializeField] float timeBetweenAttack;
    private float attackTime;
    public bool CanMove;
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
    }

    private void Update()
    {
        _UpdateJumpBuffer();

        _entity.SetMoveDirX(GetInputMoveX());

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
            _entity.jumpLeft = 2;
        }


        if (_GetInputDownJump())
        {
            if (_IsCoyoteTimeActive() || _entity.jumpLeft > 0 && !_entity.IsJumpImpulsing)
            {
                _entity.JumpStart();
                _entity.jumpLeft -= 1;
            }
            else
            {
                _ResetJumpBuffer();
            }
        }
        if (IsJumpBufferActive())
        {
            if (_IsCoyoteTimeActive() || _entity.jumpLeft > 0 && !_entity.IsJumpImpulsing)
            {
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

        if (currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
            currentHealth = maxHealth;
        }

        Attack();

        _entity._Dash();

        _entityWasTouchingGround = _entity.IsTouchingGround;
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= attackTime)
            {
                _entity._rigidbody.velocity = Vector3.zero;
                Debug.Log("debut datk");
                //_entity.animator.SetTrigger("attack");
                StartCoroutine(Delay());
                IEnumerator Delay()
                {
                    CanMove = false;
                    yield return new WaitForSeconds(.5f);
                    Debug.Log("atk");
                    CanMove = true;
                }

                attackTime = Time.time + timeBetweenAttack;
            }
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(checkEnemy.position, 0.5f, whatIsEnemy);
        foreach (var enemy_ in enemy)
        {
            //degat a l'enemy;
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