﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HiddenDeep
{
    class Program
    {
        public static Rewrite jokin = new Rewrite("hdeep");

        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        public static bool IsKeyPushedDown(Keys vKey)
        {
            return 0 != (GetAsyncKeyState((int)vKey) & 0x8000);
        }

        public static int MultiPointer(int Base, int[] Pointers)
        {
            int Current = jokin.ReadInt((int)(jokin.BaseAddr() + Base));

            if (Pointers != null)
            {
                foreach (int Pointer in Pointers)
                {
                    Current = jokin.ReadInt(Current + Pointer);
                }
            }
            return Current;
        }

        public static void Main()
        {
            if (jokin.CheckProcess())
            {
                Console.Title = "HiddenDeep Game Hack | AlphaWolf # JokinAce";
                Console.WriteLine("HiddenDeep GameCheat | AlphaWolf # JokinAce");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("ALT+5 | Magnum Ammo 9999");
                Console.WriteLine("ALT+6 | Scan Balls 9999");
                Console.WriteLine("ALT+7 | Explosive Charges 9999");
                Console.WriteLine("ALT+8 | HP % 9999");
                Console.WriteLine("ALT+9 | AssaultRifle Ammo 9999");
                Console.WriteLine("-------------------------------------------");

                while (true)
                {
                    if (IsKeyPushedDown(Keys.LMenu) & IsKeyPushedDown(Keys.D5))
                    {
                        int MagnumAmmo = MultiPointer(0x03EB5D8, new int[] { 0x1BC, 0x8, 0x1A0, 0x24, 0x1C }); //0x40
                        jokin.WriteInt(MagnumAmmo + 0x40, 9999);
                        Console.WriteLine("Magnum Ammo 9999");
                    }

                    if (IsKeyPushedDown(Keys.LMenu) & IsKeyPushedDown(Keys.D6))
                    {
                        int ScanBallsAmmo = MultiPointer(0x03EB5D8, new int[] { 0x1A0, 0xC, 0x28 }); //0x14
                        jokin.WriteInt(ScanBallsAmmo + 0x14, 9999);
                        Console.WriteLine("Scan Balls 9999");
                    }

                    if (IsKeyPushedDown(Keys.LMenu) & IsKeyPushedDown(Keys.D7))
                    {
                        int ExplosivesAmmo = MultiPointer(0x03EB5D8, new int[] { 0x1A0, 0x30, 0x114 }); //0x14
                        jokin.WriteInt(ExplosivesAmmo + 0x14, 9999);
                        Console.WriteLine("Explosive Charges 9999");
                    }

                    if (IsKeyPushedDown(Keys.LMenu) & IsKeyPushedDown(Keys.D8))
                    {
                        int HP = jokin.ReadInt((int)(jokin.BaseAddr() + 0x03EB5D8));
                        jokin.WriteFloat(HP + 0x1B0, 9999);
                        Console.WriteLine("HP 9999");
                    }

                    if (IsKeyPushedDown(Keys.LMenu) & IsKeyPushedDown(Keys.D9))
                    {
                        int AssaultRifleAmmo = MultiPointer(0x03EB4E0, new int[] { 0x8, 0x20, 0xA4 }); //0x790
                        jokin.WriteInt(AssaultRifleAmmo + 0x790, 9999);
                        Console.WriteLine("AssaultRifle Ammo 9999");
                    }
                    Thread.Sleep(100);
                }
            }
            else
            {
                Console.ReadLine();
            }
        }
    }
}
