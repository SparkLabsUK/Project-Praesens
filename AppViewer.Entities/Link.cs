using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities
{
    public class Link
    {
        public int LinkID { get; set; }
        public int PageID { get; set; }
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Enums.Transition Transition { get; set; }
        public int ToPageID { get; set; }

        public string LinkName
        {
            get
            {
                return String.Format("{0}: {1}x{2} w:{3} h:{4}", LinkID, Xcoordinate, Ycoordinate, Width, Height);
            }
        }

        public int TransitionAsInt
        {
            get
            {
                return (int)Transition;
            }
        }
    }
}
