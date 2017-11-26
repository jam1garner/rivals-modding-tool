﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RivalsModdingTool
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ripSprites_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.riph;
        }

        private void ripSprites_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.rip;
        }

        private void replaceSprites_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.replaceh;
        }

        private void replaceSprites_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.replace;
        }

        private void ripAudio_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.rip_audioh;
        }

        private void ripAudio_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.rip_audio;
        }

        private void replaceAudio_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.replace_audioh;
        }

        private void replaceAudio_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.replace_audio;
        }

        private void browseMods_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.browseh;
        }

        private void browseMods_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.browse;
        }

        class Offsets
        {
            public List<Tuple<int, int>> pngOffsets;
            public List<Tuple<int, int>> wavOffsets;
        }

        static byte[] pngMagic = { 137, 80, 78, 71 };
        static byte[] pngFooter = { 73, 69, 78, 68, 174, 66, 96, 130 };
        static byte[] wavMagic = { 82, 73, 70, 70 };

        byte[] exe = null;
        Offsets offsets = null;

        void updateOffsets()
        {
            
            if(exe == null)
               exe = File.ReadAllBytes("RivalsofAether.exe");
            int[] pngLocations = ByteArraySearch.Locate(exe, pngMagic);
            int[] pngEndLocations = ByteArraySearch.Locate(exe, pngFooter).Select(o => o+pngFooter.Length).ToArray();
            int[] wavLocations = ByteArraySearch.Locate(exe, wavMagic);
            Array.Sort(pngLocations);
            Array.Sort(pngEndLocations);
            List<Tuple<int, int>> pngRanges = new List<Tuple<int, int>>();


            for (int i = pngLocations.Length - 1; i >= 0; i--) 
            {
                for (int j = 0; j < pngEndLocations.Length; j++)
                {
                    if (pngEndLocations[j] > pngLocations[i] && pngEndLocations[j] != 0 && (pngEndLocations[j] - pngLocations[i] < 10000000))
                    {
                        pngRanges.Add(new Tuple<int, int>(pngLocations[i], pngEndLocations[j]));
                        pngEndLocations[j] = 0;
                        break;
                    }
                }
            }
            pngRanges.Reverse();
            

            BinaryReader exeFile = new BinaryReader(new FileStream("RivalsofAether.exe", FileMode.Open));
            List<Tuple<int, int>> wavRanges = new List<Tuple<int, int>>();
            foreach(var i in wavLocations)
            {
                exeFile.BaseStream.Seek(i+4, SeekOrigin.Begin);
                wavRanges.Add(new Tuple<int,int>(i,exeFile.ReadInt32()+i+8));
            }
            exeFile.Close();

            offsets = new Offsets() { pngOffsets = pngRanges, wavOffsets = wavRanges };

            //Write to file
            string f = "";
            foreach(var i in offsets.pngOffsets)
                f += i.Item1 + "-" + i.Item2 + "\r\n";
            f += "-\r\n";
            foreach (var i in offsets.wavOffsets)
                f += i.Item1 + "-" + i.Item2 + "\r\n";
            File.WriteAllText("offsets.txt", f);
        }

        void verifyOffsets()
        {
            if (!File.Exists("RivalsofAether.exe") || offsets != null)
                return;

            if (File.Exists("offsets.txt"))
            {
                if(offsets == null)
                {
                    List<string> lines = File.ReadAllLines("offsets.txt").ToList();
                    lines.Add("-"); //Safety for if there is no end to png section
                    IEnumerable<string> pngLines = lines.Take(lines.IndexOf("-")).ToArray();
                    IEnumerable<string> wavLines = lines.Skip(lines.IndexOf("-") + 1).Take(lines.IndexOf("-")).ToArray();

                    List<Tuple<int, int>> pngOffsets = pngLines.Select(o => new Tuple<int, int>(Convert.ToInt32(o.Split('-')[0]), Convert.ToInt32(o.Split('-')[1]))).ToList();
                    List<Tuple<int, int>> wavOffsets = wavLines.Select(o => new Tuple<int, int>(Convert.ToInt32(o.Split('-')[0]), Convert.ToInt32(o.Split('-')[1]))).ToList();
                    
                    offsets = new Offsets() { pngOffsets = pngOffsets, wavOffsets = wavOffsets };
                }
                BinaryReader exeFile = new BinaryReader(new FileStream("RivalsofAether.exe", FileMode.Open));
                int good = 0;
                int bad = 0;
                foreach (var i in offsets.pngOffsets)
                {
                    exeFile.BaseStream.Seek(i.Item1, SeekOrigin.Begin);
                    if (exeFile.ReadBytes(4).SequenceEqual(pngMagic))
                        good++;
                    else
                        bad++;
                }
                foreach (var i in offsets.wavOffsets)
                {
                    exeFile.BaseStream.Seek(i.Item1, SeekOrigin.Begin);
                    if (exeFile.ReadBytes(4).SequenceEqual(wavMagic))
                        good++;
                    else
                        bad++;
                }
                exeFile.Close();
                if (good < bad) // if over 50% of offsets are found to be bad
                    updateOffsets();
            }
            else
            {
                updateOffsets();
            }
        }

        private void ripSprites_Click(object sender, EventArgs e)
        {
            verifyOffsets();
            if (!Directory.Exists("sprites/"))
                Directory.CreateDirectory("sprites/");

            BinaryReader exeFile = new BinaryReader(new FileStream("RivalsofAether.exe", FileMode.Open));
            int j = 0;
            foreach (var i in offsets.pngOffsets)
            {
                j++;
                exeFile.BaseStream.Seek(i.Item1, SeekOrigin.Begin);
                File.WriteAllBytes($"sprites/RIP_{j}.png", exeFile.ReadBytes(i.Item2 - i.Item1));
            }
            exeFile.Close();
        }

        private void ripAudio_Click(object sender, EventArgs e)
        {
            verifyOffsets();
            if (!Directory.Exists("audio/"))
                Directory.CreateDirectory("audio/");

            BinaryReader exeFile = new BinaryReader(new FileStream("RivalsofAether.exe", FileMode.Open));
            int j = 0;
            foreach (var i in offsets.wavOffsets)
            {
                j++;
                exeFile.BaseStream.Seek(i.Item1, SeekOrigin.Begin);
                File.WriteAllBytes($"audio/RIP_{j}.wav", exeFile.ReadBytes(i.Item2 - i.Item1));
            }
            exeFile.Close();
        }

        private void replaceSprites_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("sprites/"))
                return;
            verifyOffsets();

            BinaryWriter exeFile = new BinaryWriter(new FileStream("RivalsofAether.exe", FileMode.Open));
            int j = 0;
            foreach (var i in offsets.pngOffsets)
            {
                j++;
                if (!File.Exists($"sprites/RIP_{j}.png"))
                    continue;
                exeFile.BaseStream.Seek(i.Item1, SeekOrigin.Begin);
                byte[] pngFile = File.ReadAllBytes($"sprites/RIP_{j}.png");
                if (pngFile.Length >= (i.Item2 + pngFooter.Length) - i.Item1)
                {
                    MessageBox.Show($"WARNING: RIP_{j}.png is too large, compress to reduce file size");
                    continue;
                }
                exeFile.Write(pngFile);
            }
            exeFile.Close();
        }

        private void replaceAudio_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("audio/"))
                return;
            verifyOffsets();

            BinaryWriter exeFile = new BinaryWriter(new FileStream("RivalsofAether.exe", FileMode.Open));
            int j = 0;
            foreach (var i in offsets.pngOffsets)
            {
                j++;
                if (!File.Exists($"audio/RIP_{j}.wav"))
                    continue;
                exeFile.BaseStream.Seek(i.Item1, SeekOrigin.Begin);
                byte[] wavFile = File.ReadAllBytes($"audio/RIP_{j}.wav");
                if (wavFile.Length >= i.Item2 - i.Item1)
                {
                    MessageBox.Show($"WARNING: RIP_{j}.wav is too large, compress to reduce file size");
                    continue;
                }
                exeFile.Write(wavFile);
            }
            exeFile.Close();
        }

        private void browseMods_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gamebanana.com/games/5750");
        }
    }

    static class ByteArraySearch
    {

        static readonly int[] Empty = new int[0];

        public static int[] Locate(byte[] searchThis, byte[] searchFor)
        {
            if (IsEmptyLocate(searchThis, searchFor))
                return Empty;

            var list = new List<int>();

            for (int i = 0; i < searchThis.Length; i++)
            {
                if (!(searchThis[i] == searchFor[0]) || !IsMatch(searchThis, i, searchFor))
                    continue;

                list.Add(i);
            }

            return list.Count == 0 ? Empty : list.ToArray();
        }

        static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;

            for (int i = 0; i < candidate.Length; i++)
                if (array[position + i] != candidate[i])
                    return false;

            return true;
        }

        static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
        }
    }
}