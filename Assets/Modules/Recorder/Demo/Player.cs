using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recorder.Demo
{
    public class Player : MonoBehaviour
    {
		public InputRecorder input;
		public float velocity = 5;

        void Update()
        {
			if (input.GetKey(KeyCode.A))
			{
				transform.position -= transform.right * Time.deltaTime * velocity;
			}
			else if (input.GetKey(KeyCode.D))
			{
				transform.position += transform.right * Time.deltaTime * velocity;
			}

			if (input.GetKey(KeyCode.S))
			{
				transform.position -= transform.forward * Time.deltaTime * velocity;
			}
			else if (input.GetKey(KeyCode.W))
			{
				transform.position += transform.forward * Time.deltaTime * velocity;
			}
        }
    }
}