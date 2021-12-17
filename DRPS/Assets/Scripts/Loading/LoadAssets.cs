using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssets : MonoBehaviour
{
    private void Start()
    {
        // Start the loading screen

        // if the loading screen is enabled start loading the assets
        StartCoroutine(RunLoader());
    }

    private IEnumerator RunLoader()
    {
        yield return new WaitForSeconds(.5f);

        GameObject[] foundLoaders = GameObject.FindGameObjectsWithTag("Loader");
        foreach (var item in foundLoaders)
        {
            item.GetComponent<LoadBundles>().Init();
        }
    }
}
