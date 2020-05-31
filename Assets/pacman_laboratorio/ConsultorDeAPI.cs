using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ConsultorDeAPI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Score s = new Score();
        s.nombre = "unity";
        s.score = 123;
        //s.ConsultarTop3();
        StartCoroutine(GetRequest("https://juegos.luisplata.co/api/" + "score/best/pacman"));
        //StartCoroutine(Upload());

        //"https://juegos.luisplata.co/api/"+"score/best/pacman"
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                Score[] s = JsonHelper.FromJson<Score>(webRequest.downloadHandler.text);
                foreach(Score sco in s)
                {
                    Debug.Log(sco.nombre + " => " + sco.score);
                }
            }
        }
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", "unity");
        form.AddField("score", "123");

        using (UnityWebRequest www = UnityWebRequest.Post("https://juegos.luisplata.co/api/" + "guardarData/pacman", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}