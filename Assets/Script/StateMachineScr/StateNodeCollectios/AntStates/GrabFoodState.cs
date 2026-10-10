using Assets.Script.FoodRelatedScr;
using Assets.Script.StateMachineScr.Interfaces;
using Assets.Script.StateMachineScr.StatesGrammarHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Script.StateMachineScr.StateNodeCollectios.AntStates
{
    public class GrabFoodState : MonoBehaviour, IStateNode
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AntBase ant;

        public string StateName => this.name;

        public event Action<string> RequestStateChange;
        public event Action Finished;

        public void OnExit()
        {
            Finished?.Invoke();
        }

        public void OnStart()
        {
            if (ant.Target is FoodBase foodTar)
            {
                int take = foodTar.TakeFood(ant.GetAntStruct().CanTakeFood);
                ant.CurFoodCarry = take;
            }

            animator.Play("ANT_ACTION");
        }

        public void OnUpdate()
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

            if (info.normalizedTime >= 1f)
            {
                GoHome();
            }
        }

        private void GoHome()
        {
            ant.Target = ant.GetAntStruct().House;
            RequestStateChange?.Invoke(AntStateNames.GO_TO_TARGET_STATE);
        }
    }
}
