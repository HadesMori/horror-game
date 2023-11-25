using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigObjectTransparency : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private float _distance = 3f;
    private Color _translucent = new Color(1f, 1f, 1f, 0.4f);
    private Color _opaque = new Color(1f, 1f, 1f, 1f);

    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        SpriteRenderer[] spriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in spriteRenderer)
        {
            bool atDistance = Vector2.Distance(_playerTransform.position, transform.position) < _distance;
            if (atDistance)
            {
                if (gameObject.transform.position.y < _playerTransform.position.y) 
                    sprite.color = _translucent;
                else
                    sprite.color = _opaque; 
            }
            else 
                sprite.color = _opaque;
        }
    }
}
