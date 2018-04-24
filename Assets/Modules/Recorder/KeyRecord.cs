using UnityEngine;
using System.Xml.Serialization;

namespace Recorder
{
    [System.Serializable]
    public class KeyRecord
    {
        [XmlAttribute]
        public float start;
        [XmlAttribute]
        public float end;
        [XmlAttribute]
        public KeyCode keyCode;
        
        [XmlIgnore]
        public bool opened;
        [XmlIgnore]
        public bool updatedLastFrame;

        public KeyRecord() 
        {
            //
        }

        public KeyRecord (float start, KeyCode keyCode)
        {
            this.start = start;
            this.keyCode = keyCode;
            opened = true;
            updatedLastFrame = true;
        }
    }
}