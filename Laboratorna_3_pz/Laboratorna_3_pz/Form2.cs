using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorna_3_pz;

namespace Laboratorna_3_pz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (check(int.Parse(textBox1.Text), int.Parse(textBox2.Text)))
                {

                    using var db = new Context();
                    foreach (var item in db.Products_in_Basket)
                    {

                        var product = db.Products.Find(item.Id);
                        product.Product_Number -= item.Product_Number;
                        db.Update(product);
                        db.SaveChanges();
                    }
                    if(checkBox1.Checked == false)
                    Client_Order.ClientCode(new Work_Drink1());
                    else
                    Client_Order.ClientCode(new Work_Drink2());
                    MessageBox.Show("Замовлення відправлено");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("номер картки або пін код невірні");
                }
            }
            catch
            {
                MessageBox.Show("номер картки або пін код невірні");
            }
            
        }
        public bool check(int card , int code)
        {
            int cardNumber = 12345;
            int cardCode = 1234;
            if(cardNumber==card && cardCode==code)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
