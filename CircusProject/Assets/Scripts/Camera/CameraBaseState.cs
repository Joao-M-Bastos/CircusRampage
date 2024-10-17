using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface CameraBaseState
{
    public void EnterState(CameraScript cameraScrpt, CameraStateMachineController stateController);

    public void ExitState(CameraScript cameraScrpt, CameraStateMachineController stateController);

    public void UpdadeState(CameraScript cameraScrpt, CameraStateMachineController stateController);

    public void FixedState(CameraScript cameraScrpt, CameraStateMachineController stateController);
}
