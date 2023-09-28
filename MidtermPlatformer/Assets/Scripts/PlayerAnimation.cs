using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public enum AnimationState
    {
        IdleGun,
        IdleKnife,
        RunGun,
        RunKnife,
        JumpGun,
        JumpKnife
    }

    public float animationFPS;
    public Sprite[] idleGun;
    public Sprite[] idleKnife;
    public Sprite[] runGun;
    public Sprite[] runKnife;
    public Sprite[] jumpGun;
    public Sprite[] jumpKnife;

    private Rigidbody2D rb2d;
    private Player2D player;
    private SpriteRenderer sRenderer;

    private float frameTimer = 0;
    private int frameIndex = 0;

    private AnimationState state = AnimationState.IdleGun;

    private Dictionary<AnimationState, Sprite[]> animationAtlas;

    private SwitchWeapons weapons;
    void Start()
    {
        animationAtlas = new Dictionary<AnimationState, Sprite[]>();
        animationAtlas.Add(AnimationState.IdleGun, idleGun);
        animationAtlas.Add(AnimationState.IdleKnife, idleKnife);
        animationAtlas.Add(AnimationState.RunGun, runGun);
        animationAtlas.Add(AnimationState.RunKnife, runKnife);
        animationAtlas.Add(AnimationState.JumpGun, jumpGun);
        animationAtlas.Add(AnimationState.JumpKnife, jumpKnife);


        rb2d = GetComponent<Rigidbody2D>();
        sRenderer  = GetComponent<SpriteRenderer>();
        player = GetComponent<Player2D>();

        weapons = GetComponent<SwitchWeapons>();
        
    }

    void Update()
    {
        AnimationState newState = GetAnimationState();

        if(state != newState)
        {
            TransitionToState(newState);
        }

        frameTimer -= Time.deltaTime;
        Sprite[] anim = animationAtlas[state];
        if (frameTimer <= 0.0f) {
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
       // if (!player.grounded) //add jumpKnife later
       // {
       //     return AnimationState.JumpGun;
       // }
        if (Mathf.Abs(rb2d.velocity.x) > 0.1f || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if(weapons.gun == true)
            {
                return AnimationState.RunGun;
            }
            if(weapons.knife == true)
            {
                return AnimationState.RunKnife;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || rb2d.velocity.y > 0.1f)
        {
            if(weapons.gun == true)
            {
                return AnimationState.JumpGun;
            }
            if(weapons.knife == true)
            {
                return AnimationState.JumpKnife;
            }
        }

        if(rb2d.velocity.x <= 0.0f)
        {
            if(weapons.knife == true)
            {
                return AnimationState.IdleKnife;
            }
        }
       return AnimationState.IdleGun;
    }
}
