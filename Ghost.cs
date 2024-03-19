﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_More_Classes
{
    public class Ghost
    {
        List<Texture2D> _textures;
        int _textureIndex;
        Vector2 _speed;
        Rectangle _location;
        SpriteEffects _direction;
        float _animationSpeed;
        float _seconds;
        float _opacity;


        public Ghost(List<Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _textureIndex = 0;
            _speed = Vector2.Zero;
            _location = location;
            _direction = SpriteEffects.None;
            _opacity = 1f;
            _animationSpeed = 0.2f;
        }

        public void Update(GameTime gameTime ,MouseState mouseState)
        {

            // Calculates horizontal speed and direction sprite should face
            _speed = Vector2.Zero;
            if (mouseState.X < _location.X)
            {
                _direction = SpriteEffects.FlipHorizontally;
                _speed.X = -1f;
            }
            else if (mouseState.X > _location.X)
            {
                _direction = SpriteEffects.None;
                _speed.X = 1f;

            }     

            // Calculates vertical speed
            if (mouseState.Y < _location.Y)
                _speed.Y = -1f;
            else if (mouseState.Y > _location.Y)
                _speed.Y = 1f;

            // Only move if the mouse button is down
            if (mouseState.LeftButton == ButtonState.Released)
            {
                _speed = Vector2.Zero; // Sets speed to zero if mouse not clicked
                _textureIndex = 0;
                _seconds = 0f;
                _opacity = 0.5f;
            }
            else if (_speed != Vector2.Zero) // Ghost is moving
            {
                _opacity = 1f;
                _seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_seconds > _animationSpeed)
                {
                    _seconds = 0;
                    _textureIndex++;
                    if (_textureIndex >= _textures.Count)
                        _textureIndex = 1;
                }
            }
            
            _location.Offset(_speed);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex], _location, null, Color.White * _opacity, 0f, Vector2.Zero, _direction, 1);
        }

    }
}
