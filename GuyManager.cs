using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace HF_ch11_DataContracts
{
    class GuyManager : INotifyPropertyChanged
    {
        private Guy joe = new Guy("Joe", 37, 176.22M);
        public Guy Joe { get => joe; }

        private Guy bob = new Guy("Bob", 45, 4.68M);
        public Guy Bob { get => bob; }

        private Guy ed = new Guy("Ed", 43, 377.51M);
        public Guy Ed { get => ed; }

        public Guy NewGuy { get; set; }
        public string GuyFile { get; set; }
        public void ReadGuy()
        {
            if (String.IsNullOrEmpty(GuyFile))
                return;

            using (Stream inputStream = File.OpenRead(GuyFile))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
                NewGuy = serializer.ReadObject(inputStream) as Guy;
            }
            OnPropertyChanged("NewGuy");
        }
        public void WriteGuy(Guy guyToWrite)
        {
            GuyFile = Path.GetFullPath(guyToWrite.Name + ".xml");

            if (File.Exists(GuyFile))
                File.Delete(GuyFile);
            using (Stream outpuStream = File.OpenWrite(GuyFile))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
                serializer.WriteObject(outpuStream, guyToWrite);
            }
            OnPropertyChanged("GuyFile");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
