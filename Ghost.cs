using Microsoft.Xna.Framework;
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

        public Ghost(List<Texture2D> textures, Rectangle location, SpriteEffects direction)
        {
            _textures = textures;
            _textureIndex = 0;
            _speed = Vector2.Zero;
            _location = location;
            _direction = SpriteEffects.None;            
        }

        public void Update(MouseState mouseState)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex], _location, null, Color.White, 0f, Vector2.Zero, _direction, 1);
        }

    }
}
