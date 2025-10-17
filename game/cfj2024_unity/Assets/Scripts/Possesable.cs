using UnityEngine;

// Class that represents an object that can be possessed by the player
public class Possesable : MonoBehaviour
{
    public Sprite possessedSprite;
    public Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to possess the object
    public void Possess()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = possessedSprite;
    }

    // Method to release the object
    public void Release()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = defaultSprite;
    }
}
