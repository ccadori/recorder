using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

namespace Recorder
{
    public class Record
    {
        [XmlArray]
        public List<KeyRecord> keyRecords;
        [XmlAttribute]
        public float length;

        public Record()
        {
            keyRecords = new List<KeyRecord>();
        }

        public void OnKeyPress(KeyCode keyCode, float time)
        {
            KeyRecord currentKeyRecord = null;

            foreach (KeyRecord keyRecord in keyRecords)
                if (keyRecord.opened && keyRecord.keyCode == keyCode)
                {
                    keyRecord.updatedLastFrame = true;
                    return;
                }

            if (currentKeyRecord == null)
            {
                keyRecords.Add(new KeyRecord(time, keyCode));
            }
        }

        public void CloseOpenedAndUnpressedKeyRecords(float time)
        {
            foreach (KeyRecord keyRecord in keyRecords)
            {
                if (keyRecord.opened && !keyRecord.updatedLastFrame)
                {
                    keyRecord.end = time;
                    keyRecord.opened = false;
                }

                keyRecord.updatedLastFrame = false;
            }
        }

        public bool IsKeyPressed(KeyCode key, float time)
        {
            foreach (KeyRecord keyRecord in keyRecords)
                if (keyRecord.keyCode == key && keyRecord.end >= time && keyRecord.start <= time)
                    return true;

            return false;
        }

        public bool Trim(float start, float end)
        {
            if (start > length || end > length || end < start)
            {
                return false;
            }

            length = end - start;

            for (int i = 0; i < keyRecords.Count; i ++)
            {
                KeyRecord key = keyRecords[i];

                key.start = key.start - start;
                
                key.end = key.end - start;

                key.end = (key.end > length)? length : key.end;

                if (key.start <= 0 || key.start > length)
                    keyRecords.RemoveAt(i);
            }

            
            return true;
        }
    }
}