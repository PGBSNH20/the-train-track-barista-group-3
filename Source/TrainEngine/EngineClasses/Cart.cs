using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TrainEngine
{
    public class Cart
    {
        public int TrainId { get; set; }
        public int DepStationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public int ArrvStationId { get; set; }
        public DateTime ArrivalTime { get; set; }

        const string FilePathSaved = @"C:\Users\doman\OneDrive\Desktop\RailwayPro\Source\TrainEngine\Data\SavedTrips.txt";
        

        public static Cart CreateFromLine(string line)
        {
            string[] parts = line.Split(',');
            Cart p = new Cart()
            {
                TrainId = int.Parse(parts[0]),
                DepStationId = int.Parse(parts[1]),
                DepartureTime = DateTime.Parse(parts[2]),
                ArrvStationId = int.Parse(parts[3]),
                ArrivalTime = DateTime.Parse(parts[4])
            };
            return p;
        }

        public static List<Cart> GetLoadedSchedule()
        {
            List<Cart> ListOfTrains = new List<Cart>();
            string[] lines = File.ReadAllLines(FilePathSaved);

            foreach (string line in lines)
            {
                Cart p = Cart.CreateFromLine(line);
                ListOfTrains.Add(p);
            }
            return ListOfTrains;
        }



        public  void SaveToFile(List<Schedule> schedule)
        {      
            List<string> linesLinesToSave = new List<string>();
            try
            {
                foreach (var item in schedule)
                {
                    linesLinesToSave.Add(item.TrainId.ToString() + ',' + item.DepStationId.ToString() + ',' + item.DepartureTime.ToString() + ',' + item.ArrvStationId.ToString() + ',' + item.ArrivalTime.ToString());
                    
                }
            }
            catch (Exception)
            {
                
            }

            try
            {
                File.WriteAllLines(FilePathSaved, linesLinesToSave);
            }

            catch (Exception)
            {

               
            }

            
        }



        public void Load(List<Cart> loaded)
        {                     
            foreach (var item in loaded.OrderBy(x => x.DepartureTime))
            {
              
                Console.WriteLine(item.TrainId + ":" + Train.GetTrain().Find(s => s.TrainId == item.TrainId).TrainName + ":" + item.DepartureTime.TimeOfDay + ":" + Station.GetStation().Find(s => s.StationId == item.DepStationId).StationName + ":" + item.ArrivalTime.TimeOfDay + ":" + Station.GetStation().Find(s => s.StationId == item.ArrvStationId).StationName);
            }
        }


    }




}

