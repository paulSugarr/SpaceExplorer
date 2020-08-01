using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerShooting _player;
    private bool _isPressed = false;
    private void Start()
    {
        _player = GameManager.Player.GetComponent<PlayerShooting>();
    }
    private void Update()
    {
        if (_isPressed)
        {
            _player.Shoot();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }
}
