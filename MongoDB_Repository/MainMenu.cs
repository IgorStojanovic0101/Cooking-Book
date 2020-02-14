using Cooking.Models;
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
    public partial class MainMenu : Form
    {
        private Kuvar kuvar;
        public MainMenu(Kuvar k)
        {
            kuvar = k;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            dataGridView1.Columns["ObjectId"].Visible = false;
            dataGridView2.Columns["ObjectId2"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recept r = new Recept(kuvar,String.Empty);
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("CookingBook");
            var kuvariCollection = db.GetCollection<Kuvar>("kuvari");
            var collection = db.GetCollection<Recepts>("Recepts");
            var i = 1;

            dataGridView1.Rows.Clear();





            //svi radnici osim prva 2 rade u sektoru 1
            /* foreach (Recepts r in collection.FindAll())
             {
                 kuvar.Recepts.Add(new MongoDBRef("Recepts", kuvar.Id));

                 r.radnik = new MongoDBRef("kuvari", r.Id);

                 collection.Save(r);
                 kuvariCollection.Save(kuvar);
             }*/


            var query = Query.And(
                           (Query.EQ("ID_Kartice", kuvar.ID_Kartice.ToString())),
                           Query.EQ("sifra", kuvar.sifra.ToString())
                           );
            var sad = kuvariCollection.Find(query);
            if (sad.Count() == 1)
            {

                foreach (Kuvar r in sad)
                {
                           
            foreach (MongoDBRef radnikRef in r.Recepts)
                {
                    Recepts recept = db.FetchDBRefAs<Recepts>(radnikRef);
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                row.Cells[0].Value = i;
                row.Cells[1].Value = recept.naziv;
                row.Cells[2].Value = recept.Id;

                dataGridView1.Rows.Add(row);
                
                i++;
                    
                }
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                string tt = dataGridView1.Rows[e.RowIndex].Cells["ObjectId"].FormattedValue.ToString();
                Recept r = new Recept(kuvar,tt);
                r.Show();
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView2.CurrentRow.Selected = true;
                string tt = dataGridView2.Rows[e.RowIndex].Cells["ObjectId2"].FormattedValue.ToString();
                ReceptView r = new ReceptView(kuvar, tt);
                r.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("CookingBook");
            var kuvariCollection = db.GetCollection<Kuvar>("kuvari");
            var collection = db.GetCollection<Recepts>("Recepts");
            var i = 1;

            dataGridView2.Rows.Clear();







            var query = Query.And(
                           (Query.EQ("ID_Kartice", kuvar.ID_Kartice.ToString())),
                           Query.EQ("sifra", kuvar.sifra.ToString())
                           );
           

               

                    foreach (Recepts recept in collection.FindAll())
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();

                        row.Cells[0].Value = i;
                        row.Cells[1].Value = recept.naziv;
                        row.Cells[2].Value = recept.Id;

                        dataGridView2.Rows.Add(row);

                        i++;

                    }
                
            

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label3.Text = "Kuvar " + kuvar.ime + " " + kuvar.prezime;
        }
    }
}
