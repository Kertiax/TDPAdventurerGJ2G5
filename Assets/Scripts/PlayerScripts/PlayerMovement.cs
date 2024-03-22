using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private List<AudioClip> soundSteps;
    private Vector2 moveDirection;
    private bool lookingRight = true;

    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        animator.SetBool("IsMoving", moveDirection.magnitude > 0);

        animator.SetBool("IsPushing", playerCollider.IsTouchingLayers(objectLayer) && moveDirection.magnitude > 0);

        rb2D.velocity = speed * moveDirection;

        TurnCheck(moveDirection.x);
    }

    private void TurnCheck(float xDirection)
    {
        if (xDirection > 0 && !lookingRight)
        {
            Turn();
        }
        else if (xDirection < 0 && lookingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void StopPlayer()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Steps()
    {
        int randomNumber = Random.Range(0,soundSteps.Count);
        SoundManager.Instance.PlaySoundFx(soundSteps[randomNumber]);
    }
}
