using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] private InputField nameInputField;
    
    public void CheckName() {
        string userName = nameInputField.text;
        Debug.Log(nameInputField.text);

        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName)) {
            DataManager.userName = userName.ToString();
            SceneManager.LoadScene("ConcentrationTest");
        }
    }

}
