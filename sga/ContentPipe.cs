﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace sga
{
	class ContentPipe
	{
		public static Texture2D LoadTexture(string path)
		{
			if (!File.Exists ("/home/wew/sga/sga/Content/" + path)) 
			{
				throw new FileNotFoundException ("file not found at Content/" + path);
			}
			int id = GL.GenTexture ();
			GL.BindTexture(TextureTarget.Texture2D,id);

			Bitmap bmp = new Bitmap ("/home/wew/sga/sga/Content/" + path);
			BitmapData data = bmp.LockBits(
				new Rectangle(0,0,bmp.Width,bmp.Height),
				ImageLockMode.ReadOnly,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			GL.TexImage2D (
				TextureTarget.Texture2D,
				0,
				PixelInternalFormat.Rgba,
				data.Width, data.Height,
				0,
				OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
				PixelType.UnsignedByte,
				data.Scan0);

			bmp.UnlockBits (data);

			GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
			GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

			GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
			GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

			return new Texture2D(id,bmp.Width,bmp.Height);
		}
	}
}

