using System;
using System.Collections;
using UnityEngine;

public class Birdy : MonoBehaviour
{
  public GameObject lookAtPoint;

  public bool isAlive = true;

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

    transform.LookAt(lookAtPoint.transform);
  }

  public void OnFlappingFinish()
  {

    transform.eulerAngles = new Vector3(0, 0, 0);
  }
  private void OnTriggerEnter(Collider other)
  {
    // Drop bird
    if (isAlive)
    {
      Debug.Log("the bird hit " + other.name);
      isAlive = false;

    }

    // Stop pipes and scenery movement
  }
}