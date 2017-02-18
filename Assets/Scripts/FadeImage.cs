using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour 
{
    public bool fadeOut = true;
    public float fadeTime = 2f;
    public float delay = 1f;
    private float fade;

	void Start () 
    {
        StartCoroutine(FadeOut());

        if(fadeOut)
        {
            fade = 0f;
        }
        else
        {
            fade = 1f;
        }

	}
	
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(delay);
        transform.GetComponent<Image>().CrossFadeAlpha(fade, fadeTime, false);
    }

}
