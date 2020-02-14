using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cooking
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void registerDoctorOrSister_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("CookingBook");


            var collection = db.GetCollection<Kuvar>("kuvari");
            Kuvar k = new Kuvar();
            k.ime = name.Text.ToString();
            k.prezime = surname.Text.ToString();
            k.ID_Kartice = IdCard.Text.ToString();
            k.sifra = password.Text.ToString();

            collection.Insert(k);

            this.Close();

        }
    }
}
