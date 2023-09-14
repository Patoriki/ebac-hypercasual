using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVO.Core.Singleton;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed;

    [Header("Text")]
    public TextMeshProUGUI textInvencible;
    public TextMeshProUGUI textSpeedUp;

    [Space]
    public float speed = 1;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEnd = "EndLine";

    public GameObject endScreen;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;

    private bool invencible;

    private void Start()
    {
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
            if (!invencible) GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEnd)
        {
            if (!invencible) GameOver();
        }
    }

    private void GameOver()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
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
    #endregion
}
