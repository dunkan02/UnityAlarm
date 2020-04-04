using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystemHouse : MonoBehaviour
{
    [SerializeField] private float _maxLevelSound = 1f;
    private Coroutine _coroutineSoundVolumeUp;
    private Coroutine _coroutineSoundVolumeDown;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<ThirdPersonUserControl>() != null)
        {
            if (_coroutineSoundVolumeDown != null)
                StopCoroutine(_coroutineSoundVolumeDown);
            else
                GetComponent<AudioSource>().volume = 0f;
            
            GetComponent<AudioSource>().Play();
            _coroutineSoundVolumeUp = StartCoroutine(SoundVolumeUp());
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<ThirdPersonUserControl>() != null)
        {
            if (_coroutineSoundVolumeUp != null)
                StopCoroutine(_coroutineSoundVolumeUp);

            _coroutineSoundVolumeDown = StartCoroutine(SoundVolumeDown());
        }
    }

    private IEnumerator SoundVolumeDown()
    {
        float soundVolume = GetComponent<AudioSource>().volume;
        while (soundVolume > 0.01f)
        {
            soundVolume -= 0.01f;
            GetComponent<AudioSource>().volume = soundVolume;
            yield return new WaitForSeconds(0.02f);
        }

        GetComponent<AudioSource>().Stop();
    }

    private IEnumerator SoundVolumeUp()
    {
        float soundVolume = GetComponent<AudioSource>().volume;
        while (soundVolume <= _maxLevelSound)
        {
            soundVolume += 0.01f;
            GetComponent<AudioSource>().volume = soundVolume;
            yield return new WaitForSeconds(0.02f);
        }
    }
}