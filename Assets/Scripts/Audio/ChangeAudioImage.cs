using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeAudioImage : MonoBehaviour
{
    [SerializeField] Sprite _musicOn;
    [SerializeField] Sprite _musicOff;

    private Image _currentSprite;

    private void Start()
    {
        _currentSprite = GetComponent<Image>();
    }

    public void ChangeImage()
    {
        if(_currentSprite.sprite == _musicOn)
            _currentSprite.sprite = _musicOff;
        
        else
            _currentSprite.sprite = _musicOn;
        
    }
}
