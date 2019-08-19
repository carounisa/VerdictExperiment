using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    UIData[] _uiArray;
    [SerializeField]
    GameObject _dot;
    [SerializeField]
    GameObject _panel;

    //Panel tracking
    int _currPanel;

    //Main panel
    GameObject _mainPanel;
    Image _mainSprite;
    TextMeshProUGUI _mainText;

    //Back Panel
    GameObject _backPanel;
    Image _backSprite;
    TextMeshProUGUI _backText;

    // Start is called before the first frame update
    void Start()
    {
        _currPanel = 0;

        //Initialize our main panel with data
        _mainPanel = Instantiate(_panel, transform);
        _mainSprite = _mainPanel.GetComponentInChildren<Image>();
        _mainText = _mainPanel.GetComponentInChildren<TextMeshProUGUI>();

        _mainSprite.sprite = _uiArray[_currPanel].image;
        _mainText.text = _uiArray[_currPanel].header;
        
    }

    // Update is called once per frame
    void Update()
    {
        _mainSprite.sprite = _uiArray[_currPanel].image;
        _mainText.text = _uiArray[_currPanel].header;


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (_mainText.text.Equals("Eye Witness Statement"))
            {
                GetComponent<AudioSource>().Play();
            }
            // _backSprite.sprite = _uiArray[_currPanel].image;
            //  _backText.text = _uiArray[_currPanel].header;
            if (_currPanel < _uiArray.Length - 1)
                _currPanel++;




        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _currPanel != 0)
        {
            _currPanel--;
            //_backSprite.sprite = _uiArray[_currPanel].image;
            //_backText.text = _uiArray[_currPanel].header;
        }
    }
}
