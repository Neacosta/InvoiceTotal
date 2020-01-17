﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmSalesTax : Form
    {
        public frmSalesTax()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                decimal Tax = Convert.ToDecimal(txtSalesTaxpct.Text);
                this.Tag = Tax;
                this.DialogResult = DialogResult.OK;
            }  
        }
        public bool IsValidData()
        {
            return
                IsPresent(txtSalesTaxpct, "Sales tax") &&
                IsDecimal(txtSalesTaxpct, "Sales tax") &&
                IsWithinRange(txtSalesTaxpct, "Sales tax", 0, 10);
        }
        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        public bool IsWithinRange(TextBox textBox, string name,
           decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number <= min || number >= max)
            {
                MessageBox.Show(name + " must be between " + min +
                    " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
