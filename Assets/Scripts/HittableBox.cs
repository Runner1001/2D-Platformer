using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HittableBox : MonoBehaviour 
{
    [SerializeField] private Sprite emptySprite;

    private Animator anim;

    protected virtual bool canUse => true; 

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!canUse) 
            return;

        var player = other.collider.GetComponent<Player>();

        if (player == null) 
            return;

        if (other.contacts[0].normal.y > 0) 
        {
            Use(); 

            PlayAnimation(); 

            if (!canUse)
                GetComponent<SpriteRenderer>().sprite = emptySprite; 
        }
    }

    private void PlayAnimation()
    {
        if (anim != null)
            anim.SetTrigger("Use"); 
    }

    protected abstract void Use(); 
}
