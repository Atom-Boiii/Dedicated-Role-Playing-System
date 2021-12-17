using UnityEngine;
using System.IO;
using System.Collections;

public class LoadBundles : MonoBehaviour
{
    public string objectName, assetName;

    AssetBundle myLoadedAssetBundle;

    public void Init()
    {
        StartCoroutine(LoadAsset());
    }

    private IEnumerator LoadAsset()
    {
        var bundleLoadRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.persistentDataPath, assetName));
        yield return bundleLoadRequest;

        var myLoadedAssetBundle = bundleLoadRequest.assetBundle;
        if (myLoadedAssetBundle == null)
        {
            DevConsole.instance.ErrorLog("Failed to load AssetBundle: " + myLoadedAssetBundle.name);
            yield break;
        }

        var assetLoadRequest = myLoadedAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetLoadRequest;

        GameObject prefab = assetLoadRequest.asset as GameObject;
        GameObject Loaded = Instantiate(prefab, transform.position, transform.rotation);

        Loaded.name = objectName;

        myLoadedAssetBundle.Unload(false);
    }
}