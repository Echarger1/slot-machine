﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        Random random = new Random();
        
        private int _numberofslots;
        public int NumberOfSlots {
            get
            {
                return _numberofslots;
            }
            set
            {
                _numberofslots = value;
                icons = new int[_numberofslots];
            }
                }

        public int Icons { get; set; }
        public int MinimumBet { get; set; }
        public int MaximumBet { get; set; }
        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;
                if (_currentBet < MinimumBet)
                {
                    _currentBet = MinimumBet;
                }
                if (_currentBet > MaximumBet)
                {
                    _currentBet = MaximumBet;
                }
            }
        }

        /// <summary>
        /// An array of integers that is as long as the number of slots,
        /// with each element of the array representing a different slot
        /// </summary>
        private int[] icons;


        public SlotMachine()
        {
            NumberOfSlots =3;
            Icons = 5;
            MinimumBet = 1;
            MaximumBet = 100;
            
        }

        /// <summary>
        /// Randomizes the contents of the icons
        /// </summary>
        public void PullLever()
        {
            
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i] = random.Next(1, Icons + 1);
            }
            
        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {
            return icons;
        }

        /// <summary>
        /// Examine the contents of the slots and determine the appropriate payout
        /// based upon the CurrentBet.
        /// </summary>
        /// <returns>number of pennies to pay out</returns>
        public int GetPayout()
        {
            int slot1 = icons[0];
            int payout = 0;
            int count = 0;
            for (int i = 1; i < icons.Length; i++)
            {
                if (icons[i] == slot1)
                {
                    count++;
                }

            }
            if (count == icons.Length - 1)
            {
                payout = slot1 * CurrentBet * 99999999;
            }
           //if (Array.TrueForAll(icons, i => i == slot1))
           // {
           //     payout = slot1 * CurrentBet * 999999999;
           // }

            return payout;
        }
    }
}
