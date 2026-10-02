using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frist_a_project_my_in_C_
{

   

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            RemoveGroupBoxBorders(this);
        }


        private void RemoveGroupBoxBorders(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is GroupBox)
                {
                    GroupBox gb = (GroupBox)ctrl;

                    gb.BackColor = this.BackColor;
                    gb.ForeColor = Color.FromArgb(26, 60, 52);
                    gb.Text = "";
                }

                if (ctrl.HasChildren)
                {
                    RemoveGroupBoxBorders(ctrl);
                }
            }
        }

        float CalculateToppingsPrice()
        {
         float ToppingsTotalPrice = 0;

            if (chkExtraChees.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChees.Tag);
            }
            if (chkMushrooms.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }
            if (chkOnion.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            }
            if (chkTomatoes.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }
            if (chkGreenPeppers.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }
            return ToppingsTotalPrice;
        }
        float GetSelectedSizePrice()
            {
            if (rdBtnSmall.Checked)
                return Convert.ToSingle(rdBtnSmall.Tag);

            if (rdBtnMeduim.Checked)
                return Convert.ToSingle(rdBtnMeduim.Tag);

            if (rdBtnLarg.Checked)
                return Convert.ToSingle(rdBtnLarg.Tag);

            return 0;
        }
        void UpdateSize()
        {
            UpdateTotalPrice();
            if (rdBtnSmall.Checked)
            {
                lbSize.Text = " Small";
                return;
            }
            if (rdBtnMeduim.Checked)
            {
                lbSize.Text = " Meduim";
                return;
            }
            if (rdBtnLarg.Checked)
            {
                lbSize.Text = " Large";
                return;
            }
        }
        float GetSelectedCrutPrice()
        {
            if (rdBtnThinCrust.Checked)
                return Convert.ToSingle(rdBtnThinCrust.Tag);
            else
            {
                return Convert.ToSingle(rdBtnThinKCrust.Tag);
            }


        }
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrutPrice();
        }
        void UpdateTotalPrice()
        {           
         lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();

        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rdBtnThinCrust.Checked)
            {
                lbCrust.Text = "  ThinCrust  ";
                return;
            }
            if (rdBtnThinKCrust.Checked)
            {
                lbCrust.Text = " ThinkCrust ";
                return;
            }


        }
        void UpdateWhere()
        {
            UpdateTotalPrice();
            if (rdBtnTakeOut.Checked)
            {
                lbWhere.Text = " TakeOut";
                return;
            }
            if (rdBtnEatin.Checked)
            {
                lbWhere.Text = " Eat in";
                return;
            }


        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";
            if (chkExtraChees.Checked)
            {
                sToppings = "Extra Chees";
            }
                
            if (chkOnion.Checked)
                sToppings += ",Onion";

            if (chkMushrooms.Checked)
            {
                sToppings += "Mushrooms";
            }
                
              if (chkOlives.Checked)
              {
                sToppings += ", Olives";
              }
            if (chkTomatoes.Checked)

                sToppings += ", Tomatos";

            if (chkGreenPeppers.Checked)
                sToppings += ", Green Peppars";

            if (sToppings.StartsWith(", "))
                
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();

            if (sToppings == "")
                sToppings = "No Toppings";

            lbToppings.Text = sToppings;





        }


       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void rdBtnSmall_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();
        }

        private void rdBtnMeduim_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();
        }

        private void rdBtnLarg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }   

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }
        private void lbToppings_Click(object sender, EventArgs e)
        {

        }

        private void rdBtnThinCrust_CheckedChanged(object sender, EventArgs e)
        {

            UpdateCrust();
        }

        private void rdBtnThinKCrust_CheckedChanged(object sender, EventArgs e)
        {

            UpdateCrust();


        }

        private void rdBtnEatin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhere();
        }

        private void rdBtnTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhere();
        }


        private void rdOrderPizza_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOrderPizza.Checked)
            {
                if (MessageBox.Show("Confirm Order", "Confirm",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Order Placed Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    grpSize.Enabled = false;
                    grpCrustType.Enabled = false;
                    grpToppings.Enabled = false;
                    grpTotal.Enabled = false;
                    grpwheretoEat.Enabled = false;
                    rdOrderPizza.Checked = false;
                }
                else
                {
                    rdOrderPizza.Checked = false;
                }
            }
        }
        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void rdResetfrom_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpTotal_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
