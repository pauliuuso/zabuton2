using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GotoStage : MonoBehaviour, IPointerDownHandler
{
    public string stageName;
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(stageName, LoadSceneMode.Single);
    }
}
