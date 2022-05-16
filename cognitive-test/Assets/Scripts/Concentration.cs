using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Concentration : MonoBehaviour {

    [SerializeField] private GameObject menuScene, testScene, completeScene; // Each "scene" is an empty game object used to group UI
    [SerializeField] private Button[] itemButtons;
    [SerializeField] private Image currentImage;
    [SerializeField] private Text currentItemName;

    private List<float> concentrationTimes;
    private float lastTime;
    private int currButtonIndex;
    private Object[] images;
    private string[] itemNames = { // Names of items that need to be found in images
        "Four-Leaf Clover", "Cat", "Panda", "Heart", "Panda"
    };

    private void Start() {

        menuScene.SetActive(true);
        testScene.SetActive(false);
        completeScene.SetActive(false);
        concentrationTimes = new List<float>();
        images = Resources.LoadAll("ConcentrationImages", typeof(Sprite));

        for (int i = 0; i < itemButtons.Length; i++) {
            if (i != itemButtons.Length && i != itemButtons.Length - 1) {
                int temp = i;
                itemButtons[i].onClick.AddListener(() => { ItemFound(temp + 1); } ); // Call ItemFound() with correct index as parameter when each button is pressed
            } else {
                itemButtons[i].onClick.AddListener(FinishConcentrationTest);
            }
            itemButtons[i].gameObject.SetActive(false);
        }

        currButtonIndex = 0;
        itemButtons[currButtonIndex].gameObject.SetActive(true);
    }

    private void FinishConcentrationTest() {
        testScene.SetActive(false);
        completeScene.SetActive(true);
        DataManager.concentrationTimes = concentrationTimes;
        SceneManager.LoadScene("ReactionTest");
    }

    private void ItemFound(int itemIndex) {
        if (itemIndex == 0) { // Occurs during the first call to this method
            itemButtons[itemIndex].gameObject.SetActive(true); // Show first image
        } else {
            itemButtons[itemIndex - 1].gameObject.SetActive(false);
            itemButtons[itemIndex].gameObject.SetActive(true);
        }

        concentrationTimes.Add(Time.time - lastTime);
        lastTime = Time.time;

        currentImage.sprite = (Sprite)images[itemIndex];
        currentItemName.text = itemNames[itemIndex];
    }

    public void EnableTestScene() {
        menuScene.SetActive(false);
        testScene.SetActive(true);
        completeScene.SetActive(false);
        ItemFound(0); // Start
        lastTime = Time.time;
    }

}
