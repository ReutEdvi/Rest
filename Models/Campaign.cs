using ResturantApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Models
{
    public class Campaign
    {
        int id;
        int investedAmount;
        int balance;
        int viewsNum;
        int clicksNum;
        bool status;

        public Campaign() { }
        public Campaign(int id, int investedAmount, int balance, int viewsNum, int clicksNum, bool status)
        {
            Id = id;
            InvestedAmount = investedAmount;
            Balance = balance;
            ViewsNum = viewsNum;
            ClicksNum = clicksNum;
            Status = status;
        }

        public int Id { get => id; set => id = value; }
        public int InvestedAmount { get => investedAmount; set => investedAmount = value; }
        public int Balance { get => balance; set => balance = value; }
        public int ViewsNum { get => viewsNum; set => viewsNum = value; }
        public int ClicksNum { get => clicksNum; set => clicksNum = value; }
        public bool Status { get => status; set => status = value; }

        public List<Campaign> Read()
        {
            DBServices dbs = new DBServices();
            List<Campaign> CampList = dbs.ReadCampaignData();
            return CampList;

        }
        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.Insert(this);
        }
        //public void InsertAmount(Campaign camp)
        //{
        //    DBServices dbs = new DBServices();
        //    dbs.InsertCampignAmont(camp);
        //}
        public Campaign Update()
        {
            DBServices dbs = new DBServices();
            //Campaign campaign = dbs.UpdateCamp(this);
            //dbs.InsertCampignAmont(this);
            return dbs.InsertCampignAmont(this);

        }
        //public int Insert()
        //{
        //    DBServices dbs = new DBServices();
        //    return dbs.Insert(this);
        //}
        //public void InsertAmount()
        //{
        //    DBServices dbs = new DBServices();
        //    dbs.InsertCampignAmont(this);
        //}
        //public Businesses ReadCamp(int id)
        //{
        //    DBServices dbs = new DBServices();
        //    return dbs.ReadCampaign(id);

        //}
        //public Campaign Read(int id)
        //{
        //    DBServices dbs = new DBServices();
        //    return dbs.ReadCampaigns(id);




        //}
        //public List<Campaign> Update()
        //{
        //    DBServices dbs = new DBServices();
        //    //Campaign campaign = dbs.UpdateCamp(this);
        //    dbs.InsertCampignAmont(this);
        //    return dbs.InsertCampignAmont();

        //}
    }
}