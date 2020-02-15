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
    public partial class Recept : Form
    {
        private string sFileName;
        private BsonValue fileId;
        private MongoGridFSFileInfo UploadedFile;
        private MongoGridFSFileInfo OriginalImage;
        private string Id;
        private string  newFileName = System.IO.Directory.GetCurrentDirectory();

        public Kuvar kuvar;
        public Recept(Kuvar k,string id)
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
                button3.Visible = true;
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
                        vreme.Text = r.vreme;
                        dodaci.Text = r.dodaci;
                     
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

            else
            {
                button3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                OpenFileDialog opnfd = new OpenFileDialog();
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            opnfd.Multiselect = true;
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("CookingBook");
            if (opnfd.ShowDialog() != DialogResult.Cancel)
            {
                sFileName = opnfd.FileName;

                if (File.Exists(sFileName))
                {
                    using (FileStream fs = File.OpenRead(sFileName))
                    {
                        // Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                        // Add some information to the file.
                        // fs.Write(info, 0, info.Length);
                        pictureBox1.Image = new Bitmap(fs.Name);

                        pictureBox1.Height = 150;
                        pictureBox1.Width = 150;
                        UploadedFile = db.GridFS.Upload(fs, sFileName);
                        fileId = UploadedFile.Id;
                        fs.Close();
                    }
                }
            }
            /*   

            */
        
            /*using (FileStream fs = File.Open(sFileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
               try
                {
                    var gridFsInfo = db.GridFS.Upload(fs, sFileName);
                    var fileId = gridFsInfo.Id;
                }
              
                catch (Exception ex)
                {
                    Console.Write("Opening the file twice is disallowed.");
                    Console.WriteLine(", as expected: {0}", ex.ToString());
                }
            }
            */

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            BsonValue OriginalImageId=null;
            if (Id == String.Empty)
            {
                if (sFileName == null && !File.Exists(sFileName))
                {
                    MessageBox.Show("Please select image");

                }
                else
                {

                    var connectionString = "mongodb://localhost/?safe=true";
                    var server = MongoServer.Create(connectionString);
                    var db = server.GetDatabase("CookingBook");

                    var kuvariCollection = db.GetCollection<Kuvar>("kuvari");
                    var collection = db.GetCollection<Recepts>("Recepts");
                    Recepts k = new Recepts();
                    k.opis = opis.Text.ToString();
                    k.naziv = naziv.Text.ToString();
                    k.zacini = zacini.Text.ToString();
                    k.vreme = vreme.Text.ToString();
                    k.dodaci = dodaci.Text.ToString();
                    k.ImageId = fileId;

                    collection.Insert(k);
                    var query = Query.And(
                                              (Query.EQ("ID_Kartice", kuvar.ID_Kartice)),
                                              Query.EQ("sifra", kuvar.sifra)
                                              );
                    var sad = kuvariCollection.Find(query);


                    foreach (Kuvar r in sad)
                    {
                        MongoDBRef referenca = new MongoDBRef("Recepts", k.Id);
                        r.Recepts.Add(referenca);
                        k.radnik = new MongoDBRef("kuvari", r.Id);
                        collection.Save(k);
                        kuvariCollection.Save(r);
                    }




                    this.Close();
                }
             
            }
            else
            {
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var db = server.GetDatabase("CookingBook");

                var kuvariCollection = db.GetCollection<Kuvar>("kuvari");
                var collection = db.GetCollection<Recepts>("Recepts");
                ObjectId objectId = new ObjectId(Id);
                var query = Query.And(
                             (Query.EQ("_id", objectId))

                             );
                var recept = collection.Find(query);
                string OriginalImageName=null;
               
                bool takeOriginal = true;
                if (recept.Count() == 1)
                {
                    
                    foreach (Recepts r in recept)
                    {                      
                        ObjectId oid = new ObjectId(r.ImageId.ToString());
                        OriginalImage = db.GridFS.FindOne(Query.EQ("_id", oid));
                        OriginalImageName = OriginalImage.Name;
                        OriginalImageId = OriginalImage.Id;
                    }
                }
                if (UploadedFile == null)
                    UploadedFile = OriginalImage;
                sFileName = newFileName + "\\" + System.IO.Path.GetFileName(UploadedFile.Name);
               var  sFileNameOriginal= newFileName + "\\" + System.IO.Path.GetFileName(OriginalImageName);
                if (sFileName != sFileNameOriginal)
                {
                    takeOriginal = false;
                }
               Recepts k = new Recepts();
                k.opis = opis.Text.ToString();
                k.naziv = naziv.Text.ToString();
                k.zacini = zacini.Text.ToString();
                k.vreme = vreme.Text.ToString();
                k.dodaci = dodaci.Text.ToString();
                k.ImageId = takeOriginal? OriginalImageId : fileId;
                List<UpdateBuilder> list = new List<UpdateBuilder>();
                var opis_update = MongoDB.Driver.Builders.Update.Set("opis", BsonValue.Create(k.opis));
                var naziv_update = MongoDB.Driver.Builders.Update.Set("naziv", BsonValue.Create(k.naziv));
                var zacini_update = MongoDB.Driver.Builders.Update.Set("zacini", BsonValue.Create(k.zacini));
                var vreme_update = MongoDB.Driver.Builders.Update.Set("vreme", BsonValue.Create(k.vreme));
                var dodaci_update = MongoDB.Driver.Builders.Update.Set("dodaci", BsonValue.Create(k.dodaci));

                var slika_update = MongoDB.Driver.Builders.Update.Set("ImageId", k.ImageId);

                list.Add(opis_update);
                list.Add(naziv_update);
                list.Add(zacini_update);
                list.Add(vreme_update);
                list.Add(dodaci_update);
                list.Add(slika_update); 
                var updateCombine = MongoDB.Driver.Builders.Update.Combine(list);
                collection.Update(query, updateCombine);

                foreach (Recepts r in collection.Find(query))
                {
                    string sadsd = r.naziv;
                }

                this.Close();
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("CookingBook");
            var kuvariCollection = db.GetCollection<Kuvar>("kuvari");

            var collection = db.GetCollection<Recepts>("Recepts");
            ObjectId objectId = new ObjectId(Id);
            var query = Query.And(
                         (Query.EQ("_id", objectId))

                         );
            collection.Remove(query);
            var query2 = Query.And(
                                             (Query.EQ("ID_Kartice", kuvar.ID_Kartice)),
                                             Query.EQ("sifra", kuvar.sifra)
                                             );
            var sad = kuvariCollection.Find(query2);

            if (sad.Count() == 1)
            {

                foreach (Kuvar r in sad)
                {
                    MongoDBRef referenca = new MongoDBRef("Recepts", new ObjectId(this.Id));
                    r.Recepts.Remove(referenca);

                    kuvariCollection.Save(r);
                }
            }
            this.Close();

        }

        private void Recept_Load(object sender, EventArgs e)
        {
           
        }
    }
}
