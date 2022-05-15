using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Reaction : MonoBehaviour {

    private Object[] symbols;
    private int correctNumber = 0; // 0 is default. Actual numbers are 1, 2, or 3.
    private int testIndex = 0;
    private KeyCode[] keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
    };

    [SerializeField] private Image symbolTall, symbolWide;

    private void Start() {
        symbols = Resources.LoadAll("ReactionSymbols", typeof(Sprite));
        DisplayRandomSymbol();
    }

    private void Update() {
        for (int i = 0; i < keyCodes.Length; i++) {
            if (Input.GetKeyDown(keyCodes[i])) {
                if ((i + 1) == correctNumber) {
                    DisplayRandomSymbol();
                } else {
                    // Do something when a symbol guessed is wrong
                }
            }
        }
    }

    // The sprites at index 0, 3, and 5 are belong in the SymbolTall UI image
    private void DisplayRandomSymbol() {
        // Clear old symbols
        symbolTall.gameObject.SetActive(false);
        symbolWide.gameObject.SetActive(false);

        int randomIndex = Random.Range(0, symbols.Length);
        Sprite symbol = (Sprite)symbols[randomIndex];

        if (randomIndex == 0 || randomIndex == 3 || randomIndex == 5) {
            symbolTall.sprite = symbol;
            symbolTall.gameObject.SetActive(true);
        } else {
            symbolWide.sprite = symbol;
            symbolWide.gameObject.SetActive(true);
        }
        
        // Simplify this later rather than brute forcing it
        switch (randomIndex) {
            case 0:
                correctNumber = 1;
                break;
            case 1:
                correctNumber = 1;
                break;
            case 2:
                correctNumber = 2;
                break;
            case 3:
                correctNumber = 2;
                break;
            case 4:
                correctNumber = 3;
                break;
            case 5:
                correctNumber = 3;
                break;
        }
    }

}
