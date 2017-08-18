﻿using AutumnBox.Basic.AdbEnc;
using AutumnBox.Basic.Devices;
using System;
using System.Collections;
/*此文件中的代码是有关core的实例化的*/
namespace AutumnBox.Basic
{
    /// <summary>
    /// 对AutumnBox.Basic的功能进行封装的类,实例化后可以调用各种方法来达成目的
    /// </summary>
    public sealed partial class Core
    {
        public event EventsHandlers.SimpleFinishEventHandler SendFileFinish;
        public event EventsHandlers.FinishEventHandler ActivatedBrvent;
        public event EventsHandlers.SimpleFinishEventHandler FlashCustomRecoveryFinish;
        public event EventsHandlers.FinishEventHandler RebootFinish;
        public event EventsHandlers.FinishEventHandler XiaomiSystemUnlockFinish;
        public event EventsHandlers.FinishEventHandler XiaomiBootloaderRelockFinish;


        public DevicesListener devicesListener;

        private Adb adb;
        private Fastboot fastboot;

        private Hashtable files = new Hashtable { { "sideloadbat", @"util\sideload.bat" } };
        public Core() {
            devicesListener = new DevicesListener();
            adb = new Adb();
            fastboot = new Fastboot();
        }
    }
}
