using Assets.Script.AntHouseScr;
using Assets.Script.Busses;
using Assets.Script.FoodRelatedScr;
using Assets.Script.StateMachineScr.Interfaces;
using Assets.Script.StateMachineScr.StatesGrammarHelper;
using Assets.Script.StupidMathScr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Script.StateMachineScr.StateNodeCollectios.AntStates
{
    public class GoToTargetState: MonoBehaviour, IStateNode
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AntBase ant;
        [SerializeField] private Rigidbody2D body;

        [Header("Options")]
        [SerializeField] float tresholdToTarget = 0.5f;

        private MonoBehaviour curTarget;

        public string StateName => this.name;

        public event Action<string> RequestStateChange;
        public event Action Finished;

        public void OnExit()
        {
            Finished?.Invoke();
        }

        public void OnStart()
        {
            animator.SetBool("isWalking", true);
            curTarget = ant.Target;
        }

        public void OnUpdate() // need to remove ant golf
        {
            if (OnTarget()) // checks every frame, i dont like that
            {
                body.linearVelocity = Vector2.zero;
                
                switch (curTarget)
                {
                    case FoodBase:
                        RequestStateChange?.Invoke(AntStateNames.FOOD_TAKE);
                        break;

                    case AntHouse:
                        RequestStateChange?.Invoke(AntStateNames.IDLE_STATE);
                        break;

                    default:
                        RequestStateChange?.Invoke(AntStateNames.IDLE_STATE);
                        break;
                }
                return;
            }

            Vector3 normalVec = SharedBus.StupidMath.VectorTo(body.position, curTarget.transform.position).normalized;
            //Vector3 dirSped = normalVec * ant.GetAntStruct().Speed * Time.deltaTime;
            Vector3 dirSped = normalVec * ant.GetAntStruct().Speed; // idk why its so slow with deltatime, will leave as is for now
            body.linearVelocity = dirSped;
            body.rotation = SharedBus.StupidMath.NormalVectorAngle(normalVec);
        }

        private bool OnTarget()
        {
            if (curTarget == null) return true;
            float distance = Vector3.Distance(body.position, curTarget.transform.position);
            //Debug.Log($"{distance} === {tresholdToTarget}");
            if (distance <= tresholdToTarget) return true;
            return false;
        }
    }
}
