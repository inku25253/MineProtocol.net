namespace LibMinecraft
{
	public struct Vector2
	{

		public Vector2 Zero
		{
			get { return new Vector2(0, 0); }
		}
		public Vector2 UpX
		{
			get { return new Vector2(1, 0); }
		}
		public Vector2 UpY
		{
			get { return new Vector2(0, 1); }
		}

		public double X;
		public double Y;

		public Vector2(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X + b.X, a.Y + b.Y);
		}

		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X - b.X, a.Y - b.Y);
		}

		public static Vector2 operator *(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X * b.X, a.Y * b.Y);
		}
		public static Vector2 operator /(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X / b.X, a.Y / b.Y);
		}

	}
}