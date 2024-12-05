using UnityEngine;
using UnityEngine.UI;

public class ManagerButton : MonoBehaviour
{
    public Button toggleBtn;
    public GameObject loginScreen;
    
    void Start()
    {
        toggleBtn.onClick.AddListener(ToggleObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleObject() {
        loginScreen.SetActive(!loginScreen.activeSelf);
    }

}
