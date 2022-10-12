using System;
using System.Collections;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    internal class DropboxLoader
    {
        private static readonly string Token = "sl.BRC2lYpLBZqIp71MVxpnH5HQysB2tQBzlfnZr3ZLJ0OZ_qoabKIP7xDXKp0lOgY62dHLIr4F0Lk2drPahDVbmthcdpTrBEySVAgGVaYVYXx5i8ZbNOl89UoUkNWnkyx9g7AIadQ";

        public static IEnumerator LoadString(string file, Action<string> callback)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("https://content.dropboxapi.com/2/files/download"))
            {
                www.SetRequestHeader("Authorization", "Bearer " + Token);
                www.SetRequestHeader("Dropbox-API-Arg", "{\"path\": \"" + file + "\"}");
                www.SetRequestHeader("DContent-Type", "");

                yield return www.SendWebRequest();
             

                if (www.result == UnityWebRequest.Result.Success)
                {
                    callback?.Invoke(www.downloadHandler.text); 
                }
            }
        }
    }
}
