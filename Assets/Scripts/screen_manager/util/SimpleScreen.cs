using UnityEngine;

public class SimpleScreen : MonoBehaviour, ISimpleScreen
{
   public SimpleScreenMananger manager { get; set; }

        public virtual void HideScreen()
        {
            gameObject.SetActive(false);
        }

        public virtual void ShowScreen(object data = null)
        {
            gameObject.SetActive(true);
        }
}
