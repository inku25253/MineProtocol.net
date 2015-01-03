namespace LibMinecraft
{
	public struct Vector3
	{
		public static Vector3 Zero
		{
			get { return new Vector3(0, 0, 0); }
		}
		public static Vector3 UpX
		{
			get { return new Vector3(1, 0, 0); }
		}
		public static Vector3 UpY
		{
			get { return new Vector3(0, 1, 0); }
		}

		public static Vector3 UpZ
		{
			get { return new Vector3(0, 0, 1); }
		}

		public double X;
		public double Y;
		public double Z;

		public Vector3(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static Vector3 operator +(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public static Vector3 operator -(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		public static Vector3 operator *(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
		}
		public static Vector3 operator /(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
		}

	}
}