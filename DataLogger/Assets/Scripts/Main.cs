using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Logger.Create(true);
    }

    public void OnButtonClick()
    {
        Logger.Log("Stuff!!");
    }
}
