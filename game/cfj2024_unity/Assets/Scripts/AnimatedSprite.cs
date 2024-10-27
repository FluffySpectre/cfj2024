using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] frames;
    public float playbackSpeed = 10f;

    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentFrame;

    public void SetFrames(Sprite[] newFrames)
    {
        frames = newFrames;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (frames.Length == 0)
        {
            Debug.LogWarning("No frames assigned to the AnimatedSprite component.");
            enabled = false;
        }
    }

    void Update()
    {
        if (frames.Length == 0) return;
        
        timer += Time.deltaTime;
        if (timer >= 1f / playbackSpeed)
        {
            timer -= 1f / playbackSpeed;
            currentFrame = (currentFrame + 1) % frames.Length;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }
}