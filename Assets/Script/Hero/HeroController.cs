using UnityEngine;

public class HeroController : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private HeroEntity _entity;
    private bool _entityWasTouchingGround;

    [Header("Jump Buffer")]
    [SerializeField] private float _jumpBufferDuration = 0.2f;
    private float _jumpBufferTimer = 0f;

    [Header("Coyote Time")]
    [SerializeField] private float _coyoteTimeDuration = 0.2f;
    [SerializeField] private float _coyoteTimeCountdown = -1f;

    [Header("Debug")]
    [SerializeField] private bool _guiDebug = false;

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
    }

    private void Update()
    {
        _UpdateJumpBuffer();

        _entity.SetMoveDirX(GetInputMoveX());

        if (_EntityHasExitGround())
        {
            _ResetCoyoteTime();
        } else
        {
            _UpdateCoyoteTime();
        }

        if (_entity.IsTouchingGround)
        {
            _entity.jumpLeft = 2;
        }


        if (_GetInputDownJump()) {
            if (_IsCoyoteTimeActive() || _entity.jumpLeft > 0 && !_entity.IsJumpImpulsing) {
                _entity.JumpStart();
                _entity.jumpLeft -= 1;
            } else {
                _ResetJumpBuffer();
            }
        }
        if (IsJumpBufferActive()) {
            if (_IsCoyoteTimeActive() || _entity.jumpLeft > 0 && !_entity.IsJumpImpulsing) {
                _entity.JumpStart();
            }
        }

        if (_entity.IsJumpImpulsing) {
            if (!_GetInputJump() && _entity.IsJumpMinDurationReached) {
                _entity.StopJumpImpulsion();
            }
        }

        if (_GetInputDash()) {
            _entity._ActivateDash();
        }

        _entity._Dash();

        _entityWasTouchingGround = _entity.IsTouchingGround;
    }

    private bool _GetInputDownJump()
    {
        if (_entity.canMove) {
            return Input.GetKeyDown(KeyCode.Space);
        } else {
            return false;
        }
    }
    private bool _GetInputJump()
    {
        if (_entity.canMove) {
            return Input.GetKey(KeyCode.Space);
        } else {
            return false;
        }
    }

    private bool _GetInputDash()
    {
        if (_entity.canMove) {
            return Input.GetKeyDown(KeyCode.E);
        } else {
            return false;
        }
    }

    private float GetInputMoveX()
    {
        float inputMoveX = 0f;
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q)) && _entity.canMove)
        {
            inputMoveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) && _entity.canMove)
        {
            inputMoveX = 1f;
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