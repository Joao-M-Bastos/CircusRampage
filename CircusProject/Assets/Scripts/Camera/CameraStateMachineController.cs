using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachineController : MonoBehaviour
{
    CameraBaseState _currentState;

    CameraBaseState _moveState = new CameraMoveState();
    CameraBaseState _stopState = new CameraStopState();

    CameraScript _cameraScrpt;

    private void Awake()
    {
        _cameraScrpt = GetComponent<CameraScript>();
    }
    private void Start()
    {
        ChangeState(_stopState);        
    }

    

    public void ChangeState(CameraBaseState newState)
    {
        if(_currentState != null)
            _currentState.ExitState(_cameraScrpt, this);

        _currentState = newState;

        _currentState.EnterState(_cameraScrpt, this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ChangeState(_moveState);

        if(_currentState != null)
            _currentState.UpdadeState(_cameraScrpt, this);
    }

    private void FixedUpdate()
    {
        if(_currentState != null)
            _currentState.FixedState(_cameraScrpt, this);
    }
}
