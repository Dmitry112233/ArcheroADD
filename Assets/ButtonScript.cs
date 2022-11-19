using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
