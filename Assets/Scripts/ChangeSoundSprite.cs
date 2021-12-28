using UnityEngine;
using UnityEngine.UI;

public class ChangeSoundSprite : MonoBehaviour
{
    public Sprite musicOn;
    public Sprite musicOff;
    private Image _myImage;
    private void Start()
    {
        _myImage = GetComponent<Image>();
    }
    public void ChangeSprite()
    {
        if(AudioManager.GetInstance().soundOn)
        {
            _myImage.sprite = musicOn;
        }

        else
        {
            _myImage.sprite = musicOff;
        }
    }
}