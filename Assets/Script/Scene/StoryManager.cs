using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StoryManager : MonoBehaviour
{
    [SerializeField]private Volume volume;
    [SerializeField]private GameObject Black;

    private Vignette vignette;

    private void Start()
    {
        volume.gameObject.SetActive(false);
        Black.SetActive(false);
    }
    public void Story1()
    {
        StartCoroutine("story1");
    }
    IEnumerator story1()
    {
        volume.gameObject.SetActive(true);

        if (volume.profile.TryGet(out Vignette _vignette))
        {
            vignette = _vignette;
        }

        float inten = 0f;

        for(int i = 0; i < 100; i++)
        {
            inten += 0.01f;
            vignette.intensity.value = inten;

            yield return new WaitForSeconds(0.1f);
        }
        Black.SetActive(true);
        volume.gameObject.SetActive(false);

        Debug.Log("ここでセリフ");
        //セリフが終わったらタップして次のシーンへ
    }
}
