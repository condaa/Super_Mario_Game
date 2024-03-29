﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace training
{
    public class Animation
    {
        int frameCounter;
        int switchFrame;
        Vector2 position, amountofFrames, currentFrame;
        Texture2D Image;
        public Rectangle sourceRect;
        bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public Vector2 CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D AnimationImage
        {
            set { Image = value; }
        }

        public int FrameWidth
        {
            get { return Image.Width / (int)amountofFrames.X; }
        }

        public int FrameHeight
        {
            get { return Image.Height / (int)amountofFrames.Y; }
        }

        public void Initialize(Vector2 position, Vector2 Frames)
        {
            active = false;
            switchFrame = 20;
            this.position = position;
            this.amountofFrames = Frames;
        }

        public void Update(GameTime gameTime)
        {
            if (active)
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            else
                frameCounter = 0;
            if (frameCounter >= switchFrame)
            {
                frameCounter = 0;
                currentFrame.X = FrameWidth;
                if (currentFrame.X >= Image.Width)
                    currentFrame.X = 0;
            }
            sourceRect = new Rectangle((int)currentFrame.X, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, position, sourceRect, Color.White);
        }


    }
}
