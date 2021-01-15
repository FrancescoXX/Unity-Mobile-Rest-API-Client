using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RestClient : MonoBehaviour
{
    public Button button1;
    public Text RestText;

	void Start () {
		Button btn = button1.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

    //Connect Coroutine with button click directly ?
    void TaskOnClick(){
        StartCoroutine(GetText());
    }

    // Button1
	IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get("https://jsonplaceholder.typicode.com/users");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            RestText.text = www.downloadHandler.text;
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    
}
