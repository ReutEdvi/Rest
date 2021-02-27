using ResturantApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Models
{
    public class Businesses
    {
        int id;
        string photo;
        string name;
        double rating;
        string category;
        int priceRange;
        string address;
        string phone;
        string linkUrl;
        List<Highlights> highlights;



        public Businesses() { }

        public Businesses(int id, string photo, string name, double rating, string category, int priceRange, string address, string phone, string linkUrl)
        {
            Id = id;
            Photo = photo;
            Name = name;
            Rating = rating;
            Category = category;
            PriceRange = priceRange;
            Address = address;
            Phone = phone;
            LinkUrl = linkUrl;
        }

        public int Id { get => id; set => id = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Name { get => name; set => name = value; }
        public double Rating { get => rating; set => rating = value; }
        public string Category { get => category; set => category = value; }
        public int PriceRange { get => priceRange; set => priceRange = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string LinkUrl { get => linkUrl; set => linkUrl = value; }


        //public void Insert()
        //{
        //    DBServices dbs = new DBServices();
        //    dbs.InsertBusinesses(this);
        //}
        ////new
        //public List<Businesses> Read()
        //{
        //    DBServices dbs = new DBServices();
        //    List<Businesses> fList = dbs.ReadBusinesses();
        //    return fList;

        //}

        public List<Businesses> Read(string categ)
        {
            DBServices dbs = new DBServices();
            return dbs.ReadResturantNonReg(categ);

        }
        public Businesses ReadCamp(int id)
        {
            DBServices dbs = new DBServices();
            return dbs.ReadCampaign(id);

        }
        //old
        //public List<Businesses> Read()
        //{
        //    DBServices dbs = new DBServices();
        //    return dbs.ReadBusinesses();

        //}
        //favoo
        //public List<Businesses> ReadFav()
        //{
        //    DBServices dbs = new DBServices();
        //    List<Businesses> fList = dbs.getFav();
        //    return fList;

        //}

        //the read of the favorites
        //public List<Businesses> Read()
        //{
        //    DBServices dbs = new DBServices();
        //    List<Businesses> b = dbs.getBusiness();
        //    return b;

        //}
        //public List<Businesses> ReadFav(string categ)
        //{

        //    DBservices dbs = new DBservices();
        //    List<Flight> fList = dbs.getByMaxPrice(maxPrice);
        //    return fList;

        //}


    }
}