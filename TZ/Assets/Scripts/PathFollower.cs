using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    internal class PathFollower : MonoBehaviour
    {
        public void StartFollower(Path path)
        {
            StartCoroutine(FollowPath(path.Points, path.Time, path.Loopind));
        }

        private IEnumerator FollowPath(Vector3[] points, float time, bool looping)
        {
            var pointTime = time / points.Length;

            while (true)
            {
                foreach (var point in points)
                {
                    yield return StartCoroutine(MoveToPoint(point, pointTime));
                }
                if (!looping)
                {
                    break;
                }
            }
        }
        private IEnumerator MoveToPoint(Vector3 to, float time)
        {
            var from = transform.position;

            for (float t = 0; t < 1; t += Time.deltaTime / time)
            {
                transform.position = Vector3.Lerp(from, to, t);
                yield return null;
            }

            
        }

    }
}
