using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Laboratorna_3_pz
{
    public partial class Form1 : Form
    {
        public int final_price = 0 ;

        public  Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            using var db = new Context();
            db.RemoveRange(db.Products_in_Basket);
            db.SaveChanges();

            update_list_product();
            update_list_basket();

        }
       
        public void update_list_product()
        {
            list_product.Items.Clear();
            using var db = new Context();
            foreach (var item in db.Products)
            {
                list_product.Items.Add(item.ProductId +" --- "+ item.Product_Name + " --- " + item.Product_Provider
                     + " --- " + item.Product_Number + " --- " + item.Product_Price);
            }
         
        }

        private void add_product_Click(object sender, EventArgs e)
        {
            using var db = new Context();   
            var product = new Product();
            try
            {
                product.ProductId = int.Parse(product_id.Text);
                product.Product_Name = product_name.Text;
                product.Product_Provider = product_provider.Text;
                product.Product_Number = int.Parse(product_number.Text);
                product.Product_Price = int.Parse(product_price.Text);
                try
                {
                    if (product.Product_Number >= 0 && product.Product_Price >= 0 && product.Product_Name.Length>0&&
                        product.Product_Provider.Length>0)
                    {
                        db.Add(product);
                        db.SaveChanges();
                        update_list_product();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("no");
                }

            }
            catch
            {
                MessageBox.Show("�� ��������� ��������� ����");
            }

        }

        private void update_product_Click(object sender, EventArgs e)
        {
            using var db = new Context();
            var product = db.Products.Find(int.Parse(product_id.Text));
            try
            {
                db.Products.Find(int.Parse(product_id.Text));

                    product.ProductId = int.Parse(product_id.Text);
                if(product_name.Text.Length >0)
                {
                product.Product_Name = product_name.Text;
                }
                else
                {
                    product.Product_Name = product.Product_Name;
                }
                if(product_provider.Text.Length > 0)
                {
                    product.Product_Provider = product_provider.Text;
                }
                else
                {
                    product.Product_Provider = product.Product_Provider;
                }
                if(product_number.Text.Length >0)
                {
                product.Product_Number = int.Parse(product_number.Text);

                }
                else
                {
                    product.Product_Number = product.Product_Number;
                }
                if(product_price.Text.Length > 0)
                {
                product.Product_Price = int.Parse(product_price.Text);
                }
                else
                {
                    product.Product_Price = product.Product_Price;
                }


                try
                {
                    if (product.Product_Number >= 0 && product.Product_Price >= 0)
                    {
                        db.Update(product);
                        db.SaveChanges();
                        update_list_product();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("no");
                }


                //db.Update(product);
                //db.SaveChanges();
                //update_list_product();
            }
            catch
            {
                MessageBox.Show("�� ��������� ��������� ����");
            }
        }

        private void del_product_Click(object sender, EventArgs e)
        {
            using var db = new Context();
            try
            {
                db.Remove(db.Products.Find(int.Parse(product_id_del.Text)));
                db.SaveChanges();
                update_list_product();
            }
            catch
            {
                MessageBox.Show("�� ��������� ��������� ����");
            }
        }
       
        private void buy_product_Click(object sender, EventArgs e)
        {
            using var db = new Context();

            try
            {
                var product = db.Products.Find(int.Parse(product_id_buy.Text));
                var basket = new Basket { 
                    Id = int.Parse(product_id_buy.Text),
                    Product_Number = int.Parse(product_number_buy.Text),
                    Product_Name = product.Product_Name,
                    Product_Provider = product.Product_Provider,
                    Product_Price = product.Product_Price,
                 };

                try
                {
                    if (basket.Product_Number<= product.Product_Number && basket.Product_Number>=1) 
                    {
                        db.Add(basket);
                        db.SaveChanges();
                        update_list_basket();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show($"�� ����� �� �� {basket.Product_Number} , {basket.Product_Name}"); ;
                }

            }
            catch
            {
                MessageBox.Show("�� ��������� ��������� ����");
            }


        }

        private void update_list_basket()
        {
            basket.Items.Clear();
            final_price = 0;
            using var db = new Context();
            foreach (var item in db.Products_in_Basket)
            {
                basket.Items.Add(item.Id + " --- " + item.Product_Name + " --- " + item.Product_Provider
                     + " --- " + item.Product_Number + " --- " + item.Product_Price + " ������� " + item.Product_Number*item.Product_Price);
                final_price +=(item.Product_Number * item.Product_Price);
            }
            final_price_text.Text = $"�������� ���� : {final_price}";
        }

        private void update_product_buy_Click(object sender, EventArgs e)
        {
            using var db = new Context();
            var basket = db.Products_in_Basket.Find(int.Parse(product_id_buy.Text));
            var product = db.Products.Find(int.Parse(product_id_buy.Text));
            try
            {

                basket.Id = int.Parse(product_id_buy.Text);
                basket.Product_Number = int.Parse(product_number_buy.Text);
                basket.Product_Name = basket.Product_Name;
                basket.Product_Provider = basket.Product_Provider;
                basket.Product_Price = basket.Product_Price;
                try
                {
                    if (basket.Product_Number<=product.Product_Number&& basket.Product_Number >=1)
                    {

                        db.Update(basket);
                db.SaveChanges();
                update_list_basket();

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show($"�� ����� �� �� {basket.Product_Number} , {basket.Product_Name}"); ;
                }


            }
            catch
            {
                MessageBox.Show("�� ��������� ��������� ����");
            }
        }

        private void del_product_in_basket_Click(object sender, EventArgs e)
        {
            using var db = new Context();
            try
            {
                db.Remove(db.Products_in_Basket.Find(int.Parse(product_id_buy.Text)));
                db.SaveChanges();
                update_list_basket();
            }
            catch
            {
                    MessageBox.Show("�� ��������� ��������� ����");
            }
        }

        private void buy_all_Click(object sender, EventArgs e)
        {

            if(final_price > 0)
            {
            var form = new Form2();
            form.ShowDialog();
           // buy();
       //     basket.Items.Clear();
                update_list_product();
            }
            else
            {
                MessageBox.Show("����� ������");
            }

        }

        public void buy()
        {

            using var db = new Context();
            foreach (var item in db.Products_in_Basket)
            {

                var product = db.Products.Find(item.Id);
                product.Product_Number -= item.Product_Number;
                db.Update(product);
                db.SaveChanges();
                update_list_product();

            }
            update_list_product();
        }

    }
}