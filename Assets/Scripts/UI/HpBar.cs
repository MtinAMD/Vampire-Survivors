using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
     [SerializeField] private Transform bar;

     public void setState(int current, int max)
     {
          float state = (float)current / max;
          if (state < 0)
               state = 0;
          bar.localScale = new Vector3(state, 1f, 1f);
     }
}
