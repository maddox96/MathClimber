using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Jump))]
public class CharacterJump : MonoBehaviour
{
    [SerializeField]
    AudioClip jumpClip;
    [SerializeField]
    Transform[] wayPoints;
    Jump _jumpMechanic;
    Animator _animator;

    int solvePosition;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _jumpMechanic = GetComponent<Jump>();
        GameManager.instance.OnGoodAnswer += JumpUp;
        GameManager.instance.OnGoodAnswer += MoveWaypoints;
        Jump.AfterLanding += JumpAnimationSwitcher;
    }

    void JumpUp()
    {
        StartCoroutine(_jumpMechanic.Hop(GetJumpPosition(GameManager.instance.Equality.solvePosition)));
        MusicManager.instance.PlaySound(jumpClip);
        JumpAnimationSwitcher();
    }

    public void JumpAnimationSwitcher()
    {
        _animator.SetBool("isJumping", !_animator.GetBool("isJumping")); 
    }

    Vector2 GetJumpPosition(int solvePosition)
    {
        return wayPoints[solvePosition].transform.position;
    }

    void MoveWaypoints()
    {
        for (int i = 0; i < 3; i++)
            wayPoints[i].transform.position += new Vector3(0.0f, 2.91f, 0.0f);
    }

    void OnDestroy()
    {
        GameManager.instance.OnGoodAnswer -= JumpUp;
        GameManager.instance.OnGoodAnswer -= MoveWaypoints;
        Jump.AfterLanding -= JumpAnimationSwitcher;
    }

}