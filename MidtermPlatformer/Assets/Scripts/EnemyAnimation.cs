using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    public enum AnimationState
    {
        Walking,
        Idle,
        Alert
    }

    public float animationFPS;
    public Sprite[] walking;
    public Sprite[] idle;
    public Sprite[] alert;

    private Rigidbody2D rb2d;
    private SpriteRenderer sRenderer;
    private EnemyBehavior enemy;

    private float frameTimer = 0;
    private int frameIndex = 0;

    private AnimationState state = AnimationState.Walking;

    private Dictionary<AnimationState, Sprite[]> animationAtlas;

    void Start()
    {

        animationAtlas = new Dictionary<AnimationState, Sprite[]>();
        animationAtlas.Add(AnimationState.Walking, walking);
        animationAtlas.Add(AnimationState.Idle, idle);

        rb2d = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        enemy = GetComponent<EnemyBehavior>();

    }

    void Update()
    {
        AnimationState newState = GetAnimationState();

        if (state != newState)
        {
            TransitionToState(newState);
        }

        frameTimer -= Time.deltaTime;
        Sprite[] anim = animationAtlas[state];
        if (frameTimer <= 0.0f)
        {
            frameTimer = 1 / animationFPS;
            frameIndex %= anim.Length;
            sRenderer.sprite = anim[frameIndex];
            frameIndex++;
        }

        if (rb2d.velocity.x < -0.01f)
        {
            sRenderer.flipX = true;
        }

        if (rb2d.velocity.x > 0.01f)
        {
            sRenderer.flipX = false;
        }
    }

    void TransitionToState(AnimationState newState)
    {
        frameTimer = 0.0f;
        frameIndex = 0;
        state = newState;
    }

    AnimationState GetAnimationState()
    {

        if(Mathf.Abs(rb2d.velocity.x) > 0.0f)
        {
            return AnimationState.Walking;
        }

        return AnimationState.Idle;
        
    }
}
