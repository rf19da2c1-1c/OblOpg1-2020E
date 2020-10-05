using System;
using System.Collections.Generic;
using System.Text;

namespace CykelLib.model
{
    public class Cykel
    {
        private int _id;
        private String _farve;
        private double _pris;
        private int _gear;

        public Cykel()
        {
        }

        public Cykel(int id, string farve, double pris, int gear)
        {
            Id = id;
            Farve = farve;
            Pris = pris;
            Gear = gear;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 0)
                {
                    throw new ArgumentException("Cykelens farven skal være mindst 1 tegn langt");
                }
                _farve = value;
            }
        }

        public double Pris
        {
            get => _pris;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cykelens pris skal være over nul");
                }
                _pris = value;
            }
        }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value < 3 || 32 < value)
                {
                    throw new ArgumentException("Cykelens gear skal være mellem 3 og 32");
                }
                _gear = value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Farve)}: {Farve}, {nameof(Pris)}: {Pris}, {nameof(Gear)}: {Gear}";
        }
    }
}
