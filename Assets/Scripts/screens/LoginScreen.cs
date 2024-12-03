using UnityEngine;
using Solana.Unity.Wallet;
using UnityEngine.UI;
using TMPro;
using Solana.Unity.SDK;

public class LoginScreen : SimpleScreen
{

    [SerializeField]
    private TMP_InputField passwordInputField;

    [SerializeField]
    private TextMeshProUGUI passwordText;

    [SerializeField]
    private Button loginBtn;

    [SerializeField]
    private Button loginBtnWalletAdapter;

    [SerializeField]
    private TextMeshProUGUI messageTxt;


    private void OnEnable()
    {
        passwordInputField.text = string.Empty;

        if (Web3.Wallet != null)
        {
            // manager.ShowScreen(this, "wallet_screen");
            gameObject.SetActive(false);
        }
    }

    public void OpenLogin()
    {
        var loginScreen = GameObject.Find("login_screen");
        Debug.Log(loginScreen);
        loginScreen.SetActive(true);
    }

    private void Start()
    {
        passwordText.text = "";
        passwordInputField.onSubmit.AddListener(delegate { LoginChecker(); });
        loginBtn.onClick.AddListener(LoginChecker);

        loginBtnWalletAdapter.onClick.AddListener(LoginCheckerWalletAdapter);

        if (Application.platform is RuntimePlatform.LinuxEditor or RuntimePlatform.WindowsEditor or RuntimePlatform.OSXEditor)
        {
            loginBtnWalletAdapter.onClick.RemoveListener(LoginCheckerWalletAdapter);
            loginBtnWalletAdapter.onClick.AddListener(() =>
                Debug.LogWarning("Wallet adapter login is not yet supported in the editor"));
        }
        if (messageTxt == null) return;
        messageTxt.gameObject.SetActive(false);

    }

    private async void LoginCheckerWalletAdapter()
    {
        if (Web3.Instance == null) return;
        var account = await Web3.Instance.LoginWalletAdapter();
        messageTxt.text = "";
        CheckAccount(account);
    }

    private async void LoginChecker()
    {
        var password = passwordInputField.text;
        var account = await Web3.Instance.LoginInGameWallet(password);
        CheckAccount(account);
    }

    private void CheckAccount(Account account)
    {
        if (account != null)
        {

            manager.ShowScreen(this, "wallet_screen");
            messageTxt.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            passwordInputField.text = string.Empty;
            messageTxt.gameObject.SetActive(true);
        }
    }

    public void OnClose()
    {
        var wallet = GameObject.Find("wallet");
        wallet.SetActive(false);
    }
}
