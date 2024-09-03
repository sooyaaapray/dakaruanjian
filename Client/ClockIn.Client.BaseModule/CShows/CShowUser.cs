using ClockIn.Client.Entity;
using System;
using System.Windows.Media;

namespace ClockIn.Client.BaseModule.CShows
{
    public class CShowUser:UserEntity
    {
        public char tag { get; set; }
        public Brush bcolor { get; set; }
    }
}
