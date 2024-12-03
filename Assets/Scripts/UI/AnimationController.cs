using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public new Animation animation;
    void Start()
    {
        animation = this.GetComponent<Animation>();
    }
    
    // Playing idle animation for menu components.
    public void PlayIdle()
    {
        animation.Play(animation.name + "-Idle");
    }

    // Playing window open animation.
    public void OpenWindow()
    {
        animation.Play("Window-In");
    }

    // Playing window close animation.
    public void CloseWindow()
    {
        animation.Play("Window-Out");        
    }
}
