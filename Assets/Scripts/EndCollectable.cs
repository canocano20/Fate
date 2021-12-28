using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EndCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] private List<GameObject> _collectables;
    private SpriteRenderer _mySpriteRenderer;
    private void Start()
    {
        _collectables = new List<GameObject>(GameObject.FindGameObjectsWithTag("Collectable"));
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            
            Debug.Log(AllCollected());
        }
    }
    public void Collect()
    {
        if(AllCollected())
        {
            _mySpriteRenderer.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private bool AllCollected()
    {
        foreach(GameObject go in _collectables)
        {
            if(go.GetComponent<Collectable>().Collected == false)
            {
                return false;
            }
        }

        return true;
    }
}
