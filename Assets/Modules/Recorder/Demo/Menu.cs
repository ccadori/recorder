using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Recorder.Demo
{
    public class Menu : MonoBehaviour
    {
        public Button recordButton;
        public Button playButton;
        public InputRecorder recorder;

        private Record lastRecord;

        private Text playButtonText;
        private Text recordButtonText;

        private void Awake()
        {
            playButtonText = playButton.GetComponentInChildren<Text>();
            recordButtonText = recordButton.GetComponentInChildren<Text>();
        }

        public void TogglePlay()
        {
            if (lastRecord == null || recorder.IsRecording())
                return;

            if (recorder.IsPlaying())
                recorder.Stop();
            else
                recorder.Play(lastRecord);

            UpdateButtons();
        }

        public void ToggleRecord()
        {
            if (recorder.IsRecording())
                lastRecord = recorder.StopRecording();
            else
                recorder.StartRecording();

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (recorder.IsRecording())
            {
                recordButton.interactable = true;
                recordButtonText.text = "Stop";

                playButton.interactable = false;
                playButtonText.text = "Play";
            }
            else if (recorder.IsPlaying())
            {
                recordButton.interactable = false;
                recordButtonText.text = "Recording";

                playButton.interactable = true;
                playButtonText.text = "Stop";
            }
            else
            {
                if (lastRecord == null)
                    playButton.interactable = false;
                else
                    playButton.interactable = true;

				recordButtonText.text = "Record";
                recordButton.interactable = true;

				playButtonText.text = "Play";
            }
        }
    }
}