using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HF_ch11_DataContracts
{
    [DataContract(Namespace = "HF_ch11_DataContracts")]
    class Guy
    {
        [DataMember(Name="Name")]
        public string Name { get; private set; }
        [DataMember(Name = "Age")]
        public int Age { get; private set; }
        [DataMember(Name = "Cash")]
        public decimal Cash { get; private set; }
        [DataMember(Name = "MyCard")]
        public Card TrumpCard { get; set; }
        public override string ToString()=>
            String.Format($"My name is {Name}, I'm {Age}, I have {Cash} bucks, and my trump card is {TrumpCard}.");
        

        public Guy(string name, int age, decimal cash)
        {
            Name = name;
            Age = age;
            Cash = cash;
            TrumpCard = Card.RandomCard();
        }
    }
}
