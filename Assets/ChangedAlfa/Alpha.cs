using UnityEngine;
using System.Collections;

public class Alpha : MonoBehaviour
{

    [SerializeField]private GameObject _gameObject;

    private Color _colorFullAlpha = new Color(1, 1, 1, 1);
    private Color _colorZeroAlpha = new Color(1, 1, 1, 0);
    private float Speed = 1;
    private Renderer _renderer;
    private MaterialPropertyBlock _materialProperty;


    void Start()
    {
        _renderer = transform.GetComponent<Renderer>();
        _materialProperty = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameObject.activeSelf)
        {
            _renderer.GetPropertyBlock(_materialProperty);
            _materialProperty.SetColor("_Color", Color.Lerp(_colorFullAlpha, _colorZeroAlpha, Time.time * Speed / 5f));
            _renderer.SetPropertyBlock(_materialProperty);
        }
    }
}
