using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IPointerDownHandler
{
    public string goTo;
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(goTo, LoadSceneMode.Single);
    }
}
