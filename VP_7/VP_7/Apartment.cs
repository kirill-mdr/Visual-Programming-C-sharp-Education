using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_7
{
    class Apartment
    {
        public int RoomsCount { get; set; }
        public int Square { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }
        public int LastFloor { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public Apartment()
        {

        }
        public Apartment(int roomCount, int square, int price, int floor, int lastFloor, string district, string address)
        {
            RoomsCount = roomCount;
            Square = square;
            Price = price;
            Floor = floor;
            LastFloor = lastFloor;
            District = district;
            Address = address;
        }
        public override string ToString()
        {
            return "Кол-во комнта: " + RoomsCount + ";  Площадь: " + Square + ";  Цена: " + Price + ";  Этаж: " + Floor + "/" + LastFloor + ";  Район: " + District + ";  Адрес: " + Address;
        }
    }
}
