using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerSpawn :MonoBehaviour
{
    private PlayerInputManager mango;

    private void Start()
    {
        PlayerInput _playerInput = GetComponent<PlayerInputManager>().JoinPlayer();
        SpawnAtPosition(_playerInput);
        
    }

    private void SpawnAtPosition(PlayerInput _playerInput)
    {
        _playerInput.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
    
}

