namespace Laboratorna_3_pz
{
    public partial class Form1 : Form
    {
        public int final_price = 0 ;

        public Form1()
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
                db.Add(basket);
                db.SaveChanges();
                update_list_basket();
            }
            catch
            {
                MessageBox.Show("Не правильно заповнені поля");
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
                     + " --- " + item.Product_Number + " --- " + item.Product_Price + " загалом " + item.Product_Number*item.Product_Price);
                final_price +=(item.Product_Number * item.Product_Price);
            }
            final_price_text.Text = $"Загальна ціна : {final_price}";
        }

        private void update_product_buy_Click(object sender, EventArgs e)
        {
            using var db = new Context();
            var basket = db.Products_in_Basket.Find(int.Parse(product_id_buy.Text));
            try
            {

                //  var product = db.Products_in_Basket.Find(int.Parse(product_id_buy.Text));

                basket.Id = int.Parse(product_id_buy.Text);
                basket.Product_Number = int.Parse(product_number_buy.Text);
                basket.Product_Name = basket.Product_Name;
                basket.Product_Provider = basket.Product_Provider;
                basket.Product_Price = basket.Product_Price;
                
                db.Update(basket);
                db.SaveChanges();
                update_list_basket();
            }
            catch
            {
                MessageBox.Show("Не правильно заповнені поля");
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
                    MessageBox.Show("Не правильно заповнені поля");
            }
        }


        private void buy_all_Click(object sender, EventArgs e)
        {
            using var db = new Context();
            foreach (var item in db.Products_in_Basket)
            {

                // var product = db.Products;//.Find(int.Parse(product_id.Text));
                //try
                //{
                 var product =  db.Products.Find(item.Id);
                listBox1.Items.Add(product.ProductId);
                    //product.ProductId = int.Parse(product_id.Text);
                    //product.Product_Name = product_name.Text;
                    //product.Product_Provider = product_provider.Text;
                    product.Product_Number -= item.Product_Number;
                    //product.Product_Price = int.Parse(product_price.Text);

                    db.Update(product);
                    db.SaveChanges();
                   update_list_product();
         //       }
              }
            //catch
            //{
            //    MessageBox.Show("Не правильно заповнені поля");
            //}
            MessageBox.Show($"До сплати : {final_price} грн" );
            MessageBox.Show($"Дякуємо за покупку");
        }


    }
}