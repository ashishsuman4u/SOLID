using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SingleResponsibilityPrinciple
{
    public class Car
    {
        public Guid Id { get; set; }
        public int PetrolLitersRemaning { get; set; }
        public int MaxPetrolLiters { get; set; }
        public bool Started { get; set; }
        public decimal Speed { get; set; }
        public string Owner { get; set; }

        public void Assing(string owner)
        {
            this.Owner = owner;
        }

        public bool IsAllowedToReload(int petrolLiters)
        {
            return petrolLiters + this.PetrolLitersRemaning >= this.MaxPetrolLiters;
        }

        public void Refuel(int petrolLiters)
        {
            this.PetrolLitersRemaning += petrolLiters;
        }

        public bool IsStarted()
        {
            return this.Started;
        }

        public void Start()
        {
            this.Started = true;
        }
    }

    public class LoggingSystem
    {
        public string LogFilePath { get; set; }

        public void WriteEntry(string entry)
        {
            File.AppendAllText(this.LogFilePath, entry);
        }
    }

    public class StoreDataCar
    {
        public void Save(Car car)
        {
            var xmlSerializer = new XmlSerializer(typeof(Car));
            using (var textWriter = new StreamWriter("Car " + car.Id + ".xml"))
            {
                xmlSerializer.Serialize(textWriter, car);
            }
        }
    }

    public class ManagementCar
    {
        public LoggingSystem LoggingSystem { get; set; }
        public StoreDataCar StoreData { get; set; }

        public Car Car { get; set; }

        public void AssingCar(string owner)
        {
            this.Car.Assing(owner);
            LoggingSystem.WriteEntry("Te new owner is " + owner);
        }

        public void Refuel(int petrolLiters)
        {
            if (this.Car.IsAllowedToReload(petrolLiters))
                LoggingSystem.WriteEntry("Refuel is not necessary");
            else
            {
                this.Car.Refuel(petrolLiters);
                LoggingSystem.WriteEntry("Refuel is necessary");
            }
        }

        public void Start()
        {
            if (this.Car.IsStarted())
                throw new CarIsAlreadyStartedException();
            else
            {
                this.Car.Start();
                LoggingSystem.WriteEntry("Car has been started");
            }
        }

        public void Save()
        {
            StoreData.Save(this.Car);
            LoggingSystem.WriteEntry("Te car was saved");
        }
    }

    public class CarIsAlreadyStartedException : Exception
    {
    }
}
