﻿using System;

namespace Assignment
{
    public class Address : IAddress, IEquatable<Address>, IComparable<Address>
    {
        public string StreetAddress { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";

        public override int GetHashCode() =>
            (StreetAddress, City, State, Zip).GetHashCode();

        #region IEquatable methods
        public override bool Equals(object? obj) =>
            obj is Address address && Equals(address);

        public bool Equals(Address other)
        {
            if (other is null) return false;

            return StreetAddress == other.StreetAddress && City == other.City
                && State == other.State && Zip == other.Zip;
        }

        public static bool operator ==(Address leftSide, Address rightSide)
            => leftSide?.Equals(rightSide) 
                ?? leftSide is null && rightSide is null
                    ? true
                    : false;

        public static bool operator !=(Address leftSide, Address rightSide)
            => !(leftSide == rightSide);
        #endregion

        #region IComparable methods
        public int CompareTo(Address other)
        {
            int compState = string.Compare(State, other?.State);
            if (compState != 0) return compState;

            int compCity = string.Compare(City, other?.City);
            if (compCity != 0) return compCity;

            return string.Compare(Zip, other?.Zip);
        }

        public static bool operator >=(Address leftSide, Address rightSide)
        {
            if (leftSide is null) return rightSide is null ? true : false;

            return leftSide.CompareTo(rightSide) >= 0;
        }

        public static bool operator <=(Address leftSide, Address rightSide)
        {
            if (leftSide is null) return true;

            return leftSide.CompareTo(rightSide) <= 0;
        }

        public static bool operator >(Address leftSide, Address rightSide)
        {
            if (leftSide is null) return false;

            return leftSide.CompareTo(rightSide) > 0;
        }

        public static bool operator <(Address leftSide, Address rightSide)
        {
            if (leftSide is null) return rightSide is null ? false : true;

            return leftSide.CompareTo(rightSide) < 0;
        }
        #endregion
    }
}
