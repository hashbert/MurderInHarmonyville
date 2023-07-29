using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBehavior : StateMachineBehaviour
{
    private float _timeToStayWalking;
    private float _minTimeToStayWalking = 3;
    private float _maxTimeToStayWalking = 5;
    NavMeshAgent navMeshAgent;
    [SerializeField] private RandomPointOnNavMesh _randomPointOnNavMesh;
    private Transform _thisTransform;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _thisTransform = animator.gameObject.GetComponent<Transform>();
        _timeToStayWalking = Random.Range(_minTimeToStayWalking, _maxTimeToStayWalking);
        navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        _randomPointOnNavMesh = FindObjectOfType<RandomPointOnNavMesh>();
        Vector3 destination = _randomPointOnNavMesh.GetRandomPointOnNavMesh();
        TurnTowards(destination);
        navMeshAgent.destination = destination;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeToStayWalking -= Time.deltaTime;
        if (_timeToStayWalking < 0 || !navMeshAgent.hasPath)
        {
            animator.SetTrigger("Think");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Walk");
        navMeshAgent.ResetPath();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    private void TurnTowards(Vector3 location)
    {
        Vector3 turnTo = location - _thisTransform.position;
        float _targetRotationDegrees = Mathf.Atan2(turnTo.x, turnTo.z) * Mathf.Rad2Deg;
        LeanTween.rotateY(_thisTransform.gameObject, _targetRotationDegrees, 0.5f);
    }
}
