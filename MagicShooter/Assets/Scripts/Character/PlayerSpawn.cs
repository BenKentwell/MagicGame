using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerSpawn :MonoBehaviour
{

    private void Start()
    {
        GetComponent<PlayerInputManager>().onPlayerJoined += SpawnAtPosition;
    }

    private void SpawnAtPosition(PlayerInput _playerInput)
    {
        _playerInput.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
    
}

