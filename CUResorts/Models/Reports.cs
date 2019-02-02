using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUResorts.Models
{
    public class MonthlyReport
    {
        public static List<AnemityUsage> AnemityUsageReport(int month, int year)
        {
            List<Anemity> anemities = AnemityActions.GetAnemities();
            List<AnemityUsage> result = new List<AnemityUsage>();
            foreach(Anemity a in anemities)
            {
                result.Add(new AnemityUsage(a, month, year));
            }
            return result.OrderByDescending(x=>x.TotalUsage).ToList();
        }

        public static List<RoomUsage> RoomUsageReport(int month, int year)
        {
            List<Room> rooms = RoomActions.GetRooms();
            List<RoomUsage> result = new List<RoomUsage>();
            foreach(Room r in rooms)
            {
                result.Add(new RoomUsage(r, month, year));
            }
            return result.OrderByDescending(x => x.TotalUsage).ToList();
        }

        public static List<GuestSpending> GuestSpendingReport(int month, int year)
        {
            List<Person> people = GuestActions.GetGuests();
            List<GuestSpending> result = new List<GuestSpending>();
            foreach(Person p in people)
            {
                result.Add(new GuestSpending(p, month, year));
            }
            return result;
        }

    }
    public class AnemityUsage 
    {
        public string Anemity { get; set; }
        public decimal StandardCost { get; set; }
        public int TotalUsage { get; set; }
        public decimal TotalRevenue { get; set; }
        public AnemityUsage(Anemity anemity, int month, int year)
        {
            Anemity = anemity.Description;
            StandardCost = anemity.StandardCost;
            TotalUsage = anemity.Charges.Where(x=>x.DateCharged.Month == month && x.DateCharged.Year == year).Count();
            TotalRevenue = StandardCost * TotalUsage;
        }
    }
    public class RoomUsage
    {
        public int RoomNumber { get; set; }
        public int TotalUsage { get; set; }
        public double TotalRevenue { get; set; }
        public RoomUsage(Room room, int month, int year)
        {
            RoomNumber = room.room1;
            TotalUsage = room.Reservations.Where(x => x.DateReserved.Month == month && x.DateReserved.Year == year).Count();
            TotalRevenue = room.RoomType.StandardCost * TotalUsage;
        }
    }
    public class GuestSpending
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double TotalSpent { get; set; }
        public GuestSpending(Person person, int month, int year)
        {
            LastName = person.LNAME;
            FirstName = person.FNAME;
            TotalSpent = person.Invoices.Where(x => x.DatePaid.Month == month && x.DatePaid.Year == year && x.Void == null)
                .Sum(x => x.AmountPaid);
        }
    }
}