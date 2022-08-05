using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public static Player Instance;
  public GameObject stash;
  public bool isInBossFight = false;
  
  private void Awake()
  {
    Instance = this;
  }
}
