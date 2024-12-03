using UnityEngine;

public interface ISimpleScreen
{
    SimpleScreenMananger manager{ get; set; }
    
    void ShowScreen(object data = null);
    void HideScreen();

}
