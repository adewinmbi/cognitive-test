using UnityEngine;
using System.Collections.Generic;

public class Reaction : MonoBehaviour {

    // Name, Reaction 1 time, reaction 2 time, reaction 3 time, reaction 4 time, reaction 5 time, concentration 1 time, conecntration 2 time, concentration 3 time, concentratino 4 time, concentration 5 time
    // Brian, 4, 5, 4, 5, 5, 1, 1, 1, 1, 1, 1

    private Object[] symbols;
    
    private void Start() {
        symbols = Resources.LoadAll("ReactionSymbols", typeof(Sprite));
    }

    private void Update() {
        Debug.Log(Time.deltaTime);
    }

}
