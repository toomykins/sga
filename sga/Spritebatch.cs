using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace sga
{
	public class Spritebatch
	{
		public static void Draw(Texture2D texture,Vector2 position, Vector2 scale, Color color, Vector2 origin)
		{
			Vector2[] vertices = new Vector2[4] {
				new Vector2 (0, 0),
				new Vector2 (1, 0),
				new Vector2 (1, 1),
				new Vector2 (0, 1),
			};
			GL.BindTexture (TextureTarget.Texture2D, texture.ID);

			GL.Begin (PrimitiveType.Quads);

			GL.Color3 (color);
			for (int i = 0; i < 4; i++) {
				GL.TexCoord2 (vertices [i]);
				vertices[i].X *= texture.Width;
				vertices [i].Y *= texture.Height;
				vertices [i] -= origin;
				vertices [i] *= scale;
				vertices[i] += position;
				GL.Vertex2 (vertices [i]);
			}
			GL.End ();
		}
		public static void Begin(int screenWidth, int screenHeight)
		{
			GL.MatrixMode (MatrixMode.Projection);
			GL.LoadIdentity ();

			GL.Ortho ((float)-screenWidth / 2, (float)screenWidth / 2, (float)screenHeight / 2, (float)-screenHeight / 2, 0f, 1f);
		}
	}
}

