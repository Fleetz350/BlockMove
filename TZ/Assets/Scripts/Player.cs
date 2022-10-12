using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour 
    {
        private PathFollower _follower;

        //[SerializeField]
        //private Path _path;

        private readonly string _filePath = "/Json.txt";

        private void Awake()
        {
            _follower = GetComponent<PathFollower>();

            StartCoroutine(DropboxLoader.LoadString(_filePath, StartFollow));
        }
        private void StartFollow(string json)
        {
            Path path = JsonUtility.FromJson<Path>(json);
            _follower.StartFollower(path);
        }
    }
}
