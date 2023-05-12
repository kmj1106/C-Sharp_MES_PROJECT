using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public enum PriodType { OneDay, ThreeDay, OneWeek, OneMonth, ThreeMonth, SixMonth }

    public partial class PeriodUserControl : UserControl
    {
        public PriodType Period 
        { 
            set
            {
                comboBox1.SelectedIndex = (int)value;
            }
        }

        public string From
        {
            get { return dateTimePicker1.Value.ToShortDateString(); }
        }

        public string To
        {
            get { return dateTimePicker2.Value.ToShortDateString(); }
        }

        public PeriodUserControl()
        {
            InitializeComponent();
        }

        private void PeriodUserControl_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            switch (comboBox1.Text)
            {
                case "1일":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-1); break;
                case "3일":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-3); break;
                case "1주일":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-7); break;
                case "1개월":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1); break;
                case "3개월":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-3); break;
                case "6개월":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-6); break;
            }
        }
    }
}
