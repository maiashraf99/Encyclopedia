﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Encyclopedia
{
	public partial class View_Content : System.Web.UI.Page
	{
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=123456");
        MySqlCommand command;
        MySqlDataReader mdr;
        protected void Page_Load(object sender, EventArgs e)
		{
            connection.Open();
            var ContentID = 0;
            var UserID = 0;
            var CatID = 0;
            var Username = "";
            var Catname = "";
            var Artname = "";
            var publishdatee = "";
            var ArtContent = "";
            string selectQuery = "SELECT ContentID FROM encyclopedia.article WHERE Name = 'Birds Facts' ;";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                ContentID = int.Parse(mdr[0].ToString());
            }
            mdr.Close();
            //MessageBox.Show(ContentID.ToString());

            string selectQuery2 = "SELECT UserID,CategoryID FROM encyclopedia.content WHERE ContentID = '" + ContentID + "' ;";
            command = new MySqlCommand(selectQuery2, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                UserID = int.Parse(mdr[0].ToString());
                CatID = int.Parse(mdr[1].ToString());
            }
            mdr.Close();
            //MessageBox.Show(UserID.ToString());
            //MessageBox.Show(CatID.ToString());


            //USERNAME
            string selectQuery3 = "SELECT Username FROM encyclopedia.user WHERE UserID = '" + UserID + "' ;";
            command = new MySqlCommand(selectQuery3, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                Username = mdr[0].ToString();
            }
            mdr.Close();
            //MessageBox.Show(Username.ToString());

            //CAT NAME
            string selectQuery4 = "SELECT type FROM encyclopedia.category WHERE CategoryID = '" + CatID + "' ;";
            command = new MySqlCommand(selectQuery4, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                Catname = mdr[0].ToString();
            }
            mdr.Close();
            // MessageBox.Show(Catname.ToString());

            //ARTICLENAME,PUBLISHED DATE
            string selectQuery5 = "SELECT Name,PublishedDate,ArticleContent FROM encyclopedia.article WHERE ContentID = '" + ContentID + "' ;";
            command = new MySqlCommand(selectQuery5, connection);
            mdr = command.ExecuteReader();
            while (mdr.Read())
            {
                Artname = mdr[0].ToString();
                publishdatee = mdr[1].ToString();
                ArtContent = mdr[2].ToString();

            }
            mdr.Close();
            Label1.Text = Artname.ToString();
            Label2.Text = publishdatee.ToString();
            Label3.Text = Username.ToString();
            Label4.Text = ArtContent.ToString();

            /*MessageBox.Show(Artname.ToString());
            MessageBox.Show(publishdatee.ToString());
            MessageBox.Show(ArtContent.ToString());
            MessageBox.Show(Username.ToString());*/
        }
	}
}