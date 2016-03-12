using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheProblem
{
    //https://galoaragonesesprogrammer.wordpress.com/
    public class Car
    {
        public string LogFilePath { get; set; }

        public Guid Id { get; set; }
        public int PetrolLitersRemaning { get; set; }
        public int MaxPetrolLiters { get; set; }
        public bool Started { get; set; }
        public decimal Speed { get; set; }
        public string Owner { get; set; }

        public Car(string logFilePath)
        {
            this.LogFilePath = logFilePath;
        }

        public void Assing(string owner)
        {
            this.Owner = owner;
            File.AppendAllText(this.LogFilePath, "Te new owner is " + owner);
        }

        public void Refuel(int petrolLiters)
        {
            if (petrolLiters + this.PetrolLitersRemaning >= this.MaxPetrolLiters)
                File.AppendAllText(this.LogFilePath, "Refuel is not necessary");
            else
            {
                this.PetrolLitersRemaning += petrolLiters;
                File.AppendAllText(this.LogFilePath, "Refuel is necessary");
            }
        }

        public void Start()
        {
            if (this.Started)
                throw new CarIsAlreadyStartedException();
            else
            {
                this.Started = true;
                File.AppendAllText(this.LogFilePath, "Car has been started");
            }
        }

        public void Save()
        {
            var xmlSerializer = new XmlSerializer(typeof(Car));
            using (var textWriter = new StreamWriter("Car." + this.Id + ".xml"))
            {
                xmlSerializer.Serialize(textWriter, this);
            }

            File.AppendAllText(this.LogFilePath, "Te car was saved");
        }
    }

    public class CarIsAlreadyStartedException : Exception
    {
    }
}
