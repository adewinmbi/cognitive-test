using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Reaction : MonoBehaviour {

    [SerializeField] private GameObject menuScene, testScene, completeScene;
    [SerializeField] private Text completeText;

    private List<float> reactionTimes;
    private List<bool> reactionCorrect;

    private float lastGuessTime;
    private bool isTestComplete;
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
        reactionTimes = new List<float>();
        reactionCorrect = new List<bool>();

        symbols = Resources.LoadAll("ReactionSymbols", typeof(Sprite));
        lastGuessTime = Time.time;
        DisplayRandomSymbol();
    }

    private void Update() {
        if (!isTestComplete) {
            for (int i = 0; i < keyCodes.Length; i++) {
                if (Input.GetKeyDown(keyCodes[i])) {
                    if ((i + 1) == correctNumber) { // Did the user guess correctly?
                        reactionCorrect.Add(true);
                    } else {
                        reactionCorrect.Add(false);
                    }
                    DisplayRandomSymbol();
                    reactionTimes.Add(Time.time - lastGuessTime);
                    lastGuessTime = Time.time;
                    testIndex++;

                    // Check if test is complete after 10 rounds have passed
                    if (testIndex >= 10) {
                        CompleteTest();
                    }
                }
            }
        }
    }

    public void BeginTest() {
        menuScene.SetActive(false);
        testScene.SetActive(true);
    }

    private void CompleteTest() {
        testScene.SetActive(false);
        completeScene.SetActive(true);

        // Display test results
        string results = "";
        if (DataManager.concentrationTimes != null) { // If the concentration test was skipped
            results += DataManager.FloatListToString("Concentration Times", DataManager.concentrationTimes);
        }
        results += DataManager.FloatListToString("Reaction Times", reactionTimes);
        results += DataManager.BoolListToString("Reaction Accuracy", reactionCorrect);
        completeText.text = results;

        isTestComplete = true;
    }

    private IEnumerator LerpColor(Color startColor, Color endColor, float time) {
        float elapsedTime = 0;
        float halfTime = time / 2;

        // Lerp to end color
        while (elapsedTime < halfTime) {
            symbolTall.color = Color.Lerp(startColor, endColor, Mathf.PingPong(elapsedTime / halfTime, 1)); // Lerp both (tall and wide) colors because either could be in use
            symbolWide.color = Color.Lerp(startColor, endColor, Mathf.PingPong(elapsedTime / halfTime, 1));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Lerp back to start color
        elapsedTime = 0;
        while (elapsedTime < halfTime) {
            symbolWide.color = Color.Lerp(endColor, startColor, Mathf.PingPong(elapsedTime / halfTime, 1));
            symbolTall.color = Color.Lerp(endColor, startColor, Mathf.PingPong(elapsedTime / halfTime, 1));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure color reaches start color again
        symbolTall.color = startColor;
        symbolWide.color = startColor;
        yield return null;
    }

    // The sprites at index 0, 3, and 5 are belong in the SymbolTall UI image (because they are slightly taller images)
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

        StartCoroutine(LerpColor(Color.white, Color.grey, 0.1f));

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
