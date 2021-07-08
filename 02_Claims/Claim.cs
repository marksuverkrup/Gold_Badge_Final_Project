using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                double diff = (DateOfClaim - DateOfIncident).TotalDays;
                double constant = 31;
                if (diff < constant)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Claim() { }
        public Claim(int claimID, ClaimType typeOfClaim, string desc, int amount, DateTime dOI, DateTime dOC)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = desc;
            Amount = amount;
            DateOfIncident = dOI;
            DateOfClaim = dOC;
        }
    }
}
