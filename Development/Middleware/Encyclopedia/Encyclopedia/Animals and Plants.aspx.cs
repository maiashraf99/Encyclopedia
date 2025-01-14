﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Encyclopedia
{
    public partial class Animals_and_Plants : System.Web.UI.Page
    {
        static string connstring = "datasource = 127.0.0.1; port=3306;username=root;password=123456;database=encyclopedia;";
        MySqlConnection connection = new MySqlConnection(connstring);
        MySqlCommand command;
        MySqlDataReader mdr;

        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            CatID = int.Parse(Request.QueryString["CATID"]);
            connection.Open();
            string selectQuery = "SELECT article.Name FROM article WHERE article.ContentID IN (SELECT content.ContentID FROM content,category WHERE content.CategoryID=category.CategoryID AND category.CategoryID=" + CatID + ");";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            mdr.Read();
            firsttitle.Text = mdr[0].ToString();
            mdr.Read();
            middletitle.Text = mdr[0].ToString();
            mdr.Read();
            lasttitle.Text = mdr[0].ToString();
            mdr.Close();

        }

        protected void Birds_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'Birds and Parrots' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                CatID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            Response.Redirect("Birds and Parrots.aspx?CATID=" + CatID + "&USERID=" + UserID);

        }

        protected void History_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'History' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                int CatID = int.Parse(mdr[0].ToString());
                Response.Redirect("History.aspx?CATID=" + CatID + "&USERID=" + UserID);

            }
            mdr.Close();
        }

        protected void Space_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'Space and Universe' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                CatID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            Response.Redirect("Space and Universe.aspx?CATID=" + CatID + "&USERID=" + UserID);
        }

        protected void Animals_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'Animal and Plants' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                CatID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            Response.Redirect("Animals and Plants.aspx?CATID=" + CatID + "&USERID=" + UserID);
        }

        protected void pubArt_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'Animal and Plants' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                CatID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            Response.Redirect("Publish Article.aspx?CATID=" + CatID + "&USERID=" + UserID);
        }

        protected void upVideo_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'Animal and Plants' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                CatID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            Response.Redirect("Upload Video.aspx?CATID=" + CatID + "&USERID=" + UserID);
        }

        protected void upRecord_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var CatID = 0;
            string selectQuery = "SELECT CategoryID FROM encyclopedia.category WHERE type = 'Animal and Plants' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                CatID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            Response.Redirect("Upload Record.aspx?CATID=" + CatID + "&USERID=" + UserID);
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            Response.Redirect("Home Page.aspx?USERID=" + UserID);
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Looged out successfully");
            Response.Redirect("Unregisterd-Home.aspx");

        }

        protected void ReadMoreBTn(object sender, EventArgs e)
        {
            var UserID = 0;
            UserID = int.Parse(Request.QueryString["USERID"]);
            var ArtName = "";
            System.Web.UI.WebControls.Label lbl;
            System.Web.UI.WebControls.Button btn = sender as System.Web.UI.WebControls.Button;
            switch (btn.ID.ToString())
            {
                case "Card1":
                    lbl = (System.Web.UI.WebControls.Label)form1.FindControl("firsttitle");
                    ArtName = lbl.Text;
                    Response.Redirect("View Content.aspx?ArtName=" + ArtName + "&USERID=" + UserID);
                    break;

                case "Card2":
                    lbl = (System.Web.UI.WebControls.Label)form1.FindControl("middletitle");
                    ArtName = lbl.Text;
                    Response.Redirect("View Content.aspx?ArtName=" + ArtName + "&USERID=" + UserID);
                    break;

                case "Card3":
                    lbl = (System.Web.UI.WebControls.Label)form1.FindControl("lasttitle");
                    ArtName = lbl.Text;
                    Response.Redirect("View Content.aspx?ArtName=" + ArtName);
                    break;

            }

        }
    }
}