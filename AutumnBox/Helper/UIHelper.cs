﻿using AutumnBox.Basic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutumnBox.Helper
{
    public static class UIHelper
    {
        public static void DragMove(Window m, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                m.DragMove();
            }
        }
        public static void DragMove(Window m, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                m.DragMove();
            }
        }
        public static void ChangeButtonByStatus(Button[] buttons, DeviceStatus status) {
        }
        public static void ChangeImageByStatus(Image[] images, DeviceStatus status) {
        }
        public static void ShowRateBox(Window owner) { }
        public static void CloseRateBox(Window owner) { }
    }

}