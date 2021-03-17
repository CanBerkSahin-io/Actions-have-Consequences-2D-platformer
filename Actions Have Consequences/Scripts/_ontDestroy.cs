using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
  public GameObject uiObject;
  public static int hazard;


  void Awake()
  {
  hazard = 0;
  DontDestroyOnLoad (uiObject); // dont destroy score text on load.
  }
}
