using Layout.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Layout.Db
{
    public class DbSeedData
    {
        private readonly Database db;

        public DbSeedData(Database db)
        {
            this.db = db;
        }

        public void Seed()
        {
            AddUsers();
            AddProducts("SeedData/product.data");
            AddPurchases("SeedData/purchases.data");
            AddPurchaseDetails("SeedData/purchasedetails.data");
            AddActivationKeys("SeedData/activationkeys.data");
        }

        public void AddUsers()
        {
            string[] usernameArr = new string[] { "Jon", "Jane" };
            string[] passwordArr = new string[] { "1234", "4321" };

            for (int i = 0; i < usernameArr.Length; i++)
            {
                db.Add(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = usernameArr[i],
                    Password = passwordArr[i],
                    IsBlacklisted = false
                });
            }
            db.SaveChanges();
        }


        public void AddProducts(string filename)
        {
 
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] quartet  = line.Split(";");
                if (quartet.Length == 4)
                {
                    db.Products.Add(new Product
                    {
                        Name = quartet[0],
                        Description = quartet[1],
                        Price = double.Parse(quartet[2]),
                        Image = quartet[3]
                    });
                }
            }

            db.SaveChanges();
        }

        public void AddPurchases(string filename)
        {

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] temp = line.Split(";");
                if (temp.Length == 2)
                {
                    User jane = db.Users.Where(x => x.Username == "Jane").FirstOrDefault();
                    db.Purchases.Add(new Purchase
                    {
                        Id = temp[0],
                        Timestamp = long.Parse(temp[1]),
                        UserId = jane.Id
                    });
                }
            }

            db.SaveChanges();
        }

        public void AddPurchaseDetails(string filename)
        {

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] temp = line.Split(";");
                if (temp.Length == 3)
                {
                    User jane = db.Users.Where(x => x.Username == "Jane").FirstOrDefault();
                    db.PurchaseDetails.Add(new PurchaseDetail
                    {
                        PurchaseId = temp[0],
                        ProductId = int.Parse(temp[1]),
                        Quantity = int.Parse(temp[2]),
                        UserId = jane.Id
                    });
                }
            }

            db.SaveChanges();
        }

        public void AddActivationKeys(string filename)
        {

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] temp = line.Split(";");
                if (temp.Length == 3)
                {
                    db.ActivationKeys.Add(new ActivationKey
                    {
                        PurchaseDetailPurchaseId = temp[0],
                        PurchaseDetailProductId = int.Parse(temp[1]),
                        PdtAtvKey = temp[2]
                    }) ;
                }
            }

            db.SaveChanges();
        }
    }
}
