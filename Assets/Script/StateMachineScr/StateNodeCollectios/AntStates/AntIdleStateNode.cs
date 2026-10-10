using Assets.Script.Busses;
using Assets.Script.StateMachineScr.Interfaces;
using Assets.Script.StateMachineScr.StatesGrammarHelper;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AntIdleStateNode : MonoBehaviour, IStateNode
{
    [SerializeField] private Animator animator;
    [SerializeField] private AntBase ant;

    public string StateName => this.name;

    public event Action<string> RequestStateChange;
    public event Action Finished;

    public void OnExit()
    {
        ant.TargetChanged -= OnTargetChange;

        Finished?.Invoke();
    }

    public void OnStart()
    {
        animator.SetBool("isWalking", false);

        ant.TargetChanged += OnTargetChange;

        if (ant.Target == ant.GetAntStruct().House && ant.CurFoodCarry > 0)
        {
            GiveAllFood();
        }
    }

    private void GiveAllFood()
    {
        SignalBus.GiveFoodEmit(ant.CurFoodCarry);
        ant.CurFoodCarry = 0;
    }

    private void OnTargetChange(MonoBehaviour behaviour)
    {
        Debug.Log("CHANGE ME MOTHER");
        RequestStateChange?.Invoke(AntStateNames.GO_TO_TARGET_STATE);
    }

    public void OnUpdate()
    {
        //
    }
}
