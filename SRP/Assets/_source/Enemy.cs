using UnityEngine;
using MVC;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    [SerializeField] private int _damage;
    private PlayerModel _playerModel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _playerLayer) 
            _playerModel.ChangeHealth(_damage);
    }
    public void Constructor(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }
}