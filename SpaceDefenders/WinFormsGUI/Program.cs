using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsGUI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
           var form = new GameForm();
           Application.Run(form);
        }
    }
}
