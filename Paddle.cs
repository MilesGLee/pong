﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Pong
{
    class Paddle : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private bool _player;
        private Vector2 _c1;
        private Vector2 _c2;
        private Vector2 _c3;
        private Vector2 _c4;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Paddle(char icon, float x, float y, float speed, Color color, bool player, string name = "Paddle")
            : base(icon, x, y, speed, color, name)
        {
            _speed = speed;
            _player = player;
        }



        public override void Update(float deltaTime)
        {
            int yDiretion = 0;
            //get the player input direction
            if (_player == false)
            {
                yDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));
            }
            else 
            {
                yDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));
            }

            //Create a vector tht stores the move input
            //Vector2 moveDirection = new Vector2(xDiretion, yDiretion);
            Vector2 moveDirection = new Vector2(0, yDiretion);

            //caculates the veclocity 
            Velocity = moveDirection.Normalized * Speed * deltaTime;

            base.Update(deltaTime);
            //moves the player
            Position += Velocity;

        }

        public override void OnCollision(Actor actor)
        {

        }
    }
}
