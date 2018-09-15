using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaker2
{
    class AudioGroup
    {
        public List<byte[]> files = new List<byte[]>();

        public AudioGroup() { }
        
        public AudioGroup(string filename)
        {
            Read(filename);
        }

        public void Read(string filename)
        {
            using(BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                Read(reader);
            }
        }

        public void Read(BinaryReader f)
        {
            f.BaseStream.Seek(0x10, SeekOrigin.Begin);
            uint fileCount = f.ReadUInt32();
            List<uint> fileOffsets = new List<uint>();
            for (int i = 0; i < fileCount; i++)
                fileOffsets.Add(f.ReadUInt32());
            foreach(var offset in fileOffsets)
            {
                f.BaseStream.Seek(offset, SeekOrigin.Begin);
                uint size = f.ReadUInt32();
                files.Add(f.ReadBytes((int)size));
            }
        }

        public void Write(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                Write(writer);
            }
        }

        public void Write(BinaryWriter f)
        {
            List<uint> offsets = new List<uint>();
            uint pos = 0x14 + (0x4 * (uint)files.Count);
            foreach(var file in files)
            {
                offsets.Add(pos);
                pos += 0x4 + (uint)file.Length;
            }
            f.Write("FORM".ToCharArray());
            f.Write(pos - 0x8);
            f.Write("AUDO".ToCharArray());
            f.Write(pos - 0x10);
            f.Write(files.Count);
            foreach (var fileOffset in offsets)
            {
                f.Write(fileOffset);
            }
            foreach (var file in files)
            {
                f.Write(file.Length);
                f.Write(file);
            }
        }
    }
}
