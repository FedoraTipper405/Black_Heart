using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Player;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private PlayerController _playerController;
    private Dash _dash;
    private PlayerAttack _attack;
    private void OnEnable()
    {
        if (_playerController == null)
            _playerController = GetComponent<PlayerController>();
        if (_dash == null)
            _dash = GetComponent<Dash>();
        if (_attack == null)
            _attack = GetComponent<PlayerAttack>();
        
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();
            _playerInputs.PlayerActions.Movement.performed +=
                (val) => _playerController.HandleMovement(val.ReadValue<Vector2>());
            _playerInputs.PlayerActions.Jump.performed += (val) => _playerController.HandleJump();
            _playerInputs.PlayerActions.Jump.canceled += (val) => _playerController.CancelJump();
            _playerInputs.PlayerActions.Dash.performed += (val) => _dash.Dashing();
            _playerInputs.PlayerActions.Attack.performed += (val) => _attack.Attack();

        }
        _playerInputs.Enable();
    }
}
