using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxes : MonoBehaviour
{
    [SerializeField] private GameObject _playerBox;
    [SerializeField] private int _numberOfBoxes;
    [SerializeField] private List<Vector3> _positions = new List<Vector3>();
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private GameEvent _putBox;
    private List<GameObject> _boxes = new List<GameObject>();
    private List<GameObject> _usedBoxes = new List<GameObject>();
    private GameObject _player;
    private bool _startLerping;
    private Vector2 _mousePosition;

    private float _lerpTime;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        for(int i = 0;  i < _numberOfBoxes; i++)
        {
           GameObject go = Instantiate(_playerBox, _player.transform.position + _positions[i], new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1)); 
           go.transform.SetParent(_player.transform); 
           _boxes.Add(go);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !_startLerping)
        {
            if(_boxes.Count != 0)
            {
                AudioManager.GetInstance().Play("PutBox");

                _boxes[0].transform.localEulerAngles = new Vector3(0,0,0);
                _boxes[0].transform.localScale = new Vector3(.5f,.5f,.5f);
                _startLerping = true;
                _lerpTime = 0;
                _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _putBox.Raise();
            }
        }

        if(_startLerping)
        {
            if(_boxes[0] != null)
            {
                PutTheBox(_boxes[0], _mousePosition);
            }
        }
    }
    private void PutTheBox(GameObject box, Vector2 mousePosition)
    {
        if(_lerpTime <= 1f)
        {
            box.transform.position = Vector3.Lerp(box.transform.position, mousePosition, _lerpTime);
            _lerpTime += Time.deltaTime * _lerpSpeed;
        }

        else
        {
            AfterBoxReached(box, mousePosition);
            _startLerping = false;
        }

    }
    private void AfterBoxReached(GameObject box, Vector2 mousePosition)
    {
        _boxes.Remove(box);
        _usedBoxes.Add(box);

        box.transform.parent = null;
        box.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        box.GetComponent<Collider2D>().enabled = true;
    }
}
