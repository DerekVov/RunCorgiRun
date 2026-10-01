using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Poop : TimedObject
{
        public void Start()
        {
                secondsOnScreen = GameParameters.PoopSecondsOnScreen;
                base.Start();  
        }
        

}
