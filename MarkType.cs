﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// The type of a value in cell in the game is currently at
    /// </summary>

    public enum MarkType
    {
        /// <summary>
        /// The cell has not been clicked yet
        /// </summary>
        Free,
        /// <summary>
        /// The cell is a O
        /// </summary>
        Nought,
        /// <summary>
        /// The cell is a X
        /// </summary>
        Cross
    }
}
