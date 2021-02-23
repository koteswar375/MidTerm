using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidTerm
{
    public partial class MagicSquare : Form
    {
        Button buttonBeingDragged;
        public MagicSquare()
        {
            InitializeComponent();
            ComputeSumOfAllLabels();
        }


        private void ComputeSumOfAllLabels()
        {
            CalculateSumOfRow1();
            CalculateSumOfRow2();
            CalculateSumOfRow3();
            CalculateSumOfCol1();
            CalculateSumOfCol2();
            CalculateSumOfCol3();
            CalculateSumOfTopleftdiagonal();
            CalculateSumOfBottomLeftDiagonal();
        }

        #region sum computation
        private void CalculateSumOfRow1()
        {
            row1sum.Text = Convert.ToString(Convert.ToInt32(row1col1.Text) + Convert.ToInt32(row1col2.Text) +
                Convert.ToInt32(row1col3.Text));
        }

        private void CalculateSumOfRow2()
        {
            row2sum.Text = Convert.ToString(Convert.ToInt32(row2col1.Text) + Convert.ToInt32(row2col2.Text) +
                Convert.ToInt32(row2col3.Text));
        }

        private void CalculateSumOfRow3()
        {
            row3sum.Text = Convert.ToString(Convert.ToInt32(row3col1.Text) + Convert.ToInt32(row3col2.Text) +
                Convert.ToInt32(row3col3.Text));
        }

        private void CalculateSumOfCol1()
        {
            col1sum.Text = Convert.ToString(Convert.ToInt32(row1col1.Text) + Convert.ToInt32(row2col1.Text) +
                Convert.ToInt32(row3col1.Text));
        }

        private void CalculateSumOfCol2()
        {
            col2sum.Text = Convert.ToString(Convert.ToInt32(row1col2.Text) + Convert.ToInt32(row2col2.Text) +
                Convert.ToInt32(row3col2.Text));
        }

        private void CalculateSumOfCol3()
        {
            col3sum.Text = Convert.ToString(Convert.ToInt32(row1col3.Text) + Convert.ToInt32(row2col3.Text) +
                Convert.ToInt32(row3col3.Text));
        }

        private void CalculateSumOfTopleftdiagonal()
        {
            topleftdiagonal.Text = Convert.ToString(Convert.ToInt32(row1col1.Text) + Convert.ToInt32(row2col2.Text) +
                Convert.ToInt32(row3col3.Text));
        }

        private void CalculateSumOfBottomLeftDiagonal()
        {
            bottomleftdiagonal.Text = Convert.ToString(Convert.ToInt32(row3col1.Text) + Convert.ToInt32(row2col2.Text) +
                Convert.ToInt32(row1col3.Text));
        }
        #endregion

        #region MouseDown Handlers
        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            buttonBeingDragged = button;
            button.DoDragDrop(button.Text, DragDropEffects.Copy);
        }

        #endregion


        #region DragEnter Handler
        private void DragEnterHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion


        #region DragDrop Handler
        private void DragDropHandler(object sender, DragEventArgs e)
        {
            Button button = sender as Button;
            buttonBeingDragged.Text = button.Text;
            button.Text = e.Data.GetData(DataFormats.Text).ToString();
            ComputeSumOfAllLabels();
        }

        #endregion


    }
}
