using System;
using System.Collections;
using UnityEngine;

public class Birdy : MonoBehaviour
{
  public GameObject lookAtPoint;

  private Animator _animator;

  private const float _gravity = 15f;
  private const float _velocityBoost = 8f;
  private Vector3 _velocity = new Vector3(0, 0, 0);

  void Start()
  {
    _animator = GetComponent<Animator>();
  }

  void Update()
  {
    _velocity.y -= _gravity * Time.deltaTime;

    if (Input.GetKeyDown("space"))
    {
      _velocity.y = _velocityBoost;

      _animator.SetTrigger("Flap");
    }
    transform.Translate(_velocity * Time.deltaTime, Space.World);
  }

  public void OnFlappingStart()
  {
    Debug.Log("gamer time");
    transform.LookAt(lookAtPoint.transform);
  }

  public void OnFlappingFinish()
  {
    Debug.Log("gamer date");
    transform.eulerAngles = new Vector3(0, 0, 0);
  }
}