using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class CarModel
    {
        public string? RegNum { get; set; }
        public int Id { get; set; }

        public static List<CarModel> Data(){
            return new List<CarModel>(){
                new CarModel(){Id=1,  RegNum="kr 1223"},
                new CarModel(){Id=2,  RegNum="ujs 1223"},
                new CarModel(){Id=3,  RegNum="su 454321"}
            };
        }
    }

    public class OwnerModel
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public int IdCar { get; set; }
   
        public static List<OwnerModel> Data(){
            return new List<OwnerModel>(){
                new OwnerModel(){Id=1, IdCar=1, Name="Olek Nowak"},
                new OwnerModel(){Id=2, IdCar=2, Name="Wanda Nowak"},
                new OwnerModel(){Id=3, IdCar=2, Name="Jurek Nowak"}
            };
        }
    }
}