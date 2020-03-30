using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// From https://www.youtube.com/watch?v=zCq0Jt6m8BQ
public class PlayVideo : MonoBehaviour
{
    public GameObject staticBackground;
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(PlayBackGroundVideo());
    }

    IEnumerator PlayBackGroundVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;

            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();

        staticBackground.gameObject.SetActive(false);
    }


}
