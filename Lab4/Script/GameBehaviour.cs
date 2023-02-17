using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
        private int _playerHP = 10;
        public int HP
        {
            get { return _playerHP; }
            set
            {
                _playerHP = value;
                Debug.LogFormat("Lives: {0}", _playerHP);
            }
        }
        void OnGUI()
        {
            GUI.Box(new Rect(90, 50, 170, 85), "Player Health: " + _playerHP);
        }

    }
