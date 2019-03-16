using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
   [DataContract]
   public class CarModel
    {
        private int id;
        private string name;
        private int year;
        private int manufacturerId;

        public CarModel()
        {

        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        [DataMember]
        public int ManufacturerId
        {
            get { return manufacturerId; }
            set { manufacturerId = value; }
        }
    } 
}
