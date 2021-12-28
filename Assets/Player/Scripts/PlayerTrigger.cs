using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("OnDead"))
        {   
            AudioManager.GetInstance().Play("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
