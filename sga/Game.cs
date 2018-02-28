using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace sga
{
	class Game : GameWindow
	{
		Texture2D texture;
		View view;


		public Game (int width, int height) : base(width,height)
		{
			GL.Enable (EnableCap.Texture2D);
			view = new View (Vector2.Zero, 1.0, 0.0);



			Mouse.ButtonDown += Mouse_ButtonDown;
		}

		void Mouse_ButtonDown (object sender, OpenTK.Input.MouseButtonEventArgs e)
		{
			Vector2 pos = new Vector2 (e.Position.X, e.Position.Y);
			pos -= new Vector2 (this.Width, this.Height) / 2f;
			pos = view.ToWorld (pos);

			view.SetPosition (pos, TweenType.Linear, 60);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			texture = ContentPipe.LoadTexture ("catshit.jpg");

		}
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame (e);


			view.update ();
		}
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			base.OnRenderFrame(e);
			GL.Clear (ClearBufferMask.ColorBufferBit);
			GL.ClearColor (Color.CornflowerBlue);

			Spritebatch.Begin (this.Width, this.Height);
			view.ApplyTransform ();

			Spritebatch.Draw (texture, Vector2.Zero, new Vector2(1f,1f), Color.Green, new Vector2 (10, 50));




			this.SwapBuffers ();
		}

	}
}

