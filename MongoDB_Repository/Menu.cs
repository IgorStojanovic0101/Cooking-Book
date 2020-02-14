using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cooking
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("CookingBook");


            var collection = db.GetCollection<Kuvar>("kuvari");
            var query = Query.And(
                           (Query.EQ("ID_Kartice", id_card.Text.ToString())),
                           Query.EQ("sifra", sifra.Text.ToString())
                           );
            var sad= collection.Find(query);
           if( sad.Count() == 1)
            {

                foreach (Kuvar r in sad)
                {
                    MainMenu m = new MainMenu(r);
                    m.Show();
                   
                }
            }
           else
            {
                MessageBox.Show("Pogresni kredencijali");
            }

          

        }
    }
}
