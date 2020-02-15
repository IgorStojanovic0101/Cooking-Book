using Cooking.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Cooking
{
    public partial class ReceptView : Form
    {
        private string sFileName;
        private BsonValue fileId;
        private MongoGridFSFileInfo UploadedFile;
        private string Id;
        private string newFileName = System.IO.Directory.GetCurrentDirectory();

        public Kuvar kuvar;
        public ReceptView(Kuvar k, string id)
        {
            kuvar = k;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Id = id;

            Inicialize(id);
        }
        public void Inicialize(string id)
        {
            if (id != String.Empty)
            {
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var db = server.GetDatabase("CookingBook");
                var kuvariCollection = db.GetCollection<Kuvar>("kuvari");
                var collection = db.GetCollection<Recepts>("Recepts");
                ObjectId objectId = new ObjectId(id);
                var query = Query.And(
                             (Query.EQ("_id", objectId))

                             );
                var recept = collection.Find(query);
                if (recept.Count() == 1)
                {
                    foreach (Recepts r in recept)
                    {
                        naziv.Text = r.naziv;
                        opis.Text = r.opis;
                        zacini.Text = r.zacini;
                        Kuvar KUVA = db.FetchDBRefAs<Kuvar>(r.radnik);
                        label7.Text = "Kuvar " + KUVA.ime + " " + KUVA.prezime;
                        ObjectId oid = new ObjectId(r.ImageId.ToString());
                        var file = db.GridFS.FindOne(Query.EQ("_id", oid));
                        sFileName = newFileName + "\\" + System.IO.Path.GetFileName(file.Name);
                        if (!File.Exists(sFileName))
                        {
                            using (var stream = file.OpenRead())
                            {
                                var bytes = new byte[stream.Length];
                                stream.Read(bytes, 0, (int)stream.Length);
                                var filestream = new FileStream(newFileName + "\\" + System.IO.Path.GetFileName(file.Name), FileMode.Create);

                                using (var newFs = filestream)
                                {
                                    newFs.Write(bytes, 0, bytes.Length);

                                }


                            }
                            pictureBox1.Image = new Bitmap(newFileName + "\\" + System.IO.Path.GetFileName(file.Name));

                            pictureBox1.Height = 150;
                            pictureBox1.Width = 150;
                        }
                        else
                        {
                            using (FileStream fs = File.OpenRead(sFileName))
                            {
                                // Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                                // Add some information to the file.
                                // fs.Write(info, 0, info.Length);
                                pictureBox1.Image = new Bitmap(fs.Name);

                                pictureBox1.Height = 150;
                                pictureBox1.Width = 150;


                            }
                        }

                    }

                }
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
