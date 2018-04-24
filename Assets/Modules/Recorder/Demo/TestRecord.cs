using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;

public class TestRecord : MonoBehaviour 
{
	public InputRecorder input;
	private Record lastRecord;

	void Update () 
	{
		if (input.GetKey(KeyCode.Keypad1))
		{
			if (input.IsPlaying())
				Debug.Log("Recording: 1");
			else 
				Debug.Log("1");
		}
		
		if (input.GetKey(KeyCode.Keypad2))
		{
			if (input.IsPlaying())
				Debug.Log("Recording: 2");
			else 
				Debug.Log("2");
		}
		
		if (input.GetKey(KeyCode.Keypad3)) 
		{
			if (input.IsPlaying())
				Debug.Log("Recording: 3");
			else 
				Debug.Log("3");
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			input.StartRecording();
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			Record record = input.StopRecording();
			
			if (record != null)
				input.Play(record);
		}
	}
}
