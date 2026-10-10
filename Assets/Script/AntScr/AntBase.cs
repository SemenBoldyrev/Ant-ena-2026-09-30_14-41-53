using Assets.Script.AntScr;
using Assets.Script.Busses;
using Assets.Script.StateMachineScr.Interfaces;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AntBase: MonoBehaviour
{
    [SerializeField] private MonoBehaviour stateMachineMono;
    private IStateMachine stateMachine;
    public IStateMachine StateMachine => stateMachine;

    private AntStruct structure;

    private MonoBehaviour target;
    public MonoBehaviour Target {  get { return target; } set { ChangeTarget(value); } }
    public event Action<MonoBehaviour> TargetChanged;

    private int curFoodCarry = 0;
    public int CurFoodCarry { get { return curFoodCarry; } set { curFoodCarry = value; } }


    private void Awake()
    {
        stateMachine = stateMachineMono.GetComponent<IStateMachine>();
    }

    public void LoadAntData(AntStruct str)
    {
        structure = str;
        stateMachine.IsActirve = true;
    }

    public AntStruct GetAntStruct()
    {
        return structure;
    }

    public void ChangeTarget(MonoBehaviour obj)
    {
        if (obj == Target) return;
        
        target = obj;
        TargetChanged?.Invoke(obj);
    }
}
