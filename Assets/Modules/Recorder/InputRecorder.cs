using UnityEngine;

namespace Recorder
{
    public class InputRecorder : MonoBehaviour
    {
        private enum State
        {
            Idle,
            Recording,
            Playing
        }

        private State state;
        private Record currentRecord;
        private float startTime;
        
        public bool IsPlaying()
        {
            if (state == State.Playing)
            {
                return true;
            }

            return false;
        }

        public bool IsRecording()
        {
            if (state == State.Recording)
            {
                return true;
            }

            return false;
        }

        private void LateUpdate()
        {   
            switch(state)
            {
                case State.Recording:
                    currentRecord.CloseOpenedAndUnpressedKeyRecords(Time.time - startTime);
                    break;

                case State.Playing:
                    if (currentRecord.length < Time.time - startTime)
                    {
                        // Scene end
                        state = State.Idle;
                    }
                    break;
            }
        }

        public bool GetKey(KeyCode key)
        {
            switch (state)
            {
                case State.Idle:
                    return Input.GetKey(key);

                case State.Recording:
                    bool isPressing = Input.GetKey(key);
                    
                    if (isPressing)
                        currentRecord.OnKeyPress(key, Time.time - startTime);

                    return isPressing;

                case State.Playing:
                    return currentRecord.IsKeyPressed(key, Time.time - startTime);
            }

            return false;
        }

        public void StartRecording()
        {
            if (state != State.Idle)
            {
                Debug.LogWarning("Already recording or playing.");
                return;
            }

            startTime = Time.time;
            currentRecord = new Record();
            state = State.Recording;
        }

        public Record StopRecording()
        {
            if (state != State.Recording)
            {
                return null;
            }

            currentRecord.length = Time.time - startTime;
            state = State.Idle;
            return currentRecord;
        }

        public bool Play(Record record)
        {
            if (state == State.Recording)
            {
                return false;
            }

            if (record == null)
            {
                return false;
            }

            currentRecord = record;
            state = State.Playing;
            startTime = Time.time;

            return true;
        }

        public void Stop()
        {
            if (state != State.Playing)
            {
                return;
            }

            state = State.Idle;
        }
    }
}