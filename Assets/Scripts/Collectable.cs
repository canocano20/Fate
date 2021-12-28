using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    private bool collected;
    public bool Collected
    {
        get
        {
            return collected;
        }
    }

    private SpriteRenderer _mySpriteRenderer;

    private void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Collect()
    {
        collected = true;
        _mySpriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.GetInstance().Play("Collect");
            Collect();
        }
        
    }
}
