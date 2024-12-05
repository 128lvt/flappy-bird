using UnityEngine;
using UnityEngine.UI;

public class WalletHolder : MonoBehaviour
{
    public Button toggleWalletBtn;

    public GameObject wallet;

    void Start()
    {
        wallet.SetActive(false);
        toggleWalletBtn.onClick.AddListener(() => wallet.SetActive(!wallet.activeSelf));
    }

   
}
