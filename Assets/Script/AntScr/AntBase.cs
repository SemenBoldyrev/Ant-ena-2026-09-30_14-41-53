using Assets.Script.Busses;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AntBase: MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float tresholdDistanceToTarget = 0.1f;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator animator;

    private Vector3 target;
    public Vector3 Target => target;

    private bool isWalking { set {
            animator.SetBool("isWalking", value);
        } }

    private void Update()
    {
        target = SharedBus.RelativeMousePos.GetRalativeMousePosition();
        if (Target != null && !OnTarget())
        {
            Move();
            //Rotate(SharedBus.StupidMath.AngleTo(body.position, target));
        }
        else Move(false);
    }

    private void Move(bool move = true) //Body is moving only, other components staying in place, so i can controll what to move 
    {
        if (!move) // do a check of speed, so it wont set value every time
        {
            body.linearVelocity = Vector3.zero;
            isWalking = false;
            return;
        }
        Vector2 dir = SharedBus.StupidMath.VectorTo(body.transform.position, Target).normalized * speed; ;

        //body.SetRotation(SharedBus.StupidMath.AngleTo(body.transform.position, target));
        body.linearVelocity = dir;
        Rotate(SharedBus.StupidMath.NormalVectorAngle(dir)); // Rotation is based on facing direction
        isWalking = true;
        //Debug.Log($"{body.position} ==== {Target}");
        //this.transform.position = SharedBus.RelativeMousePos.GetRalativeMousePosition();
    }

    private void Rotate(float rotation)
    {
        Debug.Log(rotation);
        body.rotation = rotation;
    }

    private bool OnTarget()
    {
        //Debug.Log(Vector3.Distance(body.position, Target));
        if (Vector3.Distance(body.position, Target) <= tresholdDistanceToTarget) return true;
        return false;
    }
}
