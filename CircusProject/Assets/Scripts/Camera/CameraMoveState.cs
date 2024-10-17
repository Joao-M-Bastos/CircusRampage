using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveState : CameraBaseState
{
    

    public void EnterState(CameraScript cameraScrpt, CameraStateMachineController stateController)
    {
        
    }

    public void ExitState(CameraScript cameraScrpt, CameraStateMachineController stateController)
    {

    }

    public void UpdadeState(CameraScript cameraScrpt, CameraStateMachineController stateController)
    {

    }

    public void FixedState(CameraScript cameraScrpt, CameraStateMachineController stateController)
    {
        cameraScrpt.MoveCamera(GameManager.Instance.ScreenSpeed);
    }
}
