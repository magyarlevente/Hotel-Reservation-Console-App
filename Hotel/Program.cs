using System;
using System.Collections;
using System.Collections.Generic;

namespace Program
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel("Sunny Hotel",3);
            Console.WriteLine(hotel.isRoomAvaiable());

            hotel.bookRoom("Magyar Levente");
            Console.WriteLine(hotel.ToString());

            hotel.bookRoom("Peti");
            hotel.bookRoom("Jani");
            Console.WriteLine(hotel.ToString());

            hotel.bookRoom("Kati");

            hotel.checkoutRoom("Jani");
            hotel.checkoutRoom("Magyar Levente");
            Console.WriteLine(hotel.ToString());

        }
    }

    public class Hotel
    {
        private string hotelName;
        private int rooms;
        private int avaiableRooms;
        private int bookedRooms;
        private List<string> guests;


        public Hotel(string hotelName, int rooms)
        {
            this.hotelName = hotelName;
            this.rooms = rooms;
            this.avaiableRooms = rooms;
            this.bookedRooms = 0;
            this.guests = new List<string>();
        }

        public override string ToString()
        {
            return $"""
                    Hotel adatai: 
                    - Hotel neve: {hotelName}
                    - Szobák száma: {rooms}
                    - Szabad szobák száma: {avaiableRooms}
                    - Lefoglalt szobák száma: {bookedRooms}
                    - Vendéglista: {string.Join(", ",guests)}
                    """;
        }

        public bool isRoomAvaiable()
        {
            if (avaiableRooms > 0)
            {
                return true;
            }
            return false;
        }

        public void bookRoom(string name)
        {
            if (isRoomAvaiable() == true)
            {
                guests.Add(name);
                avaiableRooms--;
                bookedRooms++;
                
            }
            else
            {
                Console.WriteLine("Hiba! Minden szoba foglalt.");
            }
        }

        public void checkoutRoom(string name)
        {
            if (guests.Contains(name))
            {
                guests.Remove(name);
                avaiableRooms++;
                bookedRooms--;

            }
            else
            {
                Console.WriteLine("Hiba! Az adott vendég nem található a rendszerben.");
            }
        }
    }
}

