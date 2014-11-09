using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMinecraft
{
	public class MinecraftStream : Stream
	{
		private Stream baseStream;
		public Stream BaseStream { get { return baseStream; } }
		public Encoding StringEncode { get; set; }

		public MinecraftStream()
			: this(new MemoryStream())
		{
		}
		public MinecraftStream(Stream @base)
			: this(@base, new UTF8Encoding())
		{
		}
		public MinecraftStream(Stream @base, Encoding encode)
		{
			this.baseStream = @base;
			this.StringEncode = encode;
		}



		#region Streamメンバ
		public override bool CanRead
		{
			get { return this.baseStream.CanRead; }
		}

		public override bool CanSeek
		{
			get { return this.baseStream.CanSeek; }
		}

		public override bool CanWrite
		{
			get { return this.baseStream.CanWrite; }
		}

		public override void Flush()
		{
			this.baseStream.Flush();
		}

		public override long Length
		{
			get { return this.baseStream.Length; }

		}

		public override long Position
		{
			get
			{
				return this.baseStream.Position;
			}
			set
			{
				if (CanSeek == false)
					throw new NotSupportedException();
				this.baseStream.Position = value;
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.CanRead == false)
				throw new NotSupportedException();
			return this.baseStream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			if (this.CanSeek == false)
				throw new NotSupportedException();
			return this.baseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this.baseStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.CanWrite == false)
				throw new NotSupportedException();
			this.baseStream.Write(buffer, offset, count);
		}
		#endregion


		public void Write(byte value)
		{
			this.baseStream.WriteByte(value);
		}
		public void Write(byte[] value)
		{
			this.Write(value, 0, value.Length);
		}
		public void Write(bool value)
		{
			this.Write((byte)(value ? 0x01 : 0x00));
		}
		public void Write(short value)
		{
			this.Write((ushort)value);
		}
		public void WriteInt32(int value)
		{
			this.Write((uint)value);
		}
		public void Write(long value)
		{
			this.Write((ulong)value);
		}

		public void Write(ushort value)
		{
			byte[] bValue = new byte[] { 
				(byte)((value & 0xFF00) >> 1 * 8), 
				(byte)((value & 0x00FF) >> 0 * 8) 
			};
			this.Write(bValue);
		}
		public void Write(uint value)
		{
			byte[] bValue = new byte[] {
				(byte)((value & 0xFF000000) >> 3 * 8), 
				(byte)((value & 0x00FF0000) >> 2 * 8), 
				(byte)((value & 0x0000FF00) >> 1 * 8), 
				(byte)((value & 0x000000FF) >> 0 * 8) 
			 };
			this.Write(bValue);
		}
		public void Write(ulong value)
		{
			byte[] bValue = new byte[]{
				(byte)(((ulong)value & 0xFF00000000000000) >> 7 * 8), 
				(byte)(((ulong)value & 0x00FF000000000000) >> 6 * 8), 
				(byte)(((ulong)value & 0x0000FF0000000000) >> 5 * 8), 
				(byte)(((ulong)value & 0x000000FF00000000) >> 4 * 8),
				(byte)(((ulong)value & 0x00000000FF000000) >> 3 * 8), 
				(byte)(((ulong)value & 0x0000000000FF0000) >> 2 * 8), 
				(byte)(((ulong)value & 0x000000000000FF00) >> 1 * 8), 
				(byte)(((ulong)value & 0x00000000000000FF) >> 0 * 8) 
			};
			this.Write(bValue);
		}

		public unsafe void Write(float value)
		{
			this.Write(*(uint*)&value);
		}
		public unsafe void Write(double value)
		{
			this.Write(*(ulong*)&value);
		}

		public void Write(string value)
		{
			byte[] bValue = this.StringEncode.GetBytes(value);

			this.Write(bValue.Length);
			this.Write(bValue);
		}

		public void Write(Metadata value)
		{
			//TODO: 
			throw new NotImplementedException();
		}


		public void Write(SlotData value)
		{
			//TODO: 
			throw new NotImplementedException();
		}

		public void Write(Guid guid)
		{
			this.Write(guid.ToByteArray());
		}


		public void Write(int value)
		{
			this.WriteVarlong(value);
		}
		public void WriteVarlong(long value)
		{
			while ((value & 0xFFFFFF80) != 0)
			{
				this.Write((byte)(value & 0x7F | 0x80));
				value >>= 7;
			}
			this.Write((byte)value);

		}
		public static int GetVarintSize(int value)
		{
			if ((value & -128) == 0)
				return 1;
			else if ((value & -16384)== 0)
				return 2;
			else if ((value & -2097152) == 0)
				return 3;
			else if ((value & -268435456) == 0)
				return 4;
			else return 5;
		}

		public static byte[] GetVarintBytes(int value)
		{
			int size = GetVarintSize(value);
			byte[] result = new byte[size];
			int i = 0;
			while ((value & 0xFFFFFF80) != 0)
			{
				result[i++] = (byte)(value & 0x7F | 0x80);
				value >>= 7;
			}
			result[i++] = (byte)value;
			return result;
		}






		public byte[] Read(int length)
		{
			byte[] result  = new byte[length];
			this.Read(result, 0, length);
			return result;
		}
		public void Read(byte[] result)
		{
			this.Read(result, 0, result.Length);
		}
		public bool ReadBool()
		{
			return this.ReadByte() == 0x01;
		}
		public short ReadInt16()
		{
			return (short)this.ReadUInt16();
		}
		public int ReadInt32()
		{
			return (int)this.ReadUInt32();

		}
		public long ReadInt64()
		{
			return (long)this.ReadUInt64();
		}
		public ushort ReadUInt16()
		{
			return (ushort)(
				this.ReadByte() << 1 * 8 |
				this.ReadByte() << 0 * 8
			);
		}
		public uint ReadUInt32()
		{
			return (uint)(
				this.ReadByte() << 3 * 8 |
				this.ReadByte() << 2 * 8 |
				this.ReadByte() << 1 * 8 |
				this.ReadByte() << 0 * 8
			);
		}
		public ulong ReadUInt64()
		{
			return unchecked(
				(ulong)this.ReadByte() << 7 * 8 |
				(ulong)this.ReadByte() << 6 * 8 |
				(ulong)this.ReadByte() << 5 * 8 |
				(ulong)this.ReadByte() << 4 * 8 |
				(ulong)this.ReadByte() << 3 * 8 |
				(ulong)this.ReadByte() << 2 * 8 |
				(ulong)this.ReadByte() << 1 * 8 |
				(ulong)this.ReadByte() << 0 * 8
			);
		}

		public unsafe float ReadSingle()
		{
			uint ifloat = this.ReadUInt32();
			return (*(float*)&ifloat);
		}
		public unsafe double ReadDouble()
		{
			ulong ldouble = this.ReadUInt64();
			return (*(double*)&ldouble);
		}
		public string ReadString()
		{
			int length = ReadVarint();

			byte[] utfData = this.Read(length);

			return this.StringEncode.GetString(utfData);

		}
		public Metadata ReadMetadata()
		{
			//TODO: 
			throw new NotImplementedException();
		}
		public SlotData ReadSlotData()
		{
			//TODO: 
			throw new NotImplementedException();
		}
		public Guid ReadGuid()
		{
			byte[] rawGuid = this.Read(16);
			return new Guid(rawGuid);
		}




		public int ReadVarint()
		{
			int i = 0, j = 0;

			byte c;

			do
			{
				c = (byte)this.ReadByte();
				i |= (c & 127) << j++ * 7;

				if (j > 5)
				{
					throw new OverflowException();
				}
			} while ((c & 128) == 128);

			return i;
		}
		public long ReadVarlong()
		{
			long i = 0;
			int j = 0;

			byte c;

			do
			{
				c = (byte)this.ReadByte();
				i |= (long)(c & 127) << j++ * 7;

				if (j > 9)
				{
					throw new OverflowException();
				}
			} while ((c & 128) == 128);

			return i;
		}

	}
}
