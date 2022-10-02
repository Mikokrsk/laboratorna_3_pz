namespace Laboratorna_3_pz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_list_product();
        }

        private void update_list_product()
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
                db.Add(product);
                db.SaveChanges();
                update_list_product();
            }
            catch
            {
                MessageBox.Show("Не правильно заповнені поля");
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
                product.Product_Name = product_name.Text;
                product.Product_Provider = product_provider.Text;
                product.Product_Number = int.Parse(product_number.Text);
                product.Product_Price = int.Parse(product_price.Text);

                db.Update(product);
                db.SaveChanges();
                update_list_product();
            }
            catch
            {
                MessageBox.Show("Не правильно заповнені поля");
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
                MessageBox.Show("Не правильно заповнені поля");
            }
        }
        //sdgs
        private void buy_product_Click(object sender, EventArgs e)
        {
    


        }

        private void update_product_buy_Click(object sender, EventArgs e)
        {

        }

        private void del_product_in_basket_Click(object sender, EventArgs e)
        {

        }


        private void buy_button_Click(object sender, EventArgs e)
        {
            //using var db = new Context();
            //var product = new Product();
            //try
            //{
            //    product.ProductId = int.Parse(product_id.Text);
            //    product.Product_Name = product_name.Text;
            //    product.Product_Provider = product_provider.Text;
            //    product.Product_Number = int.Parse(product_number.Text);
            //    product.Product_Price = int.Parse(product_price.Text);
            //    db.Add(product);
            //    db.SaveChanges();
            //    update_list_product();
            //}
            //catch
            //{
            //    MessageBox.Show("Не правильно заповнені поля");
            //}
        }


    }
}