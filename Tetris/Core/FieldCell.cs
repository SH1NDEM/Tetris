using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Core
{
    internal class FieldCell
    {
        int coordinateX_;
        int coordinateY_;

        bool isFill_;

        public int CoordinateX 
        { 
            get { return coordinateX_; } 
            set 
            { 
                if (value > 0 && value <= 20) 
                { 
                    coordinateX_ = value; 
                } 
            }
        }
        public int CoordinateY 
        { 
            get { return coordinateY_; }
            set
            {
                if (value > 0 && value <= 10)
                {
                    coordinateY_ = value;
                }
            }
        }

        public bool IsFill
        { 
            get { return isFill_; }
            set { isFill_ = value; }
        }
    }
}
