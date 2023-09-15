using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVO.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed;

    [Header("Text")]
    public TextMeshProUGUI textInvencible;
    public TextMeshProUGUI textSpeedUp;

    [Header("Power Up")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Space]
    public float speed = 1;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEnd = "EndLine";

    public GameObject endScreen;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private bool invencible;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 8;

    private void Start()
    {
        _startPosition = transform.position;
        invencible = false;
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;  
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible)
            {
                MoveBack(collision.transform);
                GameOver(AnimatorManager.AnimationType.DEAD);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEnd)
        {
            if (!invencible) GameOver();
        }
    }

    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, 0.3f).SetRelative();
    }

    private void GameOver(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }

    #region POWERUPS
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetSpeedUpText(string s)
    {
        textSpeedUp.text = s;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }
        
    public void SetInvencibleText(string s)
    {
        textInvencible.text = s;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animationDuration)
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/
        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
