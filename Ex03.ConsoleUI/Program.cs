﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Garage garage = new Garage();
            UI garageUI = new UI();
            garageUI.OpenGarage();
        }
    }
}
