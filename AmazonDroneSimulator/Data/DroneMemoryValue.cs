﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator
{
    public class DroneMemoryValue : INotifyPropertyChanged
    {
        public string Key { get; set; }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value =  value;
                NotifyPropertyChanged("Value");
            }
        }


        private int _value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                  new PropertyChangedEventArgs(propertyName));
            }
        }

        public static List<DroneMemoryValue> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new List<DroneMemoryValue>();

                    _values.Add(new DroneMemoryValue { Key = "A" });
                    _values.Add(new DroneMemoryValue { Key = "N" });

                    for (var index = 0; index < 1000; index++)
                    {
                        _values.Add(new DroneMemoryValue { Key = "[" + index + "]" });
                    }
                }

                return _values;

            }
        }

        private static List<DroneMemoryValue> _values;
    }
}